using System;
using DTO;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace CoffeeCashlessWeb.Models
{
    public class AccountM
    {
        [Required(ErrorMessage = "Veuillez entrer votre ID !")]
        public int Id { get; set; }

        public decimal TotalAmount { get; set; }

    }
}