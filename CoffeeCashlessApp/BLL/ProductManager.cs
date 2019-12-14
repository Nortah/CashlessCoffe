using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ProductManager
    {
        public static Product GetProductById(int id)
        {
            return ProductDB.GetProdcutById(id);
        }
    }
}
