using DG.Framework.Data.Abstraction;
using Microsoft.SharePoint;
using System;

namespace DG.Framework.Strategy
{
    public class ErrorAdapter : ListRepository<Error>
    {
        public ErrorAdapter(SPWeb web)
            : base(web)
        {
        }

        protected override Error GetDomainFromSPListItem(SPListItem item)
        {
            Error dominio = new Error();
            dominio.ID = item.ID;
            dominio.Title = item.Title;
            dominio.StackTrace = (string)item[Error.FieldNameStackTrace];
            dominio.RootExceptionStackTrace = (string)item[Error.FieldNameRootExceptionStack];
            dominio.CorrelationID = (string)item[Error.FieldNameCorrelationID];
            dominio.Date = (DateTime)item[Error.FieldNameDate];
            dominio.Method = (string)item[Error.FieldNameMethod];
            dominio.User = (SPUser)item[Error.FieldNameUser];
            return dominio;
        }

        protected override void SetItemFromDomain(SPListItem item, Error dominio)
        {
            item[Error.FieldNameTitle] = dominio.Title;
            item[Error.FieldNameStackTrace] = dominio.StackTrace;
            item[Error.FieldNameRootExceptionStack] = dominio.RootExceptionStackTrace;
            item[Error.FieldNameCorrelationID] = dominio.CorrelationID;
            item[Error.FieldNameDate] = dominio.Date;
            item[Error.FieldNameMethod] = dominio.Method;
            item[Error.FieldNameUser] = dominio.User;
        }
    }
}

