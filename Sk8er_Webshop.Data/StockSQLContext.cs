using System;
using System.Collections.Generic;
using System.Data;
using Sk8er_Webshop.Models;

namespace Sk8er_Webshop.Data
{
    public class StockSQLContext : IStockContext<Stock>
    {
        public IEnumerable<Stock> GetAllStock()
        {
            var storedProcedure = "EXEC GetAllStock";

            var dataTable = DatabaseConnector.GetDataTable(storedProcedure);

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
            var storedProcedure = string.Format("EXEC GetStockByProductId @Id = {0};", id);

            var dataTable = DatabaseConnector.GetDataTable(storedProcedure);

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