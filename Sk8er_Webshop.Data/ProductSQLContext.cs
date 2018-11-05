using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Sk8er_Webshop.Models;

namespace Sk8er_Webshop.Data
{
  public  class ProductSQLContext : IProductContext
    {
        public IEnumerable<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public Product GetById(int id)
        {
            var storedProcedure = string.Format("EXEC GetProductById @Id = {0};", id);

            var dataTable = DatabaseConnector.GetDataTable(storedProcedure);

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

        private static Product CreateProductInstance(DataRow row)
        {
            var name = row["Name"].ToString();
            var collection = row["Collection"].ToString();
            var description = row["Description"].ToString();
            var ID = (int)row["ProductKey"];
            var imgURL = row["ImgURL"].ToString();
            var price = (decimal)row["Price"];
            var productType = row["ProductType"].ToString();

            var stock = StockData.GetStockByProductId(ID);

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
    }
}
