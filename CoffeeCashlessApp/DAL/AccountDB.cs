using DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AccountDB
    {
        public static Account GetAccountById(int Id)
        {
            Account result = null;


            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["CashlessCoffee_DB"].ConnectionString;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Account Where Id = @Id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@Id", Id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            if (result == null)
                                result = new Account();

                            result.Id = (int)dr["Id"];

                            result.TotalAmount = (decimal)dr["TotalAmount"];

                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }
        public static int UpdateAccountAmount(Account account)
        {
            {
                int result = 0;

                string connectionString = ConfigurationManager.ConnectionStrings["CashlessCoffee_DB"].ConnectionString;

                try
                {
                    using (SqlConnection cn = new SqlConnection(connectionString))
                    {
                        string query = "Update Account  " +
                            "Set TotalAmount = @Amount WHERE Id = @Id";
                        SqlCommand cmd = new SqlCommand(query, cn);
                        cmd.Parameters.AddWithValue("@Id", account.Id);
                        cmd.Parameters.AddWithValue("@Amount", account.TotalAmount);
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
    }
}
