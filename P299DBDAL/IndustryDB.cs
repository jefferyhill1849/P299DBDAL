using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using P299DBDAL;
using P299BLL;

namespace P299DBDAL
{
    class IndustryDB
    {
        private List<Industry> industryList;

        public List<Industry> GetIndustry()
        {
            List<Industry> industryList = new List<Industry>();
            SqlConnection connection = P299DB.GetConnection();
            string selectStatement =
                "SELECT IndustryID, IndustryType, IndustryDescription, Notes " +
                "FROM Industry_Table " +
                "ORDER BY IndustryID";
            SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = selectCommand.ExecuteReader();
                while (reader.Read())
                {
                    Industry industry = new Industry();
                    industry.IndustType = reader["IndustryType"].ToString();
                    industry.IndustDescript = reader["IndustryDescription"].ToString();
                    industry.Notes = reader["Notes"].ToString();
                    industryList.Add(industry);
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
            return industryList;
        }
    }
}
