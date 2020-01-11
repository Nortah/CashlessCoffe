using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CoffeeCashlessWeb.ViewModels;
using DTO;

namespace CoffeeCashlessWeb.Controllers
{
    public class TransactionController : Controller
    {
        // GET: Transaction
        public ActionResult Index()
        {
            List<Transaction> transactions = BLL.TransactionManager.GetAllTransactions();
            return View(ConvertList(transactions));
        }

        private List<TransactionSimpleViewModel> ConvertList(List<Transaction> transactions)
        {
            try
            {
                List<TransactionSimpleViewModel> vmList = new List<TransactionSimpleViewModel>();
                foreach (Transaction t in transactions)
                {
                    TransactionSimpleViewModel vm = new TransactionSimpleViewModel(t.Date, t.Id, t.AccountFK, t.ProductFK, BLL.ProductManager.GetPriceById(t.ProductFK));
                    vmList.Add(vm);
                }
                return vmList;
            }
            catch
            {
                return null;
            }
        }

        private TransactionSimpleViewModel ConvertObject(Transaction t)
        {
            return (new TransactionSimpleViewModel(t.Date, t.Id, t.AccountFK, t.ProductFK, BLL.ProductManager.GetPriceById(t.ProductFK)));
  
        }

       

        // POST: Transaction/Details/2019
        [HttpPost]
        public ActionResult Index(int month =12, int year=2020)
        {
            try
            {
                month = month + 1;
                month = month - 1;

                year = year + 1;
                year = year - 1;
            }
            catch(Exception e)
            {
                month = 01;
                year = 2020;
            }

            List<decimal> transactionsYear = BLL.TransactionManager.GetTotalYear(year);


            List<Transaction> transactions = BLL.TransactionManager.GetTransactionsByMonth(month, year);

            List<TransactionSimpleViewModel> t = ConvertList(transactions);

            if (t != null)
            {
                foreach (var item in t)
                {
                    item.TotalYear = transactionsYear;
                }

                return View(t);
            }
            else
            {
                List<TransactionSimpleViewModel> t2 = new List<TransactionSimpleViewModel>();
                t2.Add(new TransactionSimpleViewModel(new DateTime(1999, 01, 01), 1, 1, 1, 1, transactionsYear));



                return View(t2);
            }
            
        }


        // GET: Transaction/Details/5
        public ActionResult Details(int id)
        {
            Transaction transaction = BLL.TransactionManager.GetTransactionById(id);
            return View(ConvertObject(transaction));
        }
        


        // GET: Transaction/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Transaction/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Transaction/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Transaction/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Transaction/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Transaction/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
