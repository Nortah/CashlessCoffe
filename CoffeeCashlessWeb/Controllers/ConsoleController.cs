using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using DTO;
using CoffeeCashlessWeb.ViewModels;
using CoffeeCashlessWeb.Models;
using CoffeeCashlessApp;

namespace CoffeeCashlessWeb.Controllers
{
    public class ConsoleController : Controller
    {

        public ActionResult Index()
        {

            TransactionVM pvm = new TransactionVM
            {
                Names = ProductManager.GetAllNamesProduct()
            };
            return View(pvm);
        }

        [HttpPost]
        public ActionResult Index(TransactionVM pvm = null)
        {
            if (ModelState.IsValid)
            {

                Session["pvm"] = pvm;

                Transaction transaction = new Transaction
                {
                    Date = DateTime.Now,
                    AccountFK = pvm.IdAccount,
                    ProductFK = ProductManager.GetIdByProductName(pvm.Name),

                };

                decimal price = ProductManager.GetPriceById(transaction.ProductFK);

                if (price <= AccountManager.GetAccountAmount(pvm.IdAccount))
                {


                    TransactionManager.AddTransaction(transaction);
                    AccountManager.decrementAccount(transaction.AccountFK, price);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Solde insuffisant");
                    return View();
                }




            }
            TransactionVM pvm1 = new TransactionVM
            {
                Names = ProductManager.GetAllNamesProduct()
            };

            return View(pvm1);
        }

    }
}