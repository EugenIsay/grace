using System;
using System.Collections.Generic;

namespace grace.Models;

public partial class Service
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Code { get; set; }

    public int Costperhour { get; set; }
}
