﻿using System.Collections.Generic;
using Sk8er_Webshop.Models;

namespace Sk8er_Webshop.ViewModels
{
    public class OrdersAmountViewModel
    {
        public List<UserOrdersAmount> UserOrdersAmount { get; set; }
        public int TotalOrders { get; set; }
    }
}