using System.Data;
using System.Data.SqlClient;

namespace Sk8er_Webshop.Data
{
    public static class DatabaseConnector
    {
        private static readonly string connectionString =
            @"Server=tcp:sk8erwebshopdbserver.database.windows.net,1433;Initial Catalog=Sk8erWebshop_database;Persist Security Info=False;User ID=TheAnswer42;Password=XTqwj]Q^`""NPh6*~s4t#PRE@t'7w~jy[.9#S>XrsP[*+JT,F(e3>&uP?syDBxE/*e]WE'^c&TDPwW^r2J""H<?tzQV6v`'2h]CK%b?(44C4aX8&`+Yx?QCA5XGpRX:{t;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public static DataTable GetDataTable(SqlCommand storedProcedure)
        {
            var dataTable = new DataTable();
            var con = new SqlConnection(connectionString);

            con.Open();


            SqlCommand command = storedProcedure;
            command.Connection = con;


            // Creates data adapter
            var adapter = new SqlDataAdapter(command);


            adapter.Fill(dataTable);
            con.Close();
            adapter.Dispose();

            return dataTable;
        }

        public static void ExecCommand(SqlCommand storedProcedure)
        {
            var con = new SqlConnection(connectionString);

            con.Open();


            SqlCommand command = storedProcedure;
            command.Connection = con;

            command.ExecuteNonQuery();

            con.Close();
        }
    }
}