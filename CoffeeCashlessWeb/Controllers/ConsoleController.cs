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
            return View();
        }

            ProductM pvm = new ProductM
            {
                Names = ProductManager.GetAllProductName()
            };
            return View(pvm);
        }

        [HttpPost]
        public ActionResult Index(ProductM pvm = null)
        {
            if (ModelState.IsValid)
            {
       
                Session["pvm"] = pvm;

                
                Transaction transaction = new Transaction
                {
                    Date = DateTime.Now,
                    AccountFK = pvm.Id,
                    ProductFK = ProductManager.GetIdByProductName(pvm.Name)
                };

                TransactionManager.AddTransaction(transaction);

                ProductM pvm1 = new ProductM
                {
                    Names = ProductManager.GetAllProductName()
                };

                return View(pvm1);
            }
        }

    }
}
