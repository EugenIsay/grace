using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace grace.Models;

public partial class Order
{
    public int Id { get; set; }

    public DateOnly Startdate { get; set; }

    public TimeOnly Starttime { get; set; }

    public int Userid { get; set; }

    public int Statusid { get; set; }

    public DateOnly? Enddate { get; set; }

    public int Durationinminutes { get; set; }

    public virtual Status Status { get; set; } = null!;

    public virtual User User { get; set; } = null!;
    
}
