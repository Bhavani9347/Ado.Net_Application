using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();
            while (!false)
            {
                Console.WriteLine("Library Management System");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Remove Book");
                Console.WriteLine("3. Search Book");
                Console.WriteLine("4. Display book");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Enter Title: ");
                            string title = Console.ReadLine();
                            Console.WriteLine("Enter Author: ");
                            string author = Console.ReadLine();
                            Console.WriteLine("Enter ISBN: ");
                            string isbn = Console.ReadLine();
                            Book newBook = new Book { Title = title, Author = author, ISBN = isbn };//object intializer 
                            library.AddBook(newBook);
                            break;

                        case 2:
                            Console.WriteLine("Enter ISBN of the Book to Remove: ");
                            string removeISBN = Console.ReadLine();
                            library.RemoveBook(removeISBN);
                            break;

                        case 3:
                            Console.WriteLine("Enter Title to Search: ");
                            string searchTitle = Console.ReadLine();
                            library.SearchBook(searchTitle);
                            break;
                        case 4:
                            library.Display();
                            break;
                        case 5:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Please enter the other choice:");
                }
            }
        }
    }
}
   