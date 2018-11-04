using System;
using System.Collections.Generic;
using System.Text;
using Sk8er_Webshop.Models;
using Newtonsoft.Json;
using Sk8er_Webshop.Data;

namespace Sk8er_Webshop.Logic
{
    public static class BasketLogic
    {
        public static List<BasketItem> JSONToBasketItems(string JSONString)
        {
            List<BasketItem> items = JsonConvert.DeserializeObject<List<BasketItem>>(JSONString);

            SetProducts(items);
            return items;
        }

        private static void SetProducts(List<BasketItem> items)
        {
            foreach (var item in items)
            {
                item.Product = ProductData.GetProductById(item.Id);
            }
        }
    }
}