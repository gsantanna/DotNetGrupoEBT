using DG.Framework.Data.Abstraction;
using DG.Framework.Data.Contract;
using DG.Framework.Domain;
using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DG.Framework.Data.Adapter
{
    internal class ConfigurationAdapter : ListRepository<Configuration>
    {
        internal ConfigurationAdapter(SPWeb web)
            : base(web)
        {
        }

        protected override Configuration GetDomainFromSPListItem(SPListItem item)
        {
            Configuration domain = new Configuration();
            domain.ID = item.ID;
            domain.Title = item.Title;
            domain.Value = (string)item[Configuration.FieldNameValue];
            return domain;
        }

        protected override void SetItemFromDomain(SPListItem item, Configuration dominio)
        {
            throw new NotImplementedException();
        }
    }
}

