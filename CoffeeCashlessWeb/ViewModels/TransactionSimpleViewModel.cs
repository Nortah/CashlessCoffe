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

        public DateTime Date { get; set; }

        public TransactionSimpleViewModel(DateTime date, int idAccount, int idProduct)
        {
            Date = date;
            IdAccount = idAccount;
            IdProduct = idProduct;
        }
    }
}