using DG.Framework.Data.Contract;
using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace DG.Framework.Core.Data.Contract
{
    public interface IAdapter<T> where T : IDomain<T>
    {
        T GetDomainFromSPListItem(SPListItem item);

        void SetItemFromDomain(SPListItem item, T dominio);
    }
}
