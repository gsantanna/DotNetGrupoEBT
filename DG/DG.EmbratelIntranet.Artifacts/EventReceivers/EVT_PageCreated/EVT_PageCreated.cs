using System;
using System.Linq;
using System.Security.Permissions;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.Workflow;
using DG.Framework.Data.Adapter;
using System.Collections.Generic;
using DG.Framework.Domain;

namespace DG.EmbratelIntranet.Home.Artifacts.EventReceivers.EVT_PageCreated
{
    /// <summary>
    /// List Item Events
    /// </summary>
    public class EVT_PageCreated : SPItemEventReceiver
    {
        /// <summary>
        /// An item was added.
        /// </summary>
        public override void ItemAdded(SPItemEventProperties properties)
        {
            base.ItemAdded(properties);

            try
            {
                if (properties.ListItem.ContentTypeId.IsChildOf(new SPContentTypeId("0x01010901"))) //pagina de webparts
                {
                    if (MemoryPersisted.Contains(properties.Web.CurrentUser.ID, "NewPageActionReferrer"))
                    {
                        string urlReferrer = MemoryPersisted.Get<string>(properties.Web.CurrentUser.ID, "NewPageActionReferrer");
                        string secao = MemoryPersisted.Get<string>(properties.Web.CurrentUser.ID, "SecaoMenu");

                        MenuPrincipalAdapter adapter = new MenuPrincipalAdapter(properties.Site.RootWeb);

                        IEnumerable<MenuPrincipal> referrerMenus = adapter.GetByQuery(
                             string.Format("<Where><And><Eq><FieldRef Name=\"{0}\" /><Value Type=\"Text\">{1}</Value></Eq><Contains><FieldRef Name=\"{2}\" /><Value Type=\"Text\">{3}</Value></Contains></And></Where>",
                             MenuPrincipal.FieldNameURL, urlReferrer, MenuPrincipal.FieldNameSecao, secao));

                        MenuPrincipal referrerUrlMenu = referrerMenus.FirstOrDefault();

                        //if (referrerUrlMenu != null)
                        //{
                        MenuPrincipal newChildMenu = new MenuPrincipal();
                        newChildMenu.Title = properties.ListItem.File.Name.Remove(properties.ListItem.File.Name.LastIndexOf('.'));
                        newChildMenu.URL = properties.ListItem.File.ServerRelativeUrl;
                        newChildMenu.Destino = EmbratelIntranet.Home.Core.Domain.Destino._self;
                        newChildMenu.Secao = secao;
                        newChildMenu.ParentLookup.Value = referrerUrlMenu;

                        adapter.Add(newChildMenu);
                        //}
                    }
                }
            }
            catch { }
        }


    }
}