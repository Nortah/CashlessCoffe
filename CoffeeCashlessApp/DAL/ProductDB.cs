
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System;

namespace DAL
{
    public static class ProductDB
    {
        public static List<Product> GetAllProducts()
        {
            List<Product> results = null;
       
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["CashlessCoffee_DB"].ConnectionString;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Product";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Product>();

                            Product product = new Product();

                            product.Id = (int)dr["Id"];

                            product.Name = (string)dr["Name"];

                            product.Price = (float)dr["Price"];

                            results.Add(product);

                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return results;
        }
        public static int AddProduct(Product product)
        {
            {
                int result = 0;

                string connectionString = ConfigurationManager.ConnectionStrings["CashlessCoffee_DB"].ConnectionString;

                try
                {
                    using (SqlConnection cn = new SqlConnection(connectionString))
                    {
                        string query = "Insert into Reservation (Id, Name, Price) " +
                            "Values(@Id, @Name, @Price)";
                        SqlCommand cmd = new SqlCommand(query, cn);
                        cmd.Parameters.AddWithValue("@Id", product.Id);
                        cmd.Parameters.AddWithValue("@Name", product.Name);
                        cmd.Parameters.AddWithValue("@Price", product.Price);
                        cn.Open();

                        result = cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
                //return the number of affected rows 
                return result;
            }
        }
        public static Product GetProdcutById(int id)
        {

            Product product = new Product(); ;

            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["CashlessCoffee_DB"].ConnectionString;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Product Where Id = @Id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@Id", id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {

                            product.Id = (int)dr["Id"];

                            product.Name = (string)dr["Name"];

                            product.Price = (double)dr["Price"];
                            

                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return product;
        }
    }
}
