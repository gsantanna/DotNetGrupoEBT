using DG.EmbratelIntranet.Home.Core.Domain;
using DG.Framework.Core.Data.Contract;
using DG.Framework.Data.Abstraction;
using DG.Framework.Domain;
using Microsoft.SharePoint;
using System;

namespace DG.Framework.Data.Adapter
{
    public class MenuPrincipalAdapter : ListRepository<MenuPrincipal>
    {
        public MenuPrincipalAdapter(SPWeb web)
            : base(web)
        {
        }

        protected override MenuPrincipal GetDomainFromSPListItem(SPListItem item)
        {
            MenuPrincipal dominio = new MenuPrincipal();
            dominio.ID = item.ID;
            dominio.Title = item.Title;
            dominio.URL = (string)item[MenuPrincipal.FieldNameURL];
            dominio.Secao = (string)item[MenuPrincipal.FieldNameSecao];
            if (item[MenuPrincipal.FieldNameParentLookup] != null)
                dominio.ParentLookup = new LookupDomain<MenuPrincipal>(Web, new SPFieldLookupValue(item[MenuPrincipal.FieldNameParentLookup].ToString()));
            dominio.Destino = DestinoEnum.GetEnum((string)item[MenuPrincipal.FieldNameDestino]);
            dominio.Ordem = Convert.ToInt32(item[MenuPrincipal.FieldNameOrdem]);
            dominio.ClassedeEstiloCSS = (string)item[MenuPrincipal.FieldNameClassedeEstiloCSS];
            
            return dominio;
        }

        protected override void SetItemFromDomain(SPListItem item, MenuPrincipal dominio)
        {
            item[MenuPrincipal.FieldNameTitle] = dominio.Title;
            item[MenuPrincipal.FieldNameURL] = dominio.URL;
            item[MenuPrincipal.FieldNameSecao] = dominio.Secao;
            item[MenuPrincipal.FieldNameParentLookup] = dominio.ParentLookup.Value.ToLookup();
            item[MenuPrincipal.FieldNameDestino] = dominio.Destino.GetDescription();
            item[MenuPrincipal.FieldNameOrdem] = dominio.Ordem;
            item[MenuPrincipal.FieldNameClassedeEstiloCSS] = dominio.ClassedeEstiloCSS;
        }
    }
}

