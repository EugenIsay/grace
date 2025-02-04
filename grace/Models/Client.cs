using System;
using System.Collections.Generic;

namespace grace.Models;

public partial class Client
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string? Patronimic { get; set; }

    public int Code { get; set; }

    public int Pasportseries { get; set; }

    public int Pasportnumber { get; set; }

    public DateOnly Birthday { get; set; }

    public string? Address { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
