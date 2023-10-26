using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Inventorydb
{
    internal class Dataaccess
    {
        static string cs = "Data Source=ICS-LT-D6L96V3\\SQLEXPRESS" + "Initial Catalog=bhavanirdydb; Integrated Security=True;";

        public static void InsertCategory(int prodid, string prodname, int price, int qty)
        {
        try
        {
            using (SqlConnection con = new SqlConnection(cs))
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
        //updating the data
        public static void UpdatePrice(int prodid, string prodname, int newprice, int qty)
        {
            try
            {
                string cs = "Data Source=ICS-LT-D6L96V3\\SQLEXPRESS" + "Initial Catalog=bhavanirdydb; Integrated Security=True;";
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = conn;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "usp_updateprice";

                    SqlParameter parameter = new SqlParameter();
                    parameter.ParameterName = "@prodid";
                    parameter.SqlDbType = SqlDbType.Int;
                    parameter.Direction = ParameterDirection.Input;
                    parameter.Value = prodid;
                    command.Parameters.Add(parameter);

                    SqlParameter parameter1 = new SqlParameter();
                    parameter1.ParameterName = "@prodname";
                    parameter1.SqlDbType = SqlDbType.NVarChar;
                    parameter1.Direction = ParameterDirection.Input;
                    parameter1.Value = prodname;
                    command.Parameters.Add(parameter1);

                    SqlParameter parameter2 = new SqlParameter();
                    parameter2.ParameterName = "@newprice";
                    parameter2.SqlDbType = SqlDbType.VarChar;
                    parameter2.Direction = ParameterDirection.Input;
                    parameter2.Value = newprice;
                    command.Parameters.Add(parameter2);

                    SqlParameter parameter3 = new SqlParameter();
                    parameter3.ParameterName = "@qty";
                    parameter3.SqlDbType = SqlDbType.Float;
                    parameter3.Direction = ParameterDirection.Input;
                    parameter3.Value = qty;
                    command.Parameters.Add(parameter3);
                    conn.Open();

                    int i = command.ExecuteNonQuery();
                    if (i > 0)
                    {
                        // Data updated successfully
                        Console.WriteLine("updated successfully");

                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        //retreiving the data

          public static void retreiveproducts()
          {
            try
            {
                string cs = "Data Source=ICS-LT-D6L96V3\\SQLEXPRESS" + "Initial Catalog=bhavanirdydb; Integrated Security=True;";
                using (SqlConnection con = new SqlConnection(cs))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "usp_selectproduct";
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

