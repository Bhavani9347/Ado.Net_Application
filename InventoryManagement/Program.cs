using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement
{
    internal class Program
    {
     /*   static String connectionstring = "Data Source=ICS-LT-D6L96V3\\SQLEXPRESS" + "Initial Catalog=Inventorydb.; Integrated Security=True;";*/
        static void Main(string[] args)
        {
            //insert();
            //InsertingIM.Getprodinfo();
            InsertingIM.updateproductinfo();
            Console.WriteLine();
        }

        private static void insert()
        {
         InsertingIM.InsertCategory(127, "AC", 30000, 5);
        Console.WriteLine();
        }
    }
}
