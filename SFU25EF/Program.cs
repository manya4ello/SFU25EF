using System;
using System.Linq;
using SFU25EF.Entities; 

namespace SFU25EF
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //var firstrun = new Initialdata();
            var bookrepositary = new BookRepository();

            foreach (var book in bookrepositary.GetAllBooks())
                Console.WriteLine(book.Title);

            Console.WriteLine(bookrepositary.GetBookByID(1).Title);
            Console.WriteLine(bookrepositary.GetBookByID(5).Title);

            var userrepositary = new UserRepository();

            foreach (var user in userrepositary.GetAllUsers())
                Console.WriteLine(user.Name);

            Console.WriteLine("Нажмите любую кнопку");
            Console.ReadKey();
        }

    }
}
