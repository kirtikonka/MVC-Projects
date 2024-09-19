using System;
using System.Collections.Generic;

namespace Proj7MVC.Models;

public partial class Auth
{
    public int Id { get; set; }
    public string? Email { get; set; }
    public string? Username { get; set; }
    public string? Pass { get; set; }
    public string? Urole { get; set; }
}
