using System;
using DTO;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CoffeeCashlessWeb.Models
{
    public class TransactionM
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int AccountFK { get; set; }
        public int ProductFK { get; set; }

    }
}