using System;
using System.Collections.Generic;
using System.Data;
using Sk8er_Webshop.Models;

namespace Sk8er_Webshop.Data
{
    public static class StockData
    {
        public static Stock GetStockByProductId(int id)
        {
            string query = string.Format("EXEC GetStockByProductId @Id = {0};", id);

            DataTable dataTable = DatabaseConnector.GetDataTable(query);

            Stock stockReturn;

            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];



                Stock stock = CreateStockInstance(row);
                stockReturn = stock;
            }
            else
            {
                stockReturn = null;
            }

            return stockReturn;
        }

        public static List<Stock> GetAllStock()
        {
            string storedProcedure = "EXEC GetAllStock";

            DataTable dataTable = DatabaseConnector.GetDataTable(storedProcedure);

            List<Stock> returnList = new List<Stock>();

            foreach (DataRow row in dataTable.Rows)
            {

                Stock stock = CreateStockInstance(row);
                returnList.Add(stock);
            }

            return returnList;
        }

        private static Stock CreateStockInstance(DataRow row)
        {
            int ID = (int)row["StockKey"];
            int productKey = (int)row["ProductKey"];
            string productName;
            try
            {
                productName = (string) row["Name"];
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                productName = "";
            }

            Size XS = new Size(EnumSizes.XS, (int)row["XS"]);
            Size S = new Size(EnumSizes.S, (int)row["S"]);
            Size M = new Size(EnumSizes.M, (int)row["M"]);
            Size L = new Size(EnumSizes.L, (int)row["L"]);
            Size XL = new Size(EnumSizes.XL, (int)row["XL"]);
            Size XXL = new Size(EnumSizes.XXL, (int)row["XXL"]);
            Size Other = new Size(EnumSizes.Other, (int)row["Other"]);

            Stock stock = new Stock()
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