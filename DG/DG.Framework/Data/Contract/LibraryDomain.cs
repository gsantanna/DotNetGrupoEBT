using DG.Framework.Data.Abstraction;
using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DG.Framework.Data.Contract
{
    public abstract class LibraryDomain<T> : IDomain<T>
        where T : LibraryDomain<T>
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public byte[] FileData { get; set; }

        public string FileName { get; set; }

        //public Dictionary<string, SPFieldType> Fields { get; set; }
        
        public LibraryDomain()
        {
            //Fields = new Dictionary<string, SPFieldType>();
        }

        public abstract IRepository<T> Adapt(SPWeb web);
    }
}

