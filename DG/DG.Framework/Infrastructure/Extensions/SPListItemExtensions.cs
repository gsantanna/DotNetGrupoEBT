using DG.Framework.Data.Contract;
using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DG
{
    public static class SPListItemExtensions
    {
        public static object GetValueByInternalName(this SPListItem item, string internalname)
        {
            return item[item.Fields.GetFieldByInternalName(internalname).Id];
        }

        public static SPFieldUserValue GetUserValueByInternalName(this SPListItem item, string internalname)
        {
            return new SPFieldUserValue(item.Web, (string)item.GetValueByInternalName(internalname));
        }

        public static T ToDomain<T>(this SPListItem item, IRepository<T> lookupRepository) where T : IDomain<T>
        {
            return item.ToDomain(typeof(T).Name, lookupRepository);
        }

        public static T ToDomain<T>(this SPListItem item, string campo, IRepository<T> lookupRepository) where T : IDomain<T>
        {
            if (item[item.Fields.GetFieldByInternalName(campo).Title] != null)
            {
                SPFieldLookupValue value = new SPFieldLookupValue(item[item.Fields.GetFieldByInternalName(campo).Title].ToString());
                return lookupRepository.GetByID(value.LookupId);
            }
            else
                return default(T);
        }

        public static IEnumerable<T> ToDomains<T>(this SPListItem item, IRepository<T> lookupRepository) where T : IDomain<T>
        {
            return item.ToDomains(typeof(T).Name, lookupRepository);
        }

        public static IEnumerable<T> ToDomains<T>(this SPListItem item, string campoMultiLookup, IRepository<T> lookupRepository) where T : IDomain<T>
        {
            object value = item[item.Fields.GetFieldByInternalName(campoMultiLookup).Title];
            if (value != null)
            {
                foreach (SPFieldLookupValue itemPlano in new SPFieldLookupValueCollection(value.ToString()))
                    yield return lookupRepository.GetByID(itemPlano.LookupId);
            }
        }

    }
}
