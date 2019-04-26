using DG.Framework.Data.Contract;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DG.Framework.Data.Repository
{
    //public abstract class SQLRepository <T> : IRepository<T>
    //    where T : ListDomain<T>
    //{
        //public string ConnectionString { get; set; }

        //private static string tableName = null;

        //public static string TableName
        //{
        //    get
        //    {
        //        if (tableName == null)
        //        {
        //            InternalNameAttribute attrNomeInterno = ((InternalNameAttribute)typeof(T).GetCustomAttributes(typeof(InternalNameAttribute), false).FirstOrDefault());

        //            if (attrNomeInterno != null)
        //                tableName = attrNomeInterno.InternalName;
        //            else
        //                tableName = typeof(T).Name;
        //        }

        //        return tableName;
        //    }
        //}

        //private SqlConnection _sqlconnection;

        //public SqlConnection SQLConnection
        //{
        //    get
        //    {
        //        if (_sqlconnection == null && !string.IsNullOrWhiteSpace(ConnectionString))
        //            _sqlconnection = new SqlConnection(ConnectionString);

        //        return _sqlconnection;
        //    }
        //    set { _sqlconnection = value; }
        //}


        ///// <summary>
        ///// Atualiza/Modifica um domínio se ele existe ou insere um novo se não existir (chave de seleção é ID).
        ///// </summary>
        ///// <param name="domain">Domínio que será modificado ou criado.</param>
        ///// <returns>Retorna o item modificado após a inclusão. Utilizado em casos onde o id muda após a inserção de um novo domínio que é gerado um novo ID.</returns>
        //public void AddOrUpdate(T domain)
        //{
        //    try
        //    {
        //        if (domain.ID > 0)
        //        {
        //            this.GetItemByID(domain.ID);
        //            this.Update(domain);
        //        }
        //        else
        //            this.Add(domain);
        //    }
        //    catch
        //    {
        //        this.Add(domain);
        //    }
        //}

        ///// <summary>
        ///// Insere um novo domínio na lista.
        ///// </summary>
        ///// <param name="domain">Domínio que será inserido.</param>
        ///// <returns>Retorna o domínio com a geração do novo ID e possíveis modificações do Sharepoint.</returns>
        //public void Add(T domain)
        //{
        //    SPListItem item = List.Items.Add();

        //    if (string.IsNullOrEmpty(domain.Title))
        //        domain.Title = typeof(T).Name;

        //    this.SetItemProperties(item, domain);

        //    Web.AllowUnsafeUpdates = true;
        //    item.Update();

        //    domain.ID = item.ID;
        //    //return this.GetByID(item.ID);
        //}

        ///// <summary>
        ///// Modifica um domínio existente na lista (chave de seleção é ID)
        ///// </summary>
        ///// <param name="domain">Domínio com o mesmo ID do item que será modificado.</param>
        ///// <returns>Retorna o item alterado, caso seja necessário.</returns>
        //public void Update(T domain)
        //{
        //    SPListItem item = this.GetItemByID(domain.ID);

        //    this.SetItemProperties(item, domain);

        //    Web.AllowUnsafeUpdates = true;
        //    item.Update();

        //    //return this.GetByID(item.ID);
        //}

        ///// <summary>
        ///// Deleta um domínio de uma lista
        ///// </summary>
        ///// <param name="domain">Dominio com o mesmo ID do item que será deletado.</param>
        //public void Delete(T domain)
        //{
        //    Delete(domain.ID);
        //}

        ///// <summary>
        ///// Deleta um domínio de uma lista pelo ID
        ///// </summary>
        ///// <param name="id">ID do item a ser deletado</param>
        //public void Delete(int id)
        //{
        //    this.List.ParentWeb.AllowUnsafeUpdates = true;

        //    try
        //    {
        //        this.GetItemByID(id).Delete();
        //    }
        //    catch
        //    {
        //        throw new Exception("O Item com o id especificado não existe ou este usuáro não possui permissões para deleta-lo.");
        //    }
        //}

        ///// <summary>
        ///// Obtém um domínio a partir do ID
        ///// </summary>
        ///// <param name="id">ID do domínio a ser retornado</param>
        ///// <returns></returns>
        //public T GetByID(int id)
        //{
        //    SPListItem item;

        //    try
        //    {
        //        item = this.GetItemByID(id);
        //    }
        //    catch
        //    {
        //        return default(T);
        //    }

        //    return this.GetDomain(item);
        //}

        ///// <summary>
        ///// Obtém todos os domínios da lista
        ///// </summary>
        ///// <returns></returns>
        //public IEnumerable<T> GetAll()
        //{
        //    SPListItemCollection itens = this.GetItemCollection(string.Empty);

        //    if (itens != null)
        //        foreach (SPListItem item in itens)
        //            yield return this.GetDomain(item);
        //}

        //private SPListItem GetItemByID(int id)
        //{
        //    try
        //    {
        //        return List.GetItemById(id);
        //    }
        //    catch
        //    {
        //        throw new Exception(String.Format("O(a) '{0}' com id '{1}' não pode ser encontrado(a) ou não há permissões suficientes para acessá-lo através do usuário {2}.",
        //            ListInternalName, id, Web.CurrentUser.LoginName));
        //    }
        //}

        ///// <summary>
        ///// Obtém todos os itens que satisfaçam uma condição de CAML query
        ///// </summary>
        ///// <param name="whereText">Texto da condição WHERE da CAML query</param>
        ///// <returns></returns>
        //public IEnumerable<T> GetByQuery(string whereText)
        //{
        //    return this.GetDomains(this.GetItemCollection(whereText));
        //}

        ///// <summary>
        ///// Obtém todos os itens que satisfaçam uma condição de CAML query
        ///// </summary>
        ///// <param name="query">Objeto CAML query contendo a condição de filtro.</param>
        ///// <returns></returns>
        //public IEnumerable<T> GetByQuery(SPQuery query)
        //{
        //    return this.GetDomains(this.GetItemCollection(query));
        //}

        //private SPListItemCollection GetItemCollection(string whereText)
        //{
        //    if (string.IsNullOrEmpty(whereText))
        //        return List.Items;
        //    else
        //    {
        //        SPQuery spQuery = new SPQuery();
        //        spQuery.Query = whereText;

        //        return GetItemCollection(spQuery);
        //    }
        //}

        //private SPListItemCollection GetItemCollection(SPQuery query)
        //{
        //    return List.GetItems(query);
        //}

        //private IEnumerable<T> GetDomains(SPListItemCollection itens)
        //{
        //    foreach (SPListItem item in itens)
        //    {
        //        T dominio = this.GetDomain(item);

        //        if (dominio != null)
        //            yield return dominio;
        //    }
        //}

        ///// <summary>
        ///// Especifica como é a conversão de um SPListItem para um domínio T para ser usado no código.
        ///// </summary>
        ///// <param name="item">Objeto SPListItem que está vindo da lista.</param>
        ///// <returns>Domínio T obtido a partir do SPListItem.</returns>
        //protected abstract T GetDomain(DataRow itemRow);

        ///// <summary>
        ///// Especifica como é a conversão de um domínio T para um SPListItem a ser gravado na lista.
        ///// </summary>
        ///// <param name="item">SPListItem que será gravado na lista.</param>
        ///// <param name="dominio">Domínio T a ser convertido em um SPListItem.</param>
        //protected abstract void SetSQLItemRow(Dictionary<string, object> item, T dominio);

    //}
}
