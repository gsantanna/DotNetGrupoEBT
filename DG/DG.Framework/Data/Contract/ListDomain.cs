using DG.Framework.Data.Abstraction;
using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DG.Framework.Data.Contract
{
    public abstract class ListDomain<T> : IDomain<T>
        where T : ListDomain<T>
    {
        public const string FieldNameTitle = "Title";

        public int ID { get; set; }

        public string Title { get; set; }

        //public Dictionary<string, SPFieldType> Fields { get; set; }

        public ListDomain()
        {
            //Fields = new Dictionary<string, SPFieldType>();
        }

        public abstract IRepository<T> Adapt(SPWeb web);

    }
}

