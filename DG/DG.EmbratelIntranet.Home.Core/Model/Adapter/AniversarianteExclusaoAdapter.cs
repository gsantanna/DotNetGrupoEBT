using DG.Framework.Data.Abstraction;
using DG.Framework.Data.Contract;
using DG.Framework.Domain;
using DG.EmbratelIntranet.Home.Core.Domain;
using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DG.Framework.Data.External;

namespace DG.Framework.Data.Adapter
{
    public class AniversarianteExclusaoAdapter : ListRepository<AniversarianteExclusao>
    {
        public AniversarianteExclusaoAdapter(SPWeb web)
            : base(web)
        {

        }

        protected override AniversarianteExclusao GetDomainFromSPListItem(SPListItem item)
        {
            AniversarianteExclusao dominio = new AniversarianteExclusao();
            dominio.USERNAME = (string)item[AniversarianteExclusao.FieldUsername];
            return dominio;
        }

        protected override void SetItemFromDomain(SPListItem item, AniversarianteExclusao dominio)
        {
            throw new NotImplementedException();
        }
    }
}

