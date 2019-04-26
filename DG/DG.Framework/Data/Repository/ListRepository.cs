using DG.Framework.Data.Contract;
using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DG.Framework.Data.Abstraction
{
    public abstract class ListRepository<T> : SPRepository<T>
        where T : ListDomain<T>
    {

        /// <summary>
        /// Esta classe abstrata só é instanciada a partir do construtor invocando :base(SPWeb).
        /// </summary>
        /// <param name="web">Objeto SPWeb que este repositório irá utilizar para realizar as operações.</param>
        public ListRepository(SPWeb web)
            : base(web)
        {

        }

        protected override T GetDomain(SPListItem item)
        {
            return GetDomainFromSPListItem(item);
        }

        protected override void SetItemProperties(SPListItem item, T dominio)
        {
            SetItemFromDomain(item, dominio);
        }

        protected abstract T GetDomainFromSPListItem(SPListItem item);

        protected abstract void SetItemFromDomain(SPListItem item, T dominio);

    }
}

