
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO
{
    public class Transaction
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int AccountFK { get; set; }
        public int ProductFK { get; set; }


        public override string ToString()
        {
            return "Id: " + Id +
                " Date: " + Date +
                "AccountFK: " + AccountFK +
                " ProductFK: " + ProductFK;
        }
    }
}
