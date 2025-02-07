using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace grace.Models;
public partial class Orderservice
{
    public int Id { get; set; }
    public int Orderid { get; set; }

    public int Serviceid { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Service Service { get; set; } = null!;
}
