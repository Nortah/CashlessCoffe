﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoffeeCashlessWeb.Controllers
{
    public class TransactionController : Controller
    {
        // GET: Transaction
        public ActionResult Index()
        {
            List<DTO.Transaction> transactions = DAL.TransactionDB.GetAllTransactions();
            return View(transactions);
        }

        // GET: Transaction/Details/2,2019
        public ActionResult Details(int month, int year)
        {
            List<DTO.Transaction> transactions = DAL.TransactionDB.GetTransactionsByMonth(month, year);
            return View(transactions);
        }

        // GET: Transaction/Details/5
        public ActionResult Details(int id)
        {
            DTO.Transaction transaction = null; // = DAL.TransactionDB.GetTransactionsByMonth(month, year);
            return View(transaction);
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