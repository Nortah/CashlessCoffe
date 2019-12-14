using System;
using DTO;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CoffeeCashlessWeb.ViewModels
{
    public class TransactionVM
    {
        [Required(ErrorMessage = "Veuillez entrer votre ID !")]
        public int IdAccount { get; set; }

        public int IdProduct { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}