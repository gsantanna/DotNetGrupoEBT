using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DG.Framework.Data.External
{
    public class SQLConnector
    {
        public static DataTable GetDataTable(string sqlCommand, string connectionString)
        {
            DataTable table = new DataTable();
            using (SqlCommand cmd = new SqlCommand(
                sqlCommand, new SqlConnection(connectionString)))
            {
                cmd.Connection.Open();
                table.Load(cmd.ExecuteReader());
            }
            return table;
        }
    }
}
