using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFU25EF.Entities;

namespace SFU25EF
{
    public class BookRepository
    {
        public List<Book> GetAllBooks()
        {
            using (var db = new AppContext())
            {
                return db.Books.ToList();
            }
        }

        public Book GetBookByID (int id)
        {
            using (var db = new AppContext())
            {
                return db.Books.Where(c=>c.Id ==id).FirstOrDefault();
            }
        }
        public void AddNewBook(Book book)
        {
            using (var db = new AppContext())
            {
                db.Books.Add(book);
                db.SaveChanges();
            }
        }

     }
}
