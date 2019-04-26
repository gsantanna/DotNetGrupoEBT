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
    public class Aniversariante : ListDomain<Aniversariante>
    {
        internal const string FieldNameNome = "NOME_EMPREGADO";
        internal const string FieldNameDataNascimento = "DATA_NASCIMENTO";
        internal const string FieldNameAreaLotacao = "AREA_LOTACAO";
        internal const string FieldNameUsername = "USERNAME";
        //internal const string FieldNameDiaNascimento = "dia_nascimento";
        //internal const string FieldNameMesNascimento = "mes_nascimento";

        public string Nome { get; set; }

        public string USERNAME { get; set; }

        public string AREA_LOTACAO { get; set; }

        public DateTime DataNascimento { get; set; }

        public int DiaAniversario { get { return DataNascimento.Day; } }

        public int MesAniversario { get { return DataNascimento.Month; } }

        public override IRepository<Aniversariante> Adapt(SPWeb web)
        {
            return new AniversarianteAdapter(web);
        }
    }
}

