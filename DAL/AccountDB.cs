using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AccountDB
    {
        public static List<Account> GetAccountsByMonth(int Id) //will sort only the month and year since the day is generated automatically in BLL
        {
            List<Account> results = null;


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
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Account>();

                            Account account = new Account();

                            account.Id = (int)dr["Id"];

                            account.TotalAmount = (decimal)dr["TotalAmount"];

                            results.Add(account);

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
    }
}
