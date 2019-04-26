using DG.Framework.Data.Contract;
using DG.EmbratelIntranet.Home.Core.Domain;
using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DG.Framework.Data.Adapter;

namespace DG.Framework.Domain
{
    /// <remarks>Lista de dispositivos no sharepoint contendo os dados do dispositivo.</remarks>
    [InternalName("Pessoas")]
    public class Pessoa : ListDomain<Pessoa>
    {
        internal const string FieldNameNome = "NOME_EMPREGADO";
        internal const string FieldNameMatricula = "MATRICULA";
        internal const string FieldNameCargo = "DESC_CARGO";
        internal const string FieldNameRamal = "TELEF1_COM";
        internal const string FieldNameCelular = "CEL_COM";
        internal const string FieldNameEmail = "EMAIL";
        internal const string FieldNameUsername = "USERNAME";
        internal const string FieldNameDATA_NASCIMENTO = "DATA_NASCIMENTO";
        internal const string FieldNameAREA = "AREA";
        internal const string FieldNameDATA_ANIVERSARIO = "DATA_ANIVERSARIO";
        internal const string FieldNameFOTO_HTML = "FOTO_HTML";
        internal const string FieldNameLOTACAO_HTML = "LOTACAO_HTML";
        internal const string FieldNameINI_SEMA_ANIV = "INI_SEMA_ANIV";
        internal const string FieldNameFIM_SEMA_ANIV = "FIM_SEMA_ANIV";
        internal const string FieldNameLOTACAO_TEXT = "LOTACAO_TEXT";

        public string Nome { get; set; }

        public string Matricula { get; set; }
        public string Cargo { get; set; }
        public string Ramal { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public SPUser Username { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Area { get; set; }
        public string DataAniversario { get; set; }
        public string FOTO_HTML { get; set; }
        public string LOTACAO_HTML { get; set; }
        public string INI_SEMA_ANIV { get; set; }
        public string FIM_SEMA_ANIV { get; set; }
        public string LOTACAO_TEXT { get; set; }

        public int DiaAniversario { get { return DataNascimento.Day; } }

        public int MesAniversario { get { return DataNascimento.Month; } }

        public override IRepository<Pessoa> Adapt(SPWeb web)
        {
            return new PessoaAdapter(web);
        }
    }
}

