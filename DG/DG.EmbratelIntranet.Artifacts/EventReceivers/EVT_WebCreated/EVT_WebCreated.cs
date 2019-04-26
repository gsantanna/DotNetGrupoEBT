using System;
using System.Linq;
using System.Security.Permissions;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.Workflow;

namespace DG.EmbratelIntranet.Home.Artifacts.EventReceivers.EVT_WebCreated
{
    /// <summary>
    /// Web Events
    /// </summary>
    public class EVT_WebCreated : SPWebEventReceiver
    {
        /// <summary>
        /// A site was provisioned.
        /// </summary>
        public override void WebProvisioned(SPWebEventProperties properties)
        {
            base.WebProvisioned(properties);

            try
            {
                SPEventReceiverDefinition pageAddedEvt = properties.Web.Site.EventReceivers
                    .OfType<SPEventReceiverDefinition>()
                    .FirstOrDefault(evt => evt.Name == "EVT_PageCreatedItemAdded");

                if (pageAddedEvt != null)
                {
                    foreach (SPList list in properties.Web.Lists.OfType<SPList>().Where(l => !l.Hidden && l.BaseType == SPBaseType.DocumentLibrary))
                    {
                        SPEventReceiverDefinition newEvt = list.EventReceivers.Add(pageAddedEvt.Id);

                        newEvt.Update();
                        list.Update();
                    }
                }
            }
            catch { }
        }


    }
}