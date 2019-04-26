using DG.Framework.Data.Contract;
using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DG
{
    public static class DomainExtensions
    {
        public static SPFieldLookupValueCollection ToLookupMulti<T>(this List<T> dominios) where T : IDomain<T>
        {
            if (dominios == null)
                return null;

            SPFieldLookupValueCollection list = new SPFieldLookupValueCollection();

            foreach (T domain in dominios)
                if (domain != null)
                    list.Add(new SPFieldLookupValue(domain.ID, domain.Title));

            return list;
        }

        public static SPFieldLookupValue ToLookup<T>(this T dominio) where T : IDomain<T>
        {
            if (dominio == null)
                return null;

            return new SPFieldLookupValue(dominio.ID, dominio.Title);
        }

    }
}
