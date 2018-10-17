using System.Data;
using System.Data.SqlClient;

namespace Sk8er_Webshop.Data
{
    public static class DatabaseConnector
    {
        private static string connectionString = @"Data Source=sk8erwebshopdbserver.database.windows.net;Initial Catalog=Sk8erWebshop_database;User ID=TheAnswer42;Password=XTqwj]Q^`""NPh6*~s4t#PRE@t'7w~jy[.9#S>XrsP[*+JT,F(e3>&uP?syDBxE/*e]WE'^c&TDPwW^r2J""H<?tzQV6v`'2h]CK%b?(44C4aX8&`+Yx?QCA5XGpRX:{t;Connect Timeout=60;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static string GetSingleString(string query)
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

        public static DataTable GetDataTable(string query)
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