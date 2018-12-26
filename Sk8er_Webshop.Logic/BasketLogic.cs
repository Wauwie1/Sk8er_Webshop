using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sk8er_Webshop.Models;
using Newtonsoft.Json;
using Sk8er_Webshop.Data;

namespace Sk8er_Webshop.Logic
{
    public class BasketLogic
    {
        private ProductRepository repository;

        public BasketLogic(IProductContext<Product> context)
        {
            repository = new ProductRepository(context);
        }
        public List<BasketItem> JSONTOBasketItems(string JSONString)
        {
            if (JSONString != null)
            {
                try
                {
                    List<BasketItem> items = JsonConvert.DeserializeObject<List<BasketItem>>(JSONString);

                    SetProducts(items);
                    return items;
                }
                catch (JsonReaderException ex)
                {
                    Console.WriteLine("Invalid JSONString", ex.Message);
                    return null;
                }
            }
            else
            {
                return new List<BasketItem>();
            }
        }

        private void SetProducts(List<BasketItem> items)
        {
            foreach (var item in items)
            {
                item.Product = repository.GetById(item.Id);
            }
        }

       

        public void PlaceOrder(Order order)
        {
            order.TotalPrice = calculateTotalPrice(order);
            repository.PlaceOrder(order);
        }

        private decimal calculateTotalPrice(Order order)
        {
            decimal totalPrice = 0.0m;
            List<BasketItem> basketItems = JSONTOBasketItems(order.ProductsJSON);
            foreach (var basketItem in basketItems)
            {
                totalPrice += basketItem.Product.Price * basketItem.Amount;
            }

            return totalPrice;
        }
    }
}