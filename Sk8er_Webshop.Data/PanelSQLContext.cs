using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Sk8er_Webshop.Models;

namespace Sk8er_Webshop.Data
{
    public class PanelSQLContext : InitDBConnector, IPanelContext
    {
        public PanelSQLContext(IConfiguration configuration) : base(configuration)
        {
        }

        public List<UserOrder> GetAllOrders()
        {
            List<UserOrder> list = new List<UserOrder>();
            SqlCommand command = new SqlCommand("GetAllOrders");
            command.CommandType = CommandType.StoredProcedure;
            var dataTable = DatabaseConnector.GetDataTable(command);

            foreach (DataRow row in dataTable.Rows)
            {
                var userOrder = new UserOrder()
                {
                    Username = row["Username"].ToString(),
                    OrderId = row["OrderKey"].ToString()
            };
              
                list.Add(userOrder);
            }

            return list;
        }
    }
}