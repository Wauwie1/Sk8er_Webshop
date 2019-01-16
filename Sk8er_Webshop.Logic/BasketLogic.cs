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
        private readonly ProductRepository _repository;

        public BasketLogic(IProductContext<Product> context)
        {
            _repository = new ProductRepository(context);
        }
        public List<BasketItem> JsontoBasketItems(string jsonString)
        {
            if (jsonString != null)
            {
                try
                {
                    List<BasketItem> items = JsonConvert.DeserializeObject<List<BasketItem>>(jsonString);

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
                item.Product = _repository.GetById(item.Id);
            }
        }

       

        public void PlaceOrder(Order order)
        {
            order.TotalPrice = CalculateTotalPrice(order);
            _repository.PlaceOrder(order);
        }

        private decimal CalculateTotalPrice(Order order)
        {
            decimal totalPrice = 0.0m;
            List<BasketItem> basketItems = JsontoBasketItems(order.ProductsJson);
            foreach (var basketItem in basketItems)
            {
                totalPrice += basketItem.Product.Price * basketItem.Amount;
            }

            return totalPrice;
        }
    }
}