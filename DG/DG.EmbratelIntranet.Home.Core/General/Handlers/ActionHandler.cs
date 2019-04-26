using DG.Framework.Strategy;
using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace DG.EmbratelIntranet.Home.Core.General.Handlers
{
    public class ActionHandler : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //try
            //{
            string typeName = Page.Request.QueryString["Executable"];

            if (MemoryPersisted.Contains(Page.Request.Url.ToString()))
                return;

            MemoryPersisted.Set(Page.Request.Url.ToString(), true);

            if (string.IsNullOrEmpty(typeName))
                throw new ArgumentNullException("Executable", "O parâmetro 'Executable' não foi especificado.");

            Type type = null;

            try
            {
                type = Type.GetType(typeName);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(string.Format("O tipo de Executable '{0}' não pôde ser encontrado, verifique se é um tipo válido.", typeName), "Executable");
            }

            if (typeof(IExecutable).IsAssignableFrom(type))
            {
                IExecutable executable;

                try
                {
                    executable = Activator.CreateInstance(type) as IExecutable;
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException("Falha ao tentar instanciar o Executable especificado.");
                }

                try
                {
                    executable.Execute(Page, SPContext.Current);
                }
                catch (Exception ex)
                {
                    MemoryPersisted.Remove(Page.Request.Url.ToString());
                    throw ex;
                }
            }
            else
                throw new NotSupportedException("O tipo especificado não implementa 'IExecutable'.");
            //}
            //catch (Exception ex)
            //{
            //    ExceptionManager.Log(ex);
            //}
        }
    }
}
