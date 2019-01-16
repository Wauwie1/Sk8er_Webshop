using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Sk8er_Webshop.Models;
using Microsoft.Extensions.Configuration;

namespace Sk8er_Webshop.Data
{
    public class ProductSqlContext : InitDbConnector, IProductContext<Product>
    {
        public ProductSqlContext(IConfiguration configuration) : base(configuration)
        {
        }

        public Product GetById(int id)
        {
            //Create stored procedure command
            SqlCommand command = new SqlCommand("GetProductById");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@Id", id));

            //Execute stored procedure
            var dataTable = DatabaseConnector.GetDataTable(command);

            //Create instance and return product
            Product productReturn;

            if (dataTable.Rows.Count > 0)
            {
                var row = dataTable.Rows[0];

                var product = CreateProductInstance(row);
                productReturn = product;
            }
            else
            {
                productReturn = null;
            }

            return productReturn;
        }

        public IEnumerable<Product> GetAll(int page)
        {
            //Create stored procedure command
            SqlCommand command = new SqlCommand("GetAllProductsPage");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@Page", page));

            return GetProductList(command);
        }

        public IEnumerable<Product> GetSearchedProducts(string search, int page)
        {
            //Create stored procedure command
            SqlCommand command = new SqlCommand("GetSearchedProductsPage");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@Search", search));
            command.Parameters.Add(new SqlParameter("@Page", page));

            return GetProductList(command);
        }

        public IEnumerable<Product> GetCategoryProducts(string category, int page)
        {
            //Create stored procedure command
            SqlCommand command = new SqlCommand("GetProductsCategory");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@ProductType", category));
            command.Parameters.Add(new SqlParameter("@Page", page));

            return GetProductList(command);
        }

        public bool AddNewProduct(string name, string description, decimal price, string collection, string productType,
            string imgUrl)
        {

            try
            {
                //Create stored procedure command
                SqlCommand command = new SqlCommand("AddNewProduct");
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Name", name));
                command.Parameters.Add(new SqlParameter("@Description", description));
                command.Parameters.Add(new SqlParameter("@Price", price));
                command.Parameters.Add(new SqlParameter("@Colection", collection));
                command.Parameters.Add(new SqlParameter("@ProductType", productType));
                command.Parameters.Add(new SqlParameter("@ImgUrl", imgUrl));
                DatabaseConnector.ExecCommand(command);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Adding new product failed. \n" + ex.Message);
                return false;
            }

        }

        public void PlaceOrder(Order order)
        {
            //Create stored procedure command
            SqlCommand command = new SqlCommand("AddOrder");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@ProductJSON", order.ProductsJson));
            command.Parameters.Add(new SqlParameter("@AdressKey", order.AdressKey));
            command.Parameters.Add(new SqlParameter("@UserKey", order.UserKey));
            command.Parameters.Add(new SqlParameter("@Status", order.Status));
            command.Parameters.Add(new SqlParameter("@TotalPrice", order.TotalPrice));
            command.Parameters.Add(new SqlParameter("@FirstName", order.FirstName));
            command.Parameters.Add(new SqlParameter("@LastName", order.LastName));
            DatabaseConnector.ExecCommand(command);
        }


        private Product CreateProductInstance(DataRow row)
        {
            var name = row["Name"].ToString();
            var collection = row["Collection"].ToString();
            var description = row["Description"].ToString();
            var id = (int)row["ProductKey"];
            var imgUrl = row["ImgURL"].ToString();
            var price = (decimal)row["Price"];
            var productType = row["ProductType"].ToString();


            StockRepository repository = new StockRepository(
                                            new StockSqlContext(DatabaseConnector.Configuration));
            var stock = repository.GetByProductId(id);

            var product = new Product
            {
                Name = name,
                Collection = collection,
                Description = description,
                Id = id,
                ImgUrl = imgUrl,
                Price = price,
                ProductType = productType,
                Stock = stock
            };

            return product;
        }

        private List<Product> GetProductList(SqlCommand storedProcedure)
        {
            var dataTable = DatabaseConnector.GetDataTable(storedProcedure);

            var productList = new List<Product>();

            foreach (DataRow row in dataTable.Rows)
            {
                var product = CreateProductInstance(row);
                productList.Add(product);
            }

            return productList;
        }

    }
}
