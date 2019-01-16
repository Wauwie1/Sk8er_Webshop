using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Sk8er_Webshop.Data
{
    public   class DatabaseConnector
    {

        private string ConnectionString { get; set; }
        public IConfiguration Configuration { get; private set; }

        public   DatabaseConnector(IConfiguration configuration)
        {
            Configuration = configuration;
            ConnectionString = configuration.GetConnectionString("Sk8erDB");
        }
        public   DataTable GetDataTable(SqlCommand storedProcedure)
        {
            var dataTable = new DataTable();
            var con = new SqlConnection(ConnectionString);

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
            var con = new SqlConnection(ConnectionString);

            con.Open();


            SqlCommand command = storedProcedure;
            command.Connection = con;

            command.ExecuteNonQuery();

            con.Close();
        }

        public int ExecCommandId(SqlCommand command)
        {
            var con = new SqlConnection(ConnectionString);

            con.Open();
            command.Connection = con;
            int id = (int)command.ExecuteScalar();
            con.Close();

            return id;
        }
    }
}