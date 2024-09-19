using System;
using System.Collections.Generic;

namespace Proj7MVC.Models;

public partial class Cart
{
    public int Pid { get; set; }

    public string? Pname { get; set; }

    public string? Pcat { get; set; }

    public decimal? Price { get; set; }

    public int? Qyt { get; set; }

    public string? Pic { get; set; }

    public string? Dt { get; set; }

    public string? Suser { get; set; }
}
