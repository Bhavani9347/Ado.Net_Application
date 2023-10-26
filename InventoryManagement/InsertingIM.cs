using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlTypes;

namespace InventoryManagement
{
    internal class InsertingIM
    {
        static String connectionstring = "Data Source=ICS-LT-D6L96V3\\SQLEXPRESS;" + "Initial Catalog=Inventorydb; Integrated Security=True;";
        public static void InsertCategory(int prodid, string prodname, int price, int qty)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionstring))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "usp_insertprod";
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter param1 = new SqlParameter();
                    param1.ParameterName = "@prodid";
                    param1.SqlDbType = SqlDbType.Int;
                    param1.Value = prodid;



                    cmd.Parameters.Add(param1);



                    SqlParameter param2 = new SqlParameter();
                    param2.ParameterName = "@prodname";
                    param2.SqlDbType = SqlDbType.VarChar;
                    param2.Value = prodname;



                    cmd.Parameters.Add(param2);



                    SqlParameter param3 = new SqlParameter();
                    param3.ParameterName = "@price";
                    param3.SqlDbType = SqlDbType.Money;
                    param3.Value = price;



                    cmd.Parameters.Add(param3);



                    SqlParameter param4 = new SqlParameter();
                    param4.ParameterName = "@qty";
                    param4.SqlDbType = SqlDbType.Int;
                    param4.Value = qty;



                    cmd.Parameters.Add(param4);



                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        Console.WriteLine(prodname + "data inserted succesfully");
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void Getprodinfo()



        {



            try



            {



                using (SqlConnection con = new SqlConnection(connectionstring))



                {



                    //working with stored procedures



                    // creating command & setting its properties



                    SqlCommand command = new SqlCommand();



                    command.Connection = con;



                    command.CommandText = "selectallproducts";



                    command.CommandType = CommandType.StoredProcedure;





                    con.Open();



                    using (SqlDataReader reader = command.ExecuteReader())



                    {



                        if (reader.HasRows)



                        {



                            while (reader.Read())



                            {



                                Console.WriteLine("{0} {1} {2} {3} ",



                                    reader[0], reader[1], reader[2], reader[3]);



                            }



                        }



                        else



                        {



                            Console.WriteLine("No records found");



                        }



                        reader.Close();



                    }



                }



            }



            catch (Exception ex)
            {
                Console.WriteLine(ex);

            }
        }
        public static void updateproductinfo()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionstring))
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = con;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "usp_updateprice";
                   
                    con.Open();

                    int i = command.ExecuteNonQuery();
                    if (i > 0)
                    {
                        Console.WriteLine("product quantity updated successfully");
                    }
                    else { Console.WriteLine("all products having good qty "); }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        
        }
    }



