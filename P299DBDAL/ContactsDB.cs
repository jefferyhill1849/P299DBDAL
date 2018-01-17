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
    class ContactsDB
    {
        private List<Contacts> contactList;

        public List<Contacts> GetContactDetails()
        {
            List<Contacts> contactsList = new List<Contacts>();
            SqlConnection connection = P299DB.GetConnection();
            string selectStatement =
                "SELECT ContactID, CompanyID, LastName, FirstName, Contact'sTitle, " +
                "MethodOFContact, ContactPhone, Notes " +
                "FROM Contact_Person_Table " +
                "ORDER BY ContactID";
            SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = selectCommand.ExecuteReader();
                while (reader.Read())
                {
                    Contacts contact = new Contacts();
                    contact.LastName = reader["LastName"].ToString();
                    contact.FirstName = reader["FirstName"].ToString();
                    contact.ContactTitle = reader["Contact'sTitle"].ToString();
                    contact.MethOfContact = reader["MethodOfContact"].ToString();
                    contact.PhoneNum = reader["ContactPhone"].ToString();
                    contact.Notes = reader["Notes"].ToString();
                    contactList.Add(contact);
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
            return contactList;
        }
    }
}
