using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoffeeCashlessWeb.ViewModels
{
    public class TransactionSimpleViewModel
    {
        //Acount
        public int IdAccount { get; set; }

        //Product
        public int IdProduct { get; set; }

        //Product
        public int Id { get; set; }


        public DateTime Date { get; set; }

        public decimal Price { get; set; }

        public decimal TotalPrice { get; set; }

        public TransactionSimpleViewModel(DateTime date, int id, int idAccount, int idProduct, decimal price)
        {
            Id = id;
            Date = date;
            IdAccount = idAccount;
            IdProduct = idProduct;
            Price = price;
            TotalPrice += price;
        }
    }
}