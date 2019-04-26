using DG.Framework.Core.Data.Contract;
using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DG.Framework.Data.Contract
{
    public interface IDomain<T> where T : IDomain<T>
    {

        int ID { get; set; }

        string Title { get; set; }

        //Dictionary<string, SPFieldType> Fields { get; set; }

        IRepository<T> Adapt(SPWeb web);
    }
} 

