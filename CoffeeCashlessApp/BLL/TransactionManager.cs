using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class TransactionManager
    {
        public static int AddTransaction(Transaction transaction)
        {
            return TransactionDB.AddTransaction(transaction);
        }
        public static List<Transaction> GetAllTransactions()
        {
            return TransactionDB.GetAllTransactions();
        }

        public static List<Transaction>GetTransactionsByMonth(int month, int year)
        {
            return TransactionDB.GetTransactionsByMonth(month, year);
        }

        public static Transaction GetTransactionById(int id)
        {
            return TransactionDB.GetTransactionsById(id);
        }

        public static void DisplayTransactions(List<Transaction> transactions)
        {
            foreach(Transaction t in transactions)
            {
                Console.WriteLine("\n " + t);
            }
        }
        public static double GetTotalByMonth(int month, int year)
        {
            double total = 0;
            List<Transaction> transactions = TransactionDB.GetTransactionsByMonth(month, year);
            foreach(Transaction t in transactions)
            {
                Product product = ProductManager.GetProductById(t.ProductFK);
                total += product.Price;
                Console.WriteLine("\n log Nestor: " + product.Price + " " + t.Id + " "+ product.Id);
            }
            return total;
        }
    }
}
