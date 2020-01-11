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
    public class TransactionDB
    {
        public static List<Transaction> GetAllTransactions()
        {
            List<Transaction> results = null;

            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["CashlessCoffee_DB"].ConnectionString;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from DeviceTransaction";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Transaction>();

                            Transaction transaction = new Transaction();

                            transaction.Id = (int)dr["Id"];

                            transaction.Date = (DateTime)dr["Date"];

                            transaction.AccountFK = (int)dr["AccountFK"];
                            transaction.ProductFK = (int)dr["ProductFK"];

                            results.Add(transaction);

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
        public static List<Transaction> GetTransactionsByMonth(int month, int year) //will sort only the month and year since the day is generated automatically in BLL
        {
            List<Transaction> results = null;
            

            string connectionString = ConfigurationManager.ConnectionStrings["CashlessCoffee_DB"].ConnectionString;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from DeviceTransaction Where MONTH(Date) = @month AND YEAR(Date) = @year";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@month", month);
                    cmd.Parameters.AddWithValue("@year", year);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Transaction>();

                            Transaction transaction = new Transaction();

                            transaction.Id = (int)dr["Id"];

                            transaction.Date = (DateTime)dr["Date"];

                            transaction.AccountFK = (int)dr["AccountFK"];

                            transaction.ProductFK = (int)dr["ProductFK"];

                            results.Add(transaction);

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
        public static Transaction GetTransactionsById(int id) //select a specific transaction
        {
            Transaction result = null;


            string connectionString = ConfigurationManager.ConnectionStrings["CashlessCoffee_DB"].ConnectionString;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from DeviceTransaction Where Id = @Id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@Id", id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            if (result == null)
                                result = new Transaction();

                            Transaction transaction = new Transaction();

                            transaction.Id = (int)dr["Id"];

                            transaction.Date = (DateTime)dr["Date"];

                            transaction.AccountFK = (int)dr["AccountFK"];

                            transaction.ProductFK = (int)dr["ProductFK"];

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
        public static int AddTransaction(Transaction transaction)
        {
            {
                int result = 0;

                string connectionString = ConfigurationManager.ConnectionStrings["CashlessCoffee_DB"].ConnectionString;

                try
                {
                    using (SqlConnection cn = new SqlConnection(connectionString))
                    {
                        string query = "Insert into DeviceTransaction (Date, AccountFK, ProductFK ) " +
                            "Values(@Date, @IdAccount, @IdProduct)";
                        SqlCommand cmd = new SqlCommand(query, cn);
                        cmd.Parameters.AddWithValue("@Id", transaction.Id);
                        cmd.Parameters.AddWithValue("@Date", transaction.Date);
                        cmd.Parameters.AddWithValue("@IdAccount", transaction.AccountFK);
                        cmd.Parameters.AddWithValue("@IdProduct", transaction.ProductFK);
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
