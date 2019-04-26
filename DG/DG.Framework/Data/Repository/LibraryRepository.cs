using DG.Framework.Data.Contract;
using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DG.Framework.Data.Abstraction
{
    public abstract class LibraryRepository<T> : SPRepository<T>
        where T : LibraryDomain<T>
    {
        /// <summary>
        /// Esta classe abstrata só é instanciada a partir do construtor invocando :base(SPWeb).
        /// </summary>
        /// <param name="web">Objeto SPWeb que este repositório irá utilizar para realizar as operações.</param>
        public LibraryRepository(SPWeb web)
            : base(web)
        {

        }

        public void CheckIn(int id, string comment)
        {
            throw new System.NotImplementedException();
        }

        public void CheckOut(int id)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateBinary(int id, byte[] data)
        {
            throw new System.NotImplementedException();
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

