using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeCashlessApp
{
    public class AccountManager
    {
        public static Account GetAccountById(int id)
        {
            return AccountDB.GetAccountById(id);
        }

        public static decimal GetAccountAmount(int id)
        {
            return AccountDB.GetAccountById(id).TotalAmount;
        }

        public static int decrementAccount(int id, decimal price)
        {
            Account account = AccountDB.GetAccountById(id);
            account.TotalAmount = account.TotalAmount - price;

            return AccountDB.UpdateAccountAmount(account);
        }

        public static int incrementAccount(int id, decimal price)
        {
            Account account = AccountDB.GetAccountById(id);
            account.TotalAmount = account.TotalAmount + price;

            return AccountDB.UpdateAccountAmount(account);
        }
    }
}
