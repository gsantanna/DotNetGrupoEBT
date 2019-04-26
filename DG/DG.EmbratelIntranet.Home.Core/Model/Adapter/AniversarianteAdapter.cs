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
    public class AniversarianteAdapter : ListRepository<Aniversariante>
    {
        public AniversarianteAdapter(SPWeb web)
            : base(web)
        {

        }

        protected override Aniversariante GetDomainFromSPListItem(SPListItem item)
        {
            Aniversariante dominio = new Aniversariante();
            dominio.ID = item.ID;
            dominio.Nome = (string)item[Aniversariante.FieldNameNome];
            dominio.DataNascimento = Convert.ToDateTime(item.GetValueByInternalName(Aniversariante.FieldNameDataNascimento));
            dominio.AREA_LOTACAO = (string)item[Aniversariante.FieldNameAreaLotacao];
            dominio.USERNAME = (string)item[Aniversariante.FieldNameUsername];

            //dominio.DiaAniversario = Convert.ToInt32(item.GetValueByInternalName(Aniversariante.FieldNameDiaNascimento));
            //dominio.MesAniversario = Convert.ToInt32(item.GetValueByInternalName(Aniversariante.FieldNameMesNascimento));
            return dominio;
        }

        protected override void SetItemFromDomain(SPListItem item, Aniversariante dominio)
        {
            throw new NotImplementedException();
        }
    }
}

