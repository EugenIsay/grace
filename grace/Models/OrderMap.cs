using System.Collections.Generic;
using System.Linq;

namespace grace.Models;

public class OrderMap
{
    public Order Order { get; set; }

    public List<Orderservice> Services
    {
        get => Actions.orderServices.Where(s => s.Orderid == Order.Id).ToList();
    }

}