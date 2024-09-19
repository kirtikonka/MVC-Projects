using System;
using System.Collections.Generic;

namespace Proj7MVC.Models;

public partial class User
{
    public int UserId { get; set; }

    public string? Username { get; set; }

    public string? Pass { get; set; }

    public bool? IsBlocked { get; set; }
}
