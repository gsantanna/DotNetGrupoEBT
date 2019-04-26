using DG.Framework.Data.Contract;
using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DG.Framework.Data.Abstraction
{
    /// <summary>
    /// Classe abstrata que define todas as operações de CRUD em listas do Sharepoint para implementação de repositórios.
    /// Você precisa implementar os métodos "public T GetDomain(SPlistItem item)" e "public void SetFields(SPListItem item, T dominio)".
    /// </summary>
    /// <typeparam name="T">Domínio que implementa IListDomain&lt;domínio&gt;</typeparam>
    public abstract class SPRepository<T> : IRepository<T>
        where T : IDomain<T>
    {
        protected SPView CurrentView { get; private set; }
        private SPList list;
        private static string listInternalName = null;

        /// <summary>
        /// Objeto SPWeb que o repositório atual está utilizando para realizar as operações.
        /// </summary>
        public SPWeb Web { get; private set; }

        /// <summary>
        /// InternalName da lista que o repositório está utilizando para as operações.
        /// </summary>
        public static string ListInternalName
        {
            get
            {
                if (listInternalName == null)
                {
                    InternalNameAttribute attrNomeInterno = ((InternalNameAttribute)typeof(T).GetCustomAttributes(typeof(InternalNameAttribute), false).FirstOrDefault());

                    if (attrNomeInterno != null)
                        listInternalName = attrNomeInterno.InternalName;
                    else
                        listInternalName = typeof(T).Name;
                }

                return listInternalName;
            }
        }

        /// <summary>
        /// A lista que o repositório está utilizando para as operações.
        /// </summary>
        public SPList List
        {
            get
            {
                if (list == null)
                    list = Web.FindListByName(ListInternalName);

                return list;
            }
            set { list = value; }
        }

        /// <summary>
        /// Esta classe abstrata só é instanciada a partir do construtor invocando :base(SPWeb).
        /// </summary>
        /// <param name="web">Objeto SPWeb que este repositório irá utilizar para realizar as operações.</param>
        public SPRepository(SPWeb web)
        {
            this.Web = web;
        }

        /// <summary>
        /// Atualiza/Modifica um domínio se ele existe ou insere um novo se não existir (chave de seleção é ID).
        /// </summary>
        /// <param name="domain">Domínio que será modificado ou criado.</param>
        /// <returns>Retorna o item modificado após a inclusão. Utilizado em casos onde o id muda após a inserção de um novo domínio que é gerado um novo ID.</returns>
        public void AddOrUpdate(T domain)
        {
            try
            {
                if (domain.ID > 0)
                {
                    this.GetItemByID(domain.ID);
                    this.Update(domain);
                }
                else
                    this.Add(domain);
            }
            catch
            {
                this.Add(domain);
            }
        }

        /// <summary>
        /// Insere um novo domínio na lista.
        /// </summary>
        /// <param name="domain">Domínio que será inserido.</param>
        /// <returns>Retorna o domínio com a geração do novo ID e possíveis modificações do Sharepoint.</returns>
        public void Add(T domain)
        {
            SPListItem item = List.Items.Add();

            if (string.IsNullOrEmpty(domain.Title))
                domain.Title = typeof(T).Name;

            this.SetItemProperties(item, domain);

            Web.AllowUnsafeUpdates = true;
            item.Update();

            domain.ID = item.ID;
            //return this.GetByID(item.ID);
        }

        /// <summary>
        /// Modifica um domínio existente na lista (chave de seleção é ID)
        /// </summary>
        /// <param name="domain">Domínio com o mesmo ID do item que será modificado.</param>
        /// <returns>Retorna o item alterado, caso seja necessário.</returns>
        public void Update(T domain)
        {
            SPListItem item = this.GetItemByID(domain.ID);

            this.SetItemProperties(item, domain);

            Web.AllowUnsafeUpdates = true;
            item.Update();

            //return this.GetByID(item.ID);
        }

        /// <summary>
        /// Deleta um domínio de uma lista
        /// </summary>
        /// <param name="domain">Dominio com o mesmo ID do item que será deletado.</param>
        public void Delete(T domain)
        {
            Delete(domain.ID);
        }

        /// <summary>
        /// Deleta um domínio de uma lista pelo ID
        /// </summary>
        /// <param name="id">ID do item a ser deletado</param>
        public void Delete(int id)
        {
            this.List.ParentWeb.AllowUnsafeUpdates = true;

            try
            {
                this.GetItemByID(id).Delete();
            }
            catch
            {
                throw new Exception("O Item com o id especificado não existe ou este usuáro não possui permissões para deleta-lo.");
            }
        }

        /// <summary>
        /// Obtém um domínio a partir do ID
        /// </summary>
        /// <param name="id">ID do domínio a ser retornado</param>
        /// <returns></returns>
        public T GetByID(int id)
        {
            SPListItem item;

            try
            {
                item = this.GetItemByID(id);
            }
            catch
            {
                return default(T);
            }

            return this.GetDomain(item);
        }

        /// <summary>
        /// Obtém todos os domínios da lista
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> GetAll()
        {
            SPListItemCollection itens = this.GetItemCollection(string.Empty);

            if (itens != null)
                foreach (SPListItem item in itens)
                    yield return this.GetDomain(item);
        }

        private SPListItem GetItemByID(int id)
        {
            try
            {
                return List.GetItemById(id);
            }
            catch
            {
                throw new Exception(String.Format("O(a) '{0}' com id '{1}' não pode ser encontrado(a) ou não há permissões suficientes para acessá-lo através do usuário {2}.",
                    ListInternalName, id, Web.CurrentUser.LoginName));
            }
        }

        /// <summary>
        /// Obtém todos os itens que satisfaçam uma condição de CAML query
        /// </summary>
        /// <param name="whereText">Texto da condição WHERE da CAML query</param>
        /// <returns></returns>
        public IEnumerable<T> GetByQuery(string whereText)
        {
            return this.GetDomains(this.GetItemCollection(whereText));
        }

        /// <summary>
        /// Obtém todos os itens que satisfaçam uma condição de CAML query
        /// </summary>
        /// <param name="query">Objeto CAML query contendo a condição de filtro.</param>
        /// <returns></returns>
        public IEnumerable<T> GetByQuery(SPQuery query)
        {
            return this.GetDomains(this.GetItemCollection(query));
        }

        private SPListItemCollection GetItemCollection(string whereText)
        {
            if (string.IsNullOrEmpty(whereText))
                return List.Items;
            else
            {
                SPQuery spQuery = new SPQuery();
                spQuery.Query = whereText;

                return GetItemCollection(spQuery);
            }
        }

        public IEnumerable<T> GetByViewTitle(string viewTitle)
        {
            return GetByViewTitleAndThenQuery(viewTitle, null);
        }

        public IEnumerable<T> GetByViewTitleAndThenQuery(string viewTitle, string whereText)
        {
            if (string.IsNullOrWhiteSpace(viewTitle) 
                || !List.Views.OfType<SPView>().Any(view => view.Title == viewTitle)
                || (CurrentView = List.Views[viewTitle]) == null)
            {
                throw new ArgumentException(string.Format("Não foi possível encontrar a view '{0}' na lista '{1}'. Verifique as configurações da webpart ou alterações recentes.", viewTitle, List.Title), "viewName");

                //return this.GetByQuery(whereText);
            }

            if (string.IsNullOrWhiteSpace(whereText))
                return this.GetDomains(List.GetItems(CurrentView));
            else
            {
                SPQuery spQuery = new SPQuery();
                spQuery.Query = whereText;
                IEnumerable<T> domains = this.GetDomains(List.GetItems(spQuery, CurrentView.ID.ToString("B").ToUpper()));

                CurrentView = null;
                return domains;
            }
        }

        private SPListItemCollection GetItemCollection(SPQuery query)
        {
            return List.GetItems(query);
        }

        private IEnumerable<T> GetDomains(SPListItemCollection itens)
        {
            foreach (SPListItem item in itens)
            {
                T dominio = this.GetDomain(item);

                if (dominio != null)
                    yield return dominio;
            }
        }

        private string GetViewFields()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Especifica como é a conversão de um SPListItem para um domínio T para ser usado no código.
        /// </summary>
        /// <param name="item">Objeto SPListItem que está vindo da lista.</param>
        /// <returns>Domínio T obtido a partir do SPListItem.</returns>
        protected abstract T GetDomain(SPListItem item);

        /// <summary>
        /// Especifica como é a conversão de um domínio T para um SPListItem a ser gravado na lista.
        /// </summary>
        /// <param name="item">SPListItem que será gravado na lista.</param>
        /// <param name="dominio">Domínio T a ser convertido em um SPListItem.</param>
        protected abstract void SetItemProperties(SPListItem item, T dominio);

    }
}

