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
    class InterviewReplyDB
    {
        private List<Interview> replysList;

        public List<Interview> GetPositionsDetails()
        {
            List<Interview> replysList = new List<Interview>();
            SqlConnection connection = P299DB.GetConnection();
            string selectStatement =
                "SELECT InterviewID, CompanyID, ContactID, JobID, InterviewDate, Outcome, Notes " +
                "FROM InterviewReply " +
                "ORDER BY CompanyID";
            SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = selectCommand.ExecuteReader();
                while (reader.Read())
                {
                    Interview reply = new Interview();
                    reply.InterviewDate = (DateTime)reader["InterviewDate"];
                    reply.Outcome = reader["Outcome"].ToString();
                    reply.Notes = reader["Notes"].ToString();
                    replysList.Add(reply);
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
            return replysList;
        }
    }
}
