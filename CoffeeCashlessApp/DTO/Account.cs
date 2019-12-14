using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Account
    {
        public int Id { get; set; }
        public decimal TotalAmount { get; set; }

        public override string ToString()
        {
            return "Id: " + Id +
                " TotalAmount: " + TotalAmount;

        }
    }
}
