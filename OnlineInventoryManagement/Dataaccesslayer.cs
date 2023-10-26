using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OnlineInventoryManagementSystem
{
    internal class Dataaccesslayer
    {
        static string connectionstring = "Data Source=ics-lt-b7l96v3\\sqlexpress;" + "Initial Catalog=Inventorydb; Integrated Security=True;";
        public static void enterproductsinfo(int productid, string productname, double price, int quantity)
        {
            try {
                // Create a new SqlConnection ..
                using (SqlConnection con = new SqlConnection(connectionstring))
                {

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "usp_insertProd";
                    cmd.CommandType = CommandType.StoredProcedure;


                    //parameter1-productid//
                    SqlParameter param1 = new SqlParameter();
                    param1.ParameterName = "@productid";
                    param1.SqlDbType = SqlDbType.Int;
                    param1.Value = productid;
                    cmd.Parameters.Add(param1);

                    //parameter2-Price//
                    SqlParameter param2 = new SqlParameter();
                    param2.ParameterName = "@price";
                    param2.SqlDbType = SqlDbType.Int;
                    param2.Value = price;
                    cmd.Parameters.Add(param2);

                    //parameter3-Name//
                    SqlParameter param3 = new SqlParameter();
                    param3.ParameterName = "@name";
                    param3.SqlDbType = SqlDbType.VarChar;
                    param3.Value = productname;
                    cmd.Parameters.Add(param3);

                    //connection open //
                    con.Open();
                    // Execute the stored procedure
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        // Data inserted successfully.
                        Console.WriteLine(productname + " " + "data inserted succesfully");

                    }
                }
            }
            catch (Exception ex)
            {
                // display an error message.
                Console.WriteLine(ex.Message);

            }
        }
    }
}










  