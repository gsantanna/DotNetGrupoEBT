using DG.Framework.Data.Contract;
using DG.EmbratelIntranet.Home.Core.Domain;
using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DG.Framework.Data.Abstraction;
using DG.Framework.Data.Adapter;
using DG.Framework.Core.Data.Contract;

namespace DG.Framework.Domain
{
    /// <remarks>Lista de dispositivos no sharepoint contendo os dados do dispositivo.</remarks>
    [InternalName("MenuPrincipal")]
    public class MenuPrincipal : ListDomain<MenuPrincipal>
    {
        public const string FieldNameURL = "URL";
        public const string FieldNameSecao = "Secao";
        public const string FieldNameParentLookup = "ParentID";
        public const string FieldNameOrdem = "Ordem";
        public const string FieldNameDestino = "Destino";
        public const string FieldNameClassedeEstiloCSS = "ClassedeEstiloCSS";

        public string URL { get; set; }

        public string Secao { get; set; }

        public LookupDomain<MenuPrincipal> ParentLookup { get; set; }

        public int ParentID { get { return ParentLookup.LookupValue != null ? ParentLookup.LookupValue.LookupId : 0; } }

        public MenuPrincipal Parent { get { return ParentLookup.Value; } }

        public int Ordem { get; set; }

        public Destino Destino { get; set; }

        public string ClassedeEstiloCSS { get; set; }

        public override IRepository<MenuPrincipal> Adapt(SPWeb web)
        {
            return new MenuPrincipalAdapter(web);
        }

        public MenuPrincipal() 
        {
            ParentLookup = new LookupDomain<MenuPrincipal>();
        }

    }
}

