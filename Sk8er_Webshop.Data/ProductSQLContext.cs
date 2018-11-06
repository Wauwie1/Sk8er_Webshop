using System;
using System.Collections.Generic;
using System.Data;
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

        public IEnumerable<Product> GetAll(int page)
        {
            var storedProcedure = string.Format("EXEC GetAllProductsPage @Page = {0}", page);
            return GetProductList(storedProcedure);
        }

        public IEnumerable<Product> GetSearchedProducts(string search, int page)
        {
            var storedProcedure =
                string.Format("EXEC GetSearchedProductsPage @Search = {0}, @Page = {1}", search, page);
            return GetProductList(storedProcedure);
        }

        public IEnumerable<Product> GetCategoryProducts(string category, int page)
        {
            var storedProcedure =
                string.Format("EXEC GetProductsCategory @ProductType = {0}, @Page = {1}", category, page);
            return GetProductList(storedProcedure);
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

            //todo: Make stock data use repo pattern
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

        private List<Product> GetProductList(string storedProcedure)
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
