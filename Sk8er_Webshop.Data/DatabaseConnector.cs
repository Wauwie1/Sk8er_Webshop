using System.Data;
using System.Data.SqlClient;

namespace Sk8er_Webshop.Data
{
    public static class DatabaseConnector
    {
        private static readonly string connectionString =
            @"Data Source=sk8erwebshopdbserver.database.windows.net;Initial Catalog=Sk8erWebshop_database;User ID=TheAnswer42;Password=XTqwj]Q^`""NPh6*~s4t#PRE@t'7w~jy[.9#S>XrsP[*+JT,F(e3>&uP?syDBxE/*e]WE'^c&TDPwW^r2J""H<?tzQV6v`'2h]CK%b?(44C4aX8&`+Yx?QCA5XGpRX:{t;Connect Timeout=60;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static DataTable GetDataTable(string query)
        {
            var dataTable = new DataTable();
            var con = new SqlConnection(connectionString);
            //Returns a DataTable
            con.Open();


            var command = new SqlCommand(query, con);


            // Creates data adapter
            var adapter = new SqlDataAdapter(command);


            adapter.Fill(dataTable);
            con.Close();
            adapter.Dispose();

            return dataTable;
        }
    }
}