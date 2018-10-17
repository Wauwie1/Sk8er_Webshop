using System.Data;
using System.Data.SqlClient;

namespace Sk8er_Webshop.Data
{
    public class DatabaseConnector
    {
        private string connectionString { get; }
        

        public DatabaseConnector(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public string GetSingleString(string query)
        {
            SqlConnection con = new SqlConnection(connectionString);
            //Returns the first string from a query
            con.Close();
            con.Open();
            SqlCommand command = new SqlCommand(query, con);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    string returnString = reader.GetString(0);
                    con.Close();

                    return returnString;

                }
            }

            con.Close();
            return "";
        }

        public DataTable GetDataTable(string query)
        {
            DataTable dataTable = new DataTable();
            SqlConnection con = new SqlConnection(connectionString);
            //Returns a DataTable
            con.Open();
            

            SqlCommand command = new SqlCommand(query, con);


            // Creates data adapter
            SqlDataAdapter adapter = new SqlDataAdapter(command);


            adapter.Fill(dataTable);
            con.Close();
            adapter.Dispose();

            return dataTable;

        }
    }
}