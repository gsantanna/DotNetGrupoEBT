using DG.Framework.Data.Contract;
using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DG.Framework.Strategy
{
    /// <remarks>Lista de tipos de dispositivos no sharepoint que estão sendo utilizados</remarks>
    internal class Configuration : ListDomain<Configuration>
    {
        internal const string FieldNameValue = "Value";

        internal string Value { get; set; }

        public override IRepository<Configuration> Adapt(SPWeb web) { return new ConfigurationAdapter(web); }
    }
}

