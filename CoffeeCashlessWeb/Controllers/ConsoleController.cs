using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using DTO;
using CoffeeCashlessWeb.ViewModels;
using CoffeeCashlessWeb.Models;


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
                    //Id = 10,
                    Date = DateTime.Now,
                    AccountFK = pvm.IdAccount,
                    ProductFK = ProductManager.GetIdByProductName(pvm.Name)
                };
                
                TransactionManager.AddTransaction(transaction);


            }
            TransactionVM pvm1 = new TransactionVM
            {
                Names = ProductManager.GetAllNamesProduct()
            };

            return View(pvm1);
        }

    }
}
