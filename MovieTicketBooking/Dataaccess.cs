using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movieticketbooking
{
    internal class Dataaccess
    {
        static string connectionstring = "Data Source=ics-lt-d6l96v3\\sqlexpress;" + "Initial Catalog= Moviesdb;Integrated Security=true;";
        public static void insertmovieinfo(int movieid, string title, DateTime releasedate, string genre)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionstring))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "insertmovieinfo";
                    cmd.CommandType = CommandType.StoredProcedure;

                    //frst parameter for inserting
                    SqlParameter param1 = new SqlParameter();
                    param1.ParameterName = "@movieid";
                    param1.SqlDbType = SqlDbType.Int;
                    param1.Value = movieid;
                    cmd.Parameters.Add(param1);

                    //second parameter
                    SqlParameter param2 = new SqlParameter();
                    param2.ParameterName = "title";
                    param2.SqlDbType = SqlDbType.VarChar;
                    param2.Value = title;
                    cmd.Parameters.Add(param2);

                    //3rd parameter
                    SqlParameter param3 = new SqlParameter();
                    param3.ParameterName = "@releasedate";
                    param3.SqlDbType = SqlDbType.DateTime;
                    param3.Value = releasedate;
                    cmd.Parameters.Add(param3);

                    //4th parameter 
                    SqlParameter param4 = new SqlParameter();
                    param4.ParameterName = "@genre";
                    param4.SqlDbType = SqlDbType.VarChar;
                    param4.Value = genre;
                    cmd.Parameters.Add(param4);


                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        Console.WriteLine("data inserted successfully");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void insertticketsales(int salesid, int movieid, int screeenno, string showtime, int quantity, float amount, float price)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionstring))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "insertticketsales";
                    cmd.CommandType = CommandType.StoredProcedure;

                    //1st parameter for ticketsales
                    SqlParameter param1 = new SqlParameter();
                    param1.ParameterName = "@salesid";
                    param1.SqlDbType = SqlDbType.Int;
                    param1.Value = salesid;
                    cmd.Parameters.Add(param1);

                    //2nd parameter for ticketsales
                    SqlParameter param2 = new SqlParameter();
                    param2.ParameterName = "@movieid";
                    param2.SqlDbType = SqlDbType.Int;
                    param2.Value = movieid;
                    cmd.Parameters.Add(param2);

                    //3rd parameter
                    SqlParameter param3 = new SqlParameter();
                    param3.ParameterName = "@screeenno";
                    param3.SqlDbType = SqlDbType.Int;
                    param3.Value = screeenno;
                    cmd.Parameters.Add(param3);

                    //4th parameter
                    SqlParameter param4 = new SqlParameter();
                    param4.ParameterName = "@showtime";
                    param4.SqlDbType = SqlDbType.VarChar;
                    param4.Value = showtime;
                    cmd.Parameters.Add(param4);

                    //5th parameter
                    SqlParameter param5 = new SqlParameter();
                    param5.ParameterName = "@quantity";
                    param5.SqlDbType = SqlDbType.Int;
                    param5.Value = quantity;
                    cmd.Parameters.Add(param5);

                    //6th parameter
                    SqlParameter param6 = new SqlParameter();
                    param6.ParameterName = "@amount";
                    param6.SqlDbType = SqlDbType.Float;
                    param6.Value = amount;
                    cmd.Parameters.Add(param6);

                    //7th parameter
                    SqlParameter param7 = new SqlParameter();
                    param7.ParameterName = "@price";
                    param7.SqlDbType = SqlDbType.Float;
                    param7.Value = price;
                    cmd.Parameters.Add(param7);


                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        Console.WriteLine("Successfully inserted");
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        //retreiving the movieinfo table
        public static void gettickectsinfo()
        {
            SqlConnection con = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "gettickectsinfo";
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds, "movies");
            foreach (DataRow dr in ds.Tables["movies"].Rows)
            {
                Console.WriteLine("{0}\t{1}\t{2}\t{3}", dr["movieid"], dr["title"], dr["releasedate"], dr["genre"]);
            }
        }
        //retreiving for tickectsales
        public static void getticketsales()
        {
            SqlConnection con = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "getticketsales";
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();

            da.Fill(ds, "Ticketsales");

            foreach (DataRow dr in ds.Tables["Ticketsales"].Rows)
            {
                Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}", dr["salesid"], dr["movieid"], dr["screeenno"], dr["showtime"], dr["quantity"], dr["amount"], dr["price"]);
            }
            con.Close();
        }

        //updating the movieinfo table
        public static void updatemovieinfo()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionstring))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "updatemovieinfo";
                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        Console.WriteLine("movieid is updated successfully");
                    }
                    else
                    {
                        Console.WriteLine("ERROR occurred");
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        //Retreiving the tables using joins
        public static void getmovieandtickets()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionstring))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "retrievingjoins";
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Ticketsales");
                    foreach (DataRow dr in ds.Tables["Ticketsales"].Rows)
                    {
                        Console.WriteLine("{0}\t{1}", dr[0], dr[1]);
                    }
                    con.Close();
                }
            }
            catch(Exception ex) 
            { 
                Console.WriteLine(ex.Message);
            }
        }
    }

}
