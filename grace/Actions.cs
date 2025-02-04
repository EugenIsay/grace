using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using grace.Context;
using grace.Models;
using Microsoft.EntityFrameworkCore;

namespace grace;

public static class Actions
{
    
    public static User2Context DBContext { get; set; } = new User2Context();
    public static List<User> Users = DBContext.Users.Where(u => u.Roleid != 4).ToList();
    public static List<OrderMap> orderMaps = DBContext.Orders.Include(o => o.User).Include(o => o.Status).Select(s => new OrderMap{ Order = s }).ToList();
    public static List<Orderservice> orderServices = DBContext.Orderservices.Include(s => s.Service).ToList();
    public static List<User> Clients = DBContext.Users.Where(u => u.Roleid == 4).ToList();
    public static int role = 0;

    public static bool isAdmin { get  => role == 1; }
    public static bool isSenior { get  => role == 2; }
    public static bool isSaler { get  => role == 2 || role == 3; }

    public static bool IsUser(User user)
    {
        user = DBContext.Users.FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);
        if (Users.Contains(user))
        {
            role = user.Roleid;
            return true;
        }
        return false;
    }

    public static void UpdateClient()
    {
        Clients = DBContext.Users.Where(u => u.Roleid == 4).ToList();
    }
}