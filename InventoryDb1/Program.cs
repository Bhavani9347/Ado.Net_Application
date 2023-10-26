using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventorydb
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Dataaccess.InsertCategory(12, "Electronics", 3500, 8);
            //Console.WriteLine();
            //Dataaccess.UpdatePrice(19, "Accessories", 40000, 300);
            //Console.WriteLine();
            Dataaccess.retreiveproducts();
        }
    }
}
