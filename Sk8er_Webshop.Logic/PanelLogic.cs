using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Sk8er_Webshop.Data;
using Sk8er_Webshop.Models;

namespace Sk8er_Webshop.Logic
{
    public class PanelLogic 
    {
        private readonly PanelRepository repository;
        public PanelLogic(IPanelContext context)
        {
            repository = new PanelRepository(context);

        }

        public List<UserOrder> GetAllOrders()
        {
            var list = repository.GetAllOrders();

            foreach (var order in list)
            {
                if (string.IsNullOrWhiteSpace(order.OrderId))
                {
                    order.OrderId = "This user has no orders yet";
                }
            }

            return list;
        }

        public List<UserOrdersAmount> GetUserOrdersAmount()
        {
            var list = repository.GetUserOrdersAmount();
            return list;
        }
    }
}