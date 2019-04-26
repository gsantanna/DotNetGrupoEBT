using System;
using System.Security.Permissions;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.Workflow;
using System.Web;

namespace DG.EmbratelIntranet.Home.Artifacts.EventReceivers.EVT_PermMgr
{
    /// <summary>
    /// List Item Events
    /// </summary>
    public class EVT_PermMgr : SPItemEventReceiver
    {
        /// <summary>
        /// An item is being added.
        /// </summary>
        public override void ItemAdding(SPItemEventProperties properties)
        {
            base.ItemAdding(properties);

            //try
            //{
            //    if (properties.ListTitle == "Notícias")
            //    {
            //        SPQuery query = new SPQuery()
            //        {
            //            Query = "<OrderBy><FieldRef Name=\"ID\" Ascending=\"False\"></FieldRef></OrderBy><Where><Eq><FieldRef Name=\"Author\" LookupId=\"TRUE\" /><Value Type=\"Integer\"><UserID /></Value></Eq></Where>",
            //            RowLimit = 1
            //        };


            //        foreach (SPListItem item in properties.List.GetItems(query))
            //        {
            //            string redirecturl = string.Format("{0}/_layouts/15/User.aspx?List={1}&obj={1},{2},LISTITEM&Source={3}",
            //                properties.WebUrl,
            //                HttpUtility.UrlEncode(properties.ListId.ToString("B")),
            //                item.ID,
            //                HttpUtility.UrlEncode(properties.List.DefaultViewUrl));

            //            properties.Status = SPEventReceiverStatus.CancelWithRedirectUrl;
            //            properties.RedirectUrl = redirecturl;
            //        }
            //    }
            //}
            //catch { }
        }

    }
}