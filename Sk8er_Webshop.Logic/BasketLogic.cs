﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Sk8er_Webshop.Models;
using Newtonsoft.Json;
using Sk8er_Webshop.Data;

namespace Sk8er_Webshop.Logic
{
    public class BasketLogic
    {
        private ProductRepository repository;

        public BasketLogic()
        {
            repository = new ProductRepository(new ProductSQLContext());
        }
        public List<BasketItem> JSONToBasketItems(string JSONString)
        {
            if (JSONString != null)
            {
                List<BasketItem> items = JsonConvert.DeserializeObject<List<BasketItem>>(JSONString);

                SetProducts(items);
                return items;
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

        public bool ContainsNull(IEnumerable<string> strings)
        {
            
            foreach (var stringItem in strings)
            {
                if (stringItem == null)
                {
                    return true;
                }
            }

            return false;


        }
    }
}