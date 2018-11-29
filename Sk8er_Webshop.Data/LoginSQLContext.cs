using System.Data;
using System.Data.SqlClient;
using Sk8er_Webshop.Models;

namespace Sk8er_Webshop.Data
{
    public class LoginSQLContext : ILoginContext
    {
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








        public User CreateUserInstance(DataRow row)
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