using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Sk8er_Webshop.Models;

namespace Sk8er_Webshop.Data
{
    public class LoginSqlContext : InitDbConnector, ILoginContext
    {
        public LoginSqlContext(IConfiguration configuration) : base(configuration)
        {
        }
        public User Login(string username, string password)
        {
            SqlCommand command = new SqlCommand("GetUser");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@Username", username));
            command.Parameters.Add(new SqlParameter("@Password", password));

            var dataTable = DatabaseConnector.GetDataTable(command);
            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];
                return CreateUserInstance(row);
            }
            else
            {
                return null;
            }

           
        }

        public Adress GetAdress(int id)
        {
            SqlCommand command = new SqlCommand("GetAdress");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@AdressKey", id));

            var dataTable = DatabaseConnector.GetDataTable(command);

            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];
                return CreateAdressInstance(row);
            }
            else
            {
                return null;
            }
        }

        public int SetAdress(string adress, int number, string city, string country, string zipcode)
        {
            SqlCommand command = new SqlCommand("SetAdress");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@StreetName", adress));
            command.Parameters.Add(new SqlParameter("@HouseNumber", number));
            command.Parameters.Add(new SqlParameter("@ZipCode", zipcode));
            command.Parameters.Add(new SqlParameter("@Country", country));
            command.Parameters.Add(new SqlParameter("@City", city));

            int id = DatabaseConnector.ExecCommandId(command);
            return id;
        }

        public bool UserNameAlreadyExists(string username)
        {
            SqlCommand command = new SqlCommand("UsernameExists");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@Username", username));
            return DatabaseConnector.ExecCommandBool(command);
        }

        public void RegisterUser(string username, string email, string password)
        {

            SqlCommand command = new SqlCommand("RegisterUser");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@Username", username));
            command.Parameters.Add(new SqlParameter("@Password", password));
            command.Parameters.Add(new SqlParameter("@Email", email));
            DatabaseConnector.ExecCommand(command);
        }

        private Adress CreateAdressInstance(DataRow row)
        {
            int id = (int)row["AdressKey"];
            string streetName = row["StreetName"].ToString();
            int houseNumber = (int) row["HouseNumber"];
            string houseAddition = row["HouseAddition"].ToString();
            string zipcode = row["Zipcode"].ToString();
            string country = row["Country"].ToString();

            Adress adress = new Adress()
            {
                Id = id,
                StreetName = streetName,
                HouseNumber = houseNumber,
                HouseAddition = houseAddition,
                Zipcode = zipcode,
                Country = country
            };

            return adress;
        }


        private User CreateUserInstance(DataRow row)
        {
            int id = (int)row["UserKey"];
            int adressId = (int)row["AdressKey"];
            string username = row["Username"].ToString();
            string email = row["email"].ToString();
            int authLevel = (int)row["AuthLevel"];

            User user = new User()
            {
                Id = id,
                AdressId = adressId,
                Username = username,
                Email = email,
                AuthLevel = authLevel
            };

            return user;
        }


    }
}