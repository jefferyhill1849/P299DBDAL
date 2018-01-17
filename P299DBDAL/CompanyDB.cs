using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P299DBDAL;
using P299BLL;
using System.Data.SqlClient;


namespace P299DBDAL
{
    class CompanyDB
    {
        private List<Company> compList;

        public List<Company> GetCompDetails()
        {
            List<Company> compList = new List<Company>();
            SqlConnection connection = P299DB.GetConnection();
            string selectStatement =
                "SELECT CompanyID, IndustryID, CompanyName, CompanyStreet, CompanyCity " +
                "CompanyZip, CompanyDescription, CompanyPhone, CompanyFax, WebAddress, Notes " +
                "FROM Company_Table " +
                "Order BY CompanyName";
            SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = selectCommand.ExecuteReader();
                while (reader.Read())
                {
                    Company company = new Company();
                    company.CorpName = reader["CompanyName"].ToString();
                    company.CorpAddress = reader["CompanyStreet"].ToString();
                    company.CorpCity = reader["CompanyCity"].ToString();
                    company.CorpZip = reader["CompanyZip"].ToString();
                    company.CorpPhone = reader["CompanyPhone"].ToString();
                    company.CorpFax = reader["CompanyFax"].ToString();
                    company.WebAddress = reader["WebAddress"].ToString();
                    company.Notes = reader["Notes"].ToString();
                    compList.Add(company);
                }
                reader.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return compList;
        }
    }
}
