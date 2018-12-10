using System.Collections.Generic;
using Sk8er_Webshop.Models;

namespace Sk8er_Webshop.Data
{
    public interface IPanelContext
    {
        List<UserOrder> GetAllOrders();
    }
}