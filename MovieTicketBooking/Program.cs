using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movieticketbooking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Dataaccess.insertmovieinfo(4, "Kushi", DateTime.Parse("02/08/2023"), "romantic");
            //Console.WriteLine();
            //Dataaccess.insertticketsales(45, 123, 2, "09/09/2023", 1000, 12, 18);
            //Console.WriteLine();
            //Dataaccess.gettickectsinfo();
            //Console.WriteLine();
            //Dataaccess.getticketsales();
            //Console.WriteLine();
            //Dataaccess.updatemovieinfo();
            //Console.WriteLine();
            Dataaccess.getmovieandtickets();
            Console.WriteLine();


        }
    }
}
