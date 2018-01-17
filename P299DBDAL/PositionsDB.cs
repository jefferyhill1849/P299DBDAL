using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P299DBDAL;
using System.Data.SqlClient;
using P299BLL;

namespace P299DBDAL
{
    class PositionsDB
    {
        private List<Positions> positionsList;

        public List<Positions> GetPositions()
        {
            List<Positions> positionsList = new List<Positions>();
            SqlConnection connection = P299DB.GetConnection();
            string selectStatement =
                "SELECT JobID, PositionName, PositionType, PositionDescription, Notes, CompanyID " +
                "FROM Job_ID_Table " +
                "ORDER BY PositionName";
            SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = selectCommand.ExecuteReader();
                while (reader.Read())
                {
                    Positions position = new Positions();
                    position.JobName = reader["PositionName"].ToString();
                    position.JobType = reader["PositionType"].ToString();
                    position.Description = reader["PositionDescription"].ToString();
                    position.Notes = reader["Notes"].ToString();
                    positionsList.Add(position);
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
            return positionsList;
        }
    }
}
