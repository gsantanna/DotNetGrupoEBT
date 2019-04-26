using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebPartPages;

namespace DG.EmbratelIntranet.Empresa.Structure.Features.Content
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>

    [Guid("3b8be90a-1d3e-49e0-bee1-09f38c423421")]
    public class ContentEventReceiver : SPFeatureReceiver
    {
        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            try
            {
                SPWeb web = properties.Feature.Parent as SPWeb;

                foreach (SPList list in web.Lists.OfType<SPList>().Where(l => !l.Hidden))
                {
                    list.NavigateForFormsPages = false;
                    list.Update();

                    using (SPLimitedWebPartManager wpm = web.GetLimitedWebPartManager(list.DefaultNewFormUrl, System.Web.UI.WebControls.WebParts.PersonalizationScope.Shared))
                    {
                        foreach (WebPart wp in wpm.WebParts)
                        {
                            if (wp is ListFormWebPart)
                            {
                                ListFormWebPart lfwp = (ListFormWebPart)wp;
                                lfwp.CSRRenderMode = CSRRenderMode.ServerRender;
                                wpm.SaveChanges(lfwp);
                            }
                        }
                    }
                }
                web.Update();
            }
            catch (Exception ex)
            {
            }
        }


        // Uncomment the method below to handle the event raised before a feature is deactivated.

        //public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
        //{
        //}


        // Uncomment the method below to handle the event raised after a feature has been installed.

        //public override void FeatureInstalled(SPFeatureReceiverProperties properties)
        //{
        //}


        // Uncomment the method below to handle the event raised before a feature is uninstalled.

        //public override void FeatureUninstalling(SPFeatureReceiverProperties properties)
        //{
        //}

        // Uncomment the method below to handle the event raised when a feature is upgrading.

        //public override void FeatureUpgrading(SPFeatureReceiverProperties properties, string upgradeActionName, System.Collections.Generic.IDictionary<string, string> parameters)
        //{
        //}
    }
}
