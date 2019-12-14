using System;
using DTO;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CoffeeCashlessWeb.Models
{
    public class ProductM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Names { get; set; }
        public double Price { get; set; }
    }
}