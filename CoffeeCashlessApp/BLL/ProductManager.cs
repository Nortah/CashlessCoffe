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
        public static decimal GetPriceById(int id)
        {
            return ProductDB.GetPriceById(id);
        }
        public static List<string> GetAllProductName()
        {
            List <Product> products = ProductDB.GetAllProducts();
            List<string> productsName = new List<string>();
            foreach(Product p in products)
            {
                productsName.Add(p.Name);
            }
            return productsName;
        }
        public static int GetIdByProductName(string name)
        {
            Product product = ProductDB.GetProdcutByName(name);
            return product.Id;
        }

        public static List<string> GetAllNamesProduct()
        {
            return ProductDB.GetAllNamesProduct();
        }
    }
}
