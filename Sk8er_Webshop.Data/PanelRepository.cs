using System.Collections.Generic;
using Sk8er_Webshop.Models;

namespace Sk8er_Webshop.Data
{
    public class PanelRepository
    {
        private readonly IPanelContext _context;

        public PanelRepository(IPanelContext context)
        {
            _context = context;
        }

        public List<UserOrder> GetAllOrders()
        {
            return _context.GetAllOrders();
        }

        public List<UserOrdersAmount> GetUserOrdersAmount()
        {
            return _context.GetUserOrdersAmount();
        }

        public int GetTotalOrders()
        {
            return _context.GetTotalOrders();
        }
    }
}