using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Sk8er_Webshop.Models;
using Sk8er_Webshop.Data;

namespace Sk8er_Webshop.Data
{
    public static class ProductData
    {
        
        public static Product GetProductById(int id)
        {
            string query = string.Format("EXEC GetProductById @Id = {0};", id);

            DataTable dataTable = DatabaseConnector.GetDataTable(query);

            Product productReturn;

            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];

                Product product = CreateProductInstance(row);
                productReturn = product;
            }
            else
            {
                productReturn = null;
            }

            return productReturn;
        }

        public static List<Product> GetAllProducts(int page)
        {
            string query = string.Format("EXEC GetAllProductsPage @Page = {0}", page);
            DataTable dataTable = DatabaseConnector.GetDataTable(query);

            List<Product> productList = new List<Product>();

            foreach (DataRow row in dataTable.Rows)
            {

                Product product = CreateProductInstance(row);
                productList.Add(product);
            }

            return productList;
        }

        public static List<Product> GetSearchedProducts(string search, int page)
        {
            string query = string.Format("EXEC GetSearchedProductsPage @Search = {0}, @Page = {1}", search, page);
            DataTable dataTable = DatabaseConnector.GetDataTable(query);

            List<Product> productList = new List<Product>();
            foreach (DataRow row in dataTable.Rows)
            {
                Product product = CreateProductInstance(row);
                productList.Add(product);
            }

            return productList;

        }

        private static Product CreateProductInstance(DataRow row)
        {
            string name = row["Name"].ToString();
            string collection = row["Collection"].ToString();
            string description = row["Description"].ToString();
            int ID = (int)row["ProductKey"];
            string imgURL = row["ImgURL"].ToString();
            decimal price = (decimal)row["Price"];
            string productType = row["ProductType"].ToString();

            Stock stock = StockData.GetStockByProductId(ID);

            Product product = new Product()
            {
                Name = name,
                Collection = collection,
                Description = description,
                Id = ID,
                ImgURL = imgURL,
                Price = price,
                ProductType = productType,
                Stock = stock

            };

            return product;
        }
    }
}