﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Sk8er_Webshop.Models;

namespace Sk8er_Webshop.Data
{
  public  class ProductSQLContext : IProductContext<Product>
    {
        public IEnumerable<Product> GetAll()
        {
            throw new NotImplementedException();
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
            string ImgUrl)
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
                command.Parameters.Add(new SqlParameter("@ImgUrl", ImgUrl));
                DatabaseConnector.ExecCommand(command);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Adding new product failed. \n" + ex.Message);
                return false;
            }

        }


        private Product CreateProductInstance(DataRow row)
        {
            var name = row["Name"].ToString();
            var collection = row["Collection"].ToString();
            var description = row["Description"].ToString();
            var ID = (int)row["ProductKey"];
            var imgURL = row["ImgURL"].ToString();
            var price = (decimal)row["Price"];
            var productType = row["ProductType"].ToString();

            
            StockRepository repository = new StockRepository(new StockSQLContext());
            var stock = repository.GetByProductId(ID);

            var product = new Product
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
