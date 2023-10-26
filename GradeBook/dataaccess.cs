using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace gradebook
{
    internal class dataaccess
    {
        static String connectionstring = "Data Source=ICS-LT-D6L96V3\\SQLEXPRESS;" + "Initial Catalog=Inventorydb; Integrated Security=True;";

        public static void Retrivedata()
        {
            string query = "select *from students";
            SqlConnection connection = new SqlConnection(connectionstring);
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet, "students");

            foreach (DataRow dr in dataSet.Tables["students"].Rows)
            {
                Console.WriteLine("{0} \t{1}", dr[0], dr[1]);
            }
        }


        public static void insertgrade(int stuid, string subjectname, int grade)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "usp_insertgrade";
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter param1 = new SqlParameter();
                    param1.ParameterName = "@stuid";
                    param1.SqlDbType = SqlDbType.Int;
                    param1.Value = stuid;

                    cmd.Parameters.Add(param1);


                    SqlParameter param2 = new SqlParameter();
                    param2.ParameterName = "@subjectname";
                    param2.SqlDbType = SqlDbType.VarChar;
                    param2.Value = subjectname;
                    cmd.Parameters.Add(param2);

                    SqlParameter param3 = new SqlParameter();
                    param3.ParameterName = "@grade";
                    param3.SqlDbType = SqlDbType.Int;
                    param3.Value = grade;
                    cmd.Parameters.Add(param3);

                    connection.Open();
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.InsertCommand = cmd;
                    int i = cmd.ExecuteNonQuery();
                    connection.Close();
                    if (i > 0)
                    {
                        Console.WriteLine(stuid + "data inserted successfully");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void updategrade(int stuid, int grade)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = connection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.CommandText = "usp_updategrade";

                    SqlParameter parameter = new SqlParameter();
                    parameter.ParameterName = "@stuid";
                    parameter.SqlDbType = SqlDbType.Int;
                    parameter.Direction = ParameterDirection.Input;
                    parameter.Value = stuid;
                    sqlCommand.Parameters.Add(parameter);


                    SqlParameter parameter1 = new SqlParameter();
                    parameter1.ParameterName = "@grade";
                    parameter1.SqlDbType = SqlDbType.Int;
                    parameter1.Direction = ParameterDirection.Input;
                    parameter1.Value = grade;
                    sqlCommand.Parameters.Add(parameter1);

                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    DataSet ds = new DataSet("Student");
                    adapter.UpdateCommand = sqlCommand;
                    int i = adapter.UpdateCommand.ExecuteNonQuery();

                    if (i > 0)
                    {
                        Console.WriteLine("updated successfully");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
    


