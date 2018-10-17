using System;
using System.Data;
using Sk8er_Webshop.Models;

namespace Sk8er_Webshop.Data
{
    public static class ProductData
    {
        private static string connectionString = @"Data Source=sk8erwebshopdbserver.database.windows.net;Initial Catalog=Sk8erWebshop_database;User ID=TheAnswer42;Password=XTqwj]Q^`""NPh6*~s4t#PRE@t'7w~jy[.9#S>XrsP[*+JT,F(e3>&uP?syDBxE/*e]WE'^c&TDPwW^r2J""H<?tzQV6v`'2h]CK%b?(44C4aX8&`+Yx?QCA5XGpRX:{t;Connect Timeout=60;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public static Product GetProductById(int id)
        {
            string query = string.Format("EXEC GetProductById @Id = {0};", id);


            DatabaseConnector dbConnector = new DatabaseConnector(connectionString);
            DataTable dataTable = dbConnector.GetDataTable(query);

            Product productReturn = new Product();

            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];
                
           
                string name = row["Name"].ToString();
                string collection = row["Collection"].ToString();
                string description = row["Description"].ToString();
                int ID = (int)row["ProductKey"];
                string imgURL = row["ImgURL"].ToString();
                decimal price = (decimal)row["Price"];
                string productType = row["ProductType"].ToString();

                Product temp = new Product()
                {
                    Name = name,
                    Collection = collection,
                    Description = description,
                    Id = ID,
                    ImgURL = imgURL,
                    Price = price,
                    ProductType = productType,

                };

                productReturn = temp;
            }
            else
            {
                productReturn = null;
            }

            return productReturn;
        }
    }
}