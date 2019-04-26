using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace DG.Framework.Strategy
{
    public static class ExceptionManager
    {
        public static SPWeb Web { get { return SPContext.Current.Site.RootWeb.Elevate(); } }

        public static Error Log(Exception exception)
        {
            Error error = new Error();
            Guid correlationId = Guid.NewGuid();

            try
            {
                error.Title = exception.Message.Length > 255 ? exception.Message.Substring(0, 255) : exception.Message;
                error.StackTrace = exception.StackTrace;
                error.Date = DateTime.Now;
                error.Method = exception.TargetSite.Name;
                error.RootExceptionStackTrace = exception.GetBaseException().StackTrace;
                error.CorrelationID = correlationId.ToString();
                error.User = SPContext.Current.Web.CurrentUser;

                new ErrorAdapter(Web).Add(error);
            }
            catch (Exception ex)
            {
                try
                {
                    SPSecurity.RunWithElevatedPrivileges(delegate()
                    {
                        EventLog.WriteEntry(
                            string.Format("Falha ao gravar log de erro na lista. \"{0}\"", ex.Message),
                            string.Format("Exceção primária: \"{0}\"\r\nStacktrace: {1}", exception.Message, exception.StackTrace),
                            EventLogEntryType.Error
                            );
                    });
                }
                catch { }

                error = null;
            }

            return error;
        }

    }
}

