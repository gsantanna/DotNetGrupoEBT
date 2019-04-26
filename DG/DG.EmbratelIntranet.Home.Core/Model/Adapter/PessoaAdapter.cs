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
    public class PessoaAdapter : ListRepository<Pessoa>
    {
        public PessoaAdapter(SPWeb web)
            : base(web)
        {

        }

        protected override Pessoa GetDomainFromSPListItem(SPListItem item)
        {
            Pessoa dominio = new Pessoa();
            dominio.ID = item.ID;
            
            if (CurrentView != null && CurrentView.Title == "Eu")
                GetViewEU(item, dominio);
            else
            {
                dominio.Nome = (string)item.GetValueByInternalName(Pessoa.FieldNameNome);
                dominio.Matricula = (string)item.GetValueByInternalName(Pessoa.FieldNameMatricula);
                dominio.Cargo = (string)item.GetValueByInternalName(Pessoa.FieldNameCargo);
                dominio.Ramal = (string)item.GetValueByInternalName(Pessoa.FieldNameRamal);
                dominio.Celular = (string)item.GetValueByInternalName(Pessoa.FieldNameCelular);
                dominio.Email = (string)item.GetValueByInternalName(Pessoa.FieldNameEmail);
                dominio.Username = (SPUser)item.GetValueByInternalName(Pessoa.FieldNameUsername);
                dominio.DataNascimento = Convert.ToDateTime(item.GetValueByInternalName(Pessoa.FieldNameDATA_NASCIMENTO));
                dominio.Area = (string)item.GetValueByInternalName(Pessoa.FieldNameAREA);
                dominio.DataAniversario = (string)item.GetValueByInternalName(Pessoa.FieldNameDATA_ANIVERSARIO);
                dominio.FOTO_HTML = (string)item.GetValueByInternalName(Pessoa.FieldNameFOTO_HTML);
                dominio.LOTACAO_HTML = (string)item.GetValueByInternalName(Pessoa.FieldNameLOTACAO_HTML);
                dominio.INI_SEMA_ANIV = (string)item.GetValueByInternalName(Pessoa.FieldNameINI_SEMA_ANIV);
                dominio.FIM_SEMA_ANIV = (string)item.GetValueByInternalName(Pessoa.FieldNameFIM_SEMA_ANIV);
                dominio.LOTACAO_HTML = (string)item.GetValueByInternalName(Pessoa.FieldNameLOTACAO_TEXT);
            }

            return dominio;
        }

        private void GetViewEU(SPListItem item, Pessoa dominio)
        {
            dominio.Nome = (string)item.GetValueByInternalName(Pessoa.FieldNameNome);
            dominio.Matricula = (string)item.GetValueByInternalName(Pessoa.FieldNameMatricula);
            dominio.Cargo = (string)item.GetValueByInternalName(Pessoa.FieldNameCargo);
            dominio.Ramal = (string)item.GetValueByInternalName(Pessoa.FieldNameRamal);
            dominio.Celular = (string)item.GetValueByInternalName(Pessoa.FieldNameCelular);
            dominio.Email = (string)item.GetValueByInternalName(Pessoa.FieldNameEmail);
            dominio.Username = item.GetUserValueByInternalName(Pessoa.FieldNameUsername).User;
            dominio.FOTO_HTML = ((string)item.GetValueByInternalName(Pessoa.FieldNameFOTO_HTML)).Replace("string;#{HTML}", "");
            dominio.LOTACAO_HTML = ((string)item.GetValueByInternalName(Pessoa.FieldNameLOTACAO_HTML)).Replace("string;#{HTML}", "");
        }

        protected override void SetItemFromDomain(SPListItem item, Pessoa dominio)
        {
            throw new NotImplementedException();
        }
    }
}

