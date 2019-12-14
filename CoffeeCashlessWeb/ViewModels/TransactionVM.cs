﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoffeeCashlessWeb.ViewModels
{
    public class TransactionVM
    {
        //Acount
        public int IdAccount { get; set; }
        public decimal TotalAmount { get; set; }

        //Product
        public int IdProduct { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public DateTime Date { get; set; }

        //Transaction
        public int IdTransaction { get; set; }


        public TransactionVM(int idAccount, int idProduct)
        {
            IdAccount = idAccount;
            IdProduct = idProduct;
        }


        public TransactionVM(DateTime date, int idAccount, int idProduct)
        {
            Date = date;
            IdAccount = idAccount;
            IdProduct = idProduct;
        }
    }
}