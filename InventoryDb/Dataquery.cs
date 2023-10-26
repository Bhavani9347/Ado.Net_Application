using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace invenatorydb1ass
{
    internal class Dataquery
    {
       

        //function for inserting values in products table using storedprocedure
        public static void enterproductinfo(int productid, string productname, int price, int quantity)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings ["AssessmentDb"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "usp_insertproductinfo";
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter param1 = new SqlParameter();
                    param1.ParameterName = "@productid";
                    param1.SqlDbType = SqlDbType.Int;
                    param1.Value = productid;



                    cmd.Parameters.Add(param1);



                    SqlParameter param2 = new SqlParameter();
                    param2.ParameterName = "@productname";
                    param2.SqlDbType = SqlDbType.VarChar;
                    param2.Value = productname;



                    cmd.Parameters.Add(param2);



                    SqlParameter param3 = new SqlParameter();
                    param3.ParameterName = "@price";
                    param3.SqlDbType = SqlDbType.Money;
                    param3.Value = price;



                    cmd.Parameters.Add(param3);



                    SqlParameter param4 = new SqlParameter();
                    param4.ParameterName = "@quantity";
                    param4.SqlDbType = SqlDbType.Int;
                    param4.Value = quantity;



                    cmd.Parameters.Add(param4);



                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        Console.WriteLine(productname + "data inserted succesfully");
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }



        //function to retrieve products
        public static void retreiveproducts()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["AssessmentDb"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "usp_selectproducts";
                    cmd.CommandType = CommandType.StoredProcedure;



                    con.Open();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                Console.WriteLine("{0} {1}  {2} {3}", rdr[0], rdr[1], rdr[2],
                                    rdr[3]);
                            }
                        }
                        else
                        {
                            Console.WriteLine("no records found");
                        }
                        rdr.Close();
                    }



                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }



        //to update quantity in product table
        public static void updateproductqty()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["AssessmentDb"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "usp_updateproduct";
                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        Console.WriteLine("product quantity updated successfully");
                    }
                    else { Console.WriteLine("all products having good qty "); }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }



        /*
        public static void deleterecords(int productid)
        {
            using(SqlConnection con = new SqlConnection())
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "usp_deleteproducts";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "@productid";
                param1.SqlDbType = SqlDbType.Int;
                param1.Value = productid;

 

                cmd.Parameters.Add(param1);

 

                con.Open();
                int i = cmd.ExecuteNonQuery();
            }
        }
        */



        //calculate amount of sales done 
        public static int calculateamt(int quantity, int price)
        {
            return quantity * price;
        }



        //entering data into sales table
        public static void entersalesinfo(int salesid, int productid, int quantity, int price)
        {
            double amount = calculateamt(quantity, price);



            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["AssessmentDb"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "usp_insertsales";
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter param1 = new SqlParameter();
                    param1.ParameterName = "@productid";
                    param1.SqlDbType = SqlDbType.Int;
                    param1.Value = productid;



                    cmd.Parameters.Add(param1);



                    SqlParameter param2 = new SqlParameter();
                    param2.ParameterName = "@salesid";
                    param2.SqlDbType = SqlDbType.VarChar;
                    param2.Value = salesid;



                    cmd.Parameters.Add(param2);



                    SqlParameter param3 = new SqlParameter();
                    param3.ParameterName = "@price";
                    param3.SqlDbType = SqlDbType.Money;
                    param3.Value = price;



                    cmd.Parameters.Add(param3);



                    SqlParameter param4 = new SqlParameter();
                    param4.ParameterName = "@quantity";
                    param4.SqlDbType = SqlDbType.Int;
                    param4.Value = quantity;



                    cmd.Parameters.Add(param4);



                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        Console.WriteLine(salesid + "data inserted succesfully");
                    }
                }



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }



        //retreiving data from sales table
        public static void retreivesales()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["AssessmentDb"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "usp_retreivesales";
                    cmd.CommandType = CommandType.StoredProcedure;



                    con.Open();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                Console.WriteLine("{0} {1}  {2} {3}", rdr[0], rdr[1], rdr[2],
                                    rdr[3]);
                            }
                        }
                        else
                        {
                            Console.WriteLine("no records found");
                        }
                        rdr.Close();
                    }



                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
   
