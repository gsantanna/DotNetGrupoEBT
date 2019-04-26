using DG.Framework.Data.Adapter;
using DG.Framework.Data.Contract;
using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DG.Framework.Domain
{
    /// <remarks>Lista de dispositivos no sharepoint contendo os dados do dispositivo.</remarks>
    public class Error : ListDomain<Error>
    {
        internal const string FieldNameTitle = "Title";
        internal const string FieldNameMethod = "Method";
        internal const string FieldNameStackTrace = "StackTrace";
        internal const string FieldNameRootExceptionStack = "RootExceptionStackTrace";
        internal const string FieldNameUser = "OriginatorUser";
        internal const string FieldNameDate = "ErrorDate";
        internal const string FieldNameCorrelationID = "CorrelationID";

        public string RootExceptionStackTrace { get; set; }

        public string Method { get; set; }

        public string StackTrace { get; set; }

        public string InnerExceptions { get; set; }

        public SPUser User { get; set; }

        public DateTime Date { get; set; }

        public string CorrelationID { get; set; }

        public override IRepository<Error> Adapt(SPWeb web)
        {
            return new ErrorAdapter(web);
        }
    }
}

