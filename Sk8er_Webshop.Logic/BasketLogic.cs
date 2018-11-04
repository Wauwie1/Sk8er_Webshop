using System;
using System.Collections.Generic;
using System.Text;
using Sk8er_Webshop.Models;
using Newtonsoft.Json;

namespace Sk8er_Webshop.Logic
{
    public static class BasketLogic
    {
        public static List<BasketItem> JSONToBasketItems(string JSONString)
        {
            List<BasketItem> items = JsonConvert.DeserializeObject<List<BasketItem>>(JSONString);
            throw new NotImplementedException();
        }
    }
}