using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFonctions
{
    class Program
    {
        public static void Main(string[] args)
        {
            Transaction transaction = new Transaction();
            transaction.Id = 0;
            transaction.Date = Convert.ToDateTime("10/01/2020");
            transaction.AccountFK = 0;
            transaction.ProductFK = 2;
            TransactionManager.AddTransaction(transaction);
            List<Transaction>monthlyTransactions = TransactionManager.GetTransactionsByMonth(12, 2019);
            Console.WriteLine(monthlyTransactions);
            TransactionManager.DisplayTransactions(monthlyTransactions);
            TransactionManager.GetTotalByMonth(12, 2019);
            Console.WriteLine(TransactionManager.GetTotalByMonth(12, 2019));
            Console.ReadKey();
        }
    }
}
