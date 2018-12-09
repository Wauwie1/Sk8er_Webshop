using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Sk8er_Webshop.Models;

namespace Sk8er_Webshop.Data
{
    public class StockSQLContext : InitDBConnector, IStockContext<Stock>
    {
        public StockSQLContext(IConfiguration configuration) : base(configuration)
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
            var ID = (int)row["StockKey"];
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

            var XS = new Size(EnumSizes.XS, (int)row["XS"]);
            var S = new Size(EnumSizes.S, (int)row["S"]);
            var M = new Size(EnumSizes.M, (int)row["M"]);
            var L = new Size(EnumSizes.L, (int)row["L"]);
            var XL = new Size(EnumSizes.XL, (int)row["XL"]);
            var XXL = new Size(EnumSizes.XXL, (int)row["XXL"]);
            var Other = new Size(EnumSizes.Other, (int)row["Other"]);

            var stock = new Stock
            {
                Id = ID,
                ProductKey = productKey,
                ProductName = productName,
                Sizes = new List<Size>()
            };
            stock.Sizes.Add(XS);
            stock.Sizes.Add(S);
            stock.Sizes.Add(M);
            stock.Sizes.Add(L);
            stock.Sizes.Add(XL);
            stock.Sizes.Add(XXL);
            stock.Sizes.Add(Other);

            return stock;
        }


    }
}