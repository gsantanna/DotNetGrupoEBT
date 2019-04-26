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
    /// <remarks>Lista de exclusoes no sharepoint contendo os dados do pessoas para excluir.</remarks>
    [InternalName("ExclusaoAniversariantes")]
    public class AniversarianteExclusao : ListDomain<AniversarianteExclusao>
    {
        internal const string FieldUsername = "Author";

        public string USERNAME { get; set; }
        public override IRepository<AniversarianteExclusao> Adapt(SPWeb web)
        {
            return new AniversarianteExclusaoAdapter(web);
        }
    }
}

