using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.Navigation;

namespace DG.EmbratelIntranet.Gente.Structure.Features.Install
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>

    [Guid("488fb5d0-44d4-4487-8772-4449532d8e39")]
    public class InstallEventReceiver : SPFeatureReceiver
    {
        // Uncomment the method below to handle the event raised after a feature has been activated.

        string name = "Gente";
        string path = "/Gente";

        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            SPWebApplication webApp = properties.Feature.Parent as SPWebApplication;

            CreateManagedPath(path, webApp);

            SPSite site = CreateSPSite(webApp, name, path);

            //SPSolution solution = SPFarm.Local.Solutions.SingleOrDefault(s => s.Name == "dg.embratelintranet.gente.structure.wsp");
            //solution.Deploy()

            //ActivateFeature(site, "DG.EmbratelIntranet.Gente Colors");

        }

        private static SPSite CreateSPSite(SPWebApplication webApp, string name, string path)
        {
            SPSite site = webApp.Sites.Add(path, name, null, 1046, "STS#0", webApp.ApplicationPool.Username, webApp.ApplicationPool.Username, "admin@contoso.com");
            return site;
        }


        private static void CreateManagedPath(string path, SPWebApplication webApp)
        {
            SPPrefixCollection prefixColl = webApp.Prefixes;

            if (prefixColl.Contains(path) == false)
            {
                SPPrefix newPrefix = webApp.Prefixes.Add(path, SPPrefixType.ExplicitInclusion);
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
