﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proj5MVC16Aug.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string pname { get; set; }
        public string pcat { get; set; }
        public double price { get; set; }
    }
}