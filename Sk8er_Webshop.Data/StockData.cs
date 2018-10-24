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

        private static Stock CreateStockInstance(DataRow row)
        {
            int ID = (int)row["StockKey"];
            int productKey = (int)row["ProductKey"];
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