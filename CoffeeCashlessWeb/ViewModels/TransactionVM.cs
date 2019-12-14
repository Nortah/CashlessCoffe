using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoffeeCashlessWeb.ViewModels
{
    public class TransactionVM
    {
        public DateTime DateIn { get; set; }
        public DateTime DateOut { get; set; }
        public int IdRoom { get; set; }
        public int IdClient { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Forname { get; set; }
        public double Days { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }

        public decimal FinalTotal { get; set; }

        public string Location { get; set; }
        public int Category { get; set; }
        public string Pic1 { get; set; }
        public string Pic2 { get; set; }
        public string Pic3 { get; set; }
        public int CliNumber { get; set; }
        public int DateInDays { get; set; }
        public int DateInMonths { get; set; }
        public int DateInYears { get; set; }
        public int DateOutDays { get; set; }
        public int DateOutMonths { get; set; }
        public int DateOutYears { get; set; }
        public bool Tv { get; set; }
        public bool Hairdryer { get; set; }
        public bool Parking { get; set; }
        public bool Wireless { get; set; }
        public int Error { get; set; }
        public int NumberRoom { get; set; }

        public List<int> IdList { get; set; }
        public List<int> IdNumber { get; set; }

        public decimal TotalWithRoom { get; set; }

        public TransactionVM(int idRoom, int idClient, DateTime dateIn, DateTime dateOut, string lastname, string forname, double days, decimal price, List<int> idList, List<int> idNumber, int nbPerson, decimal nbrSolo, decimal nbrDuo)
        {
            IdRoom = idRoom;
            IdClient = idClient;
            DateIn = dateIn;
            DateOut = dateOut;
            Lastname = lastname;
            Forname = forname;
            Days = days;

            Price = price;
            IdList = idList;
            IdNumber = idNumber;
            CliNumber = nbPerson;

            Total = (decimal)(days * (int)Price); // Total Price
            FinalTotal = Total * nbPerson; // Final Price

            TotalWithRoom = (decimal)(days) * (nbrSolo + nbrDuo); // Total price for a booking
        }

      


    }

}