using DG.Framework.Data.Contract;
using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DG.Framework.Core.Data.Contract
{
    public class LookupDomain<T>
        where T : IDomain<T>
    {
        private IRepository<T> Repository { get; set; }

        public SPWeb Web { get; set; }
        public SPFieldLookupValue LookupValue { get; set; }

        private bool __IsValueSetted;
        private T __value;

        public T Value
        {
            get
            {
                if (!__IsValueSetted && __value == null && LookupValue != null)
                    __value = Activator.CreateInstance<T>().Adapt(Web).GetByID(LookupValue.LookupId);

                return __value;
            }
            set { __value = value; __IsValueSetted = true; }
        }

        public LookupDomain() { }

        public LookupDomain(SPWeb web, SPFieldLookupValue lookupvalue)
        {
            this.Web = web;
            this.LookupValue = lookupvalue;
        }
    }
}
