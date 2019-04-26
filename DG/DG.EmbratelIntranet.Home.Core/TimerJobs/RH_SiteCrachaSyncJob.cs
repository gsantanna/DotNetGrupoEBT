using DG.Framework.Data.External;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace DG.EmbratelIntranet.Home.Core.TimerJobs
{
    public class RH_SiteCrachaSyncJob : SPJobDefinition
    {
        public const string JobName = "RH_SiteCracha Sync Job";

        public RH_SiteCrachaSyncJob() : base() {
            loga("Construtor.. ");
        }
        public RH_SiteCrachaSyncJob(string jobName, SPService service)
            : base(jobName, service, null, SPJobLockType.None)
        {
            this.Title = JobName;
        }

        public RH_SiteCrachaSyncJob(string jobName, SPWebApplication webapp)
            : base(jobName, webapp, null, SPJobLockType.ContentDatabase)
        {
            this.Title = JobName;
        }

        public override void Execute(Guid targetInstanceId)
        {
            loga("Iniciando job");

            SPWebApplication webApp = this.Parent as SPWebApplication;
            Configuration config = WebConfigurationManager.OpenWebConfiguration("/", webApp.Name);

            loga("Crregado config e webapp");
            DataTable dt = SQLConnector.GetDataTable(config.AppSettings.Settings["QueryPessoas"].Value, config.AppSettings.Settings["ConnectionStrPessoas"].Value);

            loga("dt carregado " + dt.Rows.Count.ToString());


            SPSite site = webApp.Sites[0];
            SPWeb web = site.RootWeb;

            loga("iniciando erase");
            SPList listPessoas = EraseListPessoas(web);

            loga("fim erase " + listPessoas.Items.Count );


            loga("inicio update");
            listPessoas = UpdateListPessoas(dt, web);

            loga("inicio fill");
            FillListPessoas(dt, listPessoas);

            web.Dispose();
            site.Dispose();
            dt.Dispose();
        }

        private static void FillListPessoas(DataTable dt, SPList listPessoas)
        {
            loga(" Filling ");
            foreach (DataRow pessoaCracha in dt.Rows)
            {
                bool save = true;

                SPListItem newPessoa = listPessoas.Items.Add();

                newPessoa["Title"] = (string)pessoaCracha["NOME_EMPREGADO"];

                foreach (DataColumn cracha in dt.Columns)
                {
                    string columnName = cracha.ColumnName;
                    object value = pessoaCracha[cracha];

                    if (cracha.ColumnName.ToUpper() == "ID")
                        columnName = "SQL_ID";

                    else if (cracha.ColumnName.ToUpper() == "USERNAME")
                    {
                        columnName = "USERNAME";

                        try
                        {
                            value = listPessoas.ParentWeb.EnsureUser("EMBRATEL\\" + (string)value);
                        }
                        catch
                        {
                            save = false;
                            break;
                        }

                        try
                        {
                            newPessoa[listPessoas.Fields.GetFieldByInternalName("Conta").Id] = value;
                        }
                        catch { }
                    }

                    if (value == DBNull.Value)
                        value = null;

                    try
                    {
                        newPessoa[listPessoas.Fields.GetFieldByInternalName(columnName).Id] = value;
                    }
                    catch { }
                }
                loga("Salvando pessoa " + newPessoa.Title);
                if (save)
                    newPessoa.Update();
            }
        }

        private static SPList EraseListPessoas(SPWeb web)
        {
            SPList listPessoas = null;
            web.AllowUnsafeUpdates = true;
            listPessoas = web.Lists["Pessoas"];
            DeleteAllItems(listPessoas);
            listPessoas.Update();
            web.Update();
            return listPessoas;
        }

        private static SPList UpdateListPessoas(DataTable dt, SPWeb web)
        {
            SPList listPessoas;

            if ((listPessoas = web.Lists.TryGetList("Pessoas")) == null)
            {
                Guid newlistGuid = web.Lists.Add("Pessoas", "", SPListTemplateType.GenericList);

                listPessoas = web.Lists[newlistGuid];
            }

            //listPessoas.Fields.Add("sql_id", SPFieldType.Number, true);
            //listPessoas.Fields.Add("username", SPFieldType.User, true);

            foreach (DataColumn cracha in dt.Columns)
            {
                try
                {
                    if (cracha.ColumnName.ToUpper() == "ID" || listPessoas.Fields.ContainsField(cracha.ColumnName))
                        continue;

                    SPFieldType fieldtype;

                    if (cracha.DataType == typeof(int)
                        || cracha.DataType == typeof(double)
                        || cracha.DataType == typeof(float)
                        || cracha.DataType == typeof(decimal))
                        fieldtype = SPFieldType.Number;
                    else if (cracha.DataType == typeof(DateTime))
                        fieldtype = SPFieldType.DateTime;
                    else
                        fieldtype = SPFieldType.Text;

                    listPessoas.Fields.Add(cracha.ColumnName, fieldtype, false);
                }
                catch (Exception ex)
                {

                }
            }

            return listPessoas;
        }






        public static void DeleteAllItems(SPList lista)
        {
            StringBuilder deletebuilder = BatchCommand(lista);
            lista.ParentWeb.ProcessBatchData(deletebuilder.ToString());


        }

        private static StringBuilder BatchCommand(SPList spList)
        {
            StringBuilder deletebuilder = new StringBuilder();
            deletebuilder.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?><Batch>");
            string command = "<Method><SetList Scope=\"Request\">" + spList.ID +
                "</SetList><SetVar Name=\"ID\">{0}</SetVar><SetVar Name=\"Cmd\">Delete</SetVar></Method>";

            foreach (SPListItem item in spList.Items)
            {
                deletebuilder.Append(string.Format(command, item.ID.ToString()));
            }
            deletebuilder.Append("</Batch>");
            return deletebuilder;
        }


        public static  void loga(string s)
        {
            File.AppendAllText( "C:\\temp\\log_job.txt" ,
                string.Format("{0:dd/MM - HH:mm:ss} -- {1} \n" , DateTime.Now, s)
                ); 
        
        }




    }
}
