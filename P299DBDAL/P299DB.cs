using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using P299BLL;

namespace P299DBDAL
{
    public class P299DB
    {
        private string connection;

        public string P299StringBuilder
        {
            get
            {
                return connection;
            }

            set
            {
                connection = value;
            }
        }

        public static SqlConnection GetConnection()
        {
            SqlConnectionStringBuilder P299StrBuilder = new SqlConnectionStringBuilder();
            P299StrBuilder.DataSource = "localhost\\SQLExpress2014";
            P299StrBuilder.InitialCatalog = "PRG299DBJeff";
            P299StrBuilder.IntegratedSecurity = true;
            SqlConnection connection = new SqlConnection(P299StrBuilder.ConnectionString);
            return connection;
        }
    }
}
