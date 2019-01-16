using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Sk8er_Webshop.Models;

namespace Sk8er_Webshop.Data
{
    public class StockSqlContext : InitDbConnector, IStockContext<Stock>
    {
        public StockSqlContext(IConfiguration configuration) : base(configuration)
        {
        }
        public IEnumerable<Stock> GetAllStock()
        {
            //Create stored procedure command
            SqlCommand command = new SqlCommand("GetAllStock");
            command.CommandType = CommandType.StoredProcedure;

            var dataTable = DatabaseConnector.GetDataTable(command);
            var returnList = new List<Stock>();

            foreach (DataRow row in dataTable.Rows)
            {
                var stock = CreateStockInstance(row);
                returnList.Add(stock);
            }

            return returnList;
        }

        public Stock GetByProductId(int id)
        {
            //Create stored procedure command
            SqlCommand command = new SqlCommand("GetStockByProductId");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@Id", id));

            var dataTable = DatabaseConnector.GetDataTable(command);

            Stock stockReturn;

            if (dataTable.Rows.Count > 0)
            {
                var row = dataTable.Rows[0];


                var stock = CreateStockInstance(row);
                stockReturn = stock;
            }
            else
            {
                stockReturn = null;
            }

            return stockReturn;
        }

        private static Stock CreateStockInstance(DataRow row)
        {
            var id = (int)row["StockKey"];
            var productKey = (int)row["ProductKey"];
            string productName;
            try
            {
                productName = (string)row["Name"];
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                productName = "";
            }

            var xs = new Size(EnumSizes.Xs, (int)row["XS"]);
            var s = new Size(EnumSizes.S, (int)row["S"]);
            var m = new Size(EnumSizes.M, (int)row["M"]);
            var l = new Size(EnumSizes.L, (int)row["L"]);
            var xl = new Size(EnumSizes.Xl, (int)row["XL"]);
            var xxl = new Size(EnumSizes.Xxl, (int)row["XXL"]);
            var other = new Size(EnumSizes.Other, (int)row["Other"]);

            var stock = new Stock
            {
                Id = id,
                ProductKey = productKey,
                ProductName = productName,
                Sizes = new List<Size>()
            };
            stock.Sizes.Add(xs);
            stock.Sizes.Add(s);
            stock.Sizes.Add(m);
            stock.Sizes.Add(l);
            stock.Sizes.Add(xl);
            stock.Sizes.Add(xxl);
            stock.Sizes.Add(other);

            return stock;
        }


    }

}