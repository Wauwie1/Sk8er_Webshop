using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Sk8er_Webshop.Data
{
    public   class DatabaseConnector
    {

        private string connectionString { get; set; }
        public IConfiguration _configuration { get; private set; }

        public   DatabaseConnector(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = configuration.GetConnectionString("Sk8erDB");
        }
        public   DataTable GetDataTable(SqlCommand storedProcedure)
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

        public   void ExecCommand(SqlCommand storedProcedure)
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