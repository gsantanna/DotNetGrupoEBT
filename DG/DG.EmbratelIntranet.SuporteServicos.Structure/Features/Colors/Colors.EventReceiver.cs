using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Microsoft.SharePoint;

namespace DG.EmbratelIntranet.SuporteServicos.Structure.Features.Colors
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>

    [Guid("7d7d0965-85ed-475b-9a52-8bcfb9720546")]
    public class ColorsEventReceiver : SPFeatureReceiver
    {
        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            //SPSite site = properties.Feature.Parent as SPSite;
            SPWeb web = properties.Feature.Parent as SPWeb;

            SetMasterPage(web, "_catalogs/masterpage/template.master");
        }

        private static void SetMasterPage(SPWeb web, string master)
        {
            web.MasterUrl = master;
            web.CustomMasterUrl = master;

            web.Update();
        }


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
