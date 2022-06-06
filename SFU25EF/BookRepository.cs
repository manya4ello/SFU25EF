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
        /// <summary>
        /// Получить все киниги
        /// </summary>
        /// <returns></returns>
        public List<Book> GetAllBooks()
        {
            using (var db = new AppContext())
            {
                return db.Books.ToList();
            }
        }

        /// <summary>
        /// Получить книгу по ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Book GetBookByID (int id)
        {
            using (var db = new AppContext())
            {
                return db.Books.Where(c=>c.Id ==id).FirstOrDefault();
            }
        }

        /// <summary>
        /// Получить книгу по названию
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Book GetBookByTitle(string title)
        {
            using (var db = new AppContext())
            {
                return db.Books.Where(c => c.Title == title).FirstOrDefault();
            }
        }

        /// <summary>
        /// Добавить книгу
        /// </summary>
        /// <param name="book"></param>
        public void AddNewBook(Book book)
        {
            using (var db = new AppContext())
            {
                db.Books.Add(book);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Удалить книгу
        /// </summary>
        /// <param name="book"></param>
        public void DeleteBook(Book book)
        {
            using (var db = new AppContext())
            {
                db.Books.Remove(book);
                db.SaveChanges();
            }
        }
        /// <summary>
        /// Обновить год написания книги по ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newyear"></param>
        public void UpdateYearByID(int id, int newyear)
        {
            using (var db = new AppContext())
            {
                var book = db.Books.FirstOrDefault(c => c.Id == id);
                book.Year = newyear;
                db.SaveChanges();
            }
        }
        /// <summary>
        /// Получать список книг определенного жанра и вышедших между определенными годами.
        /// </summary>
        /// <param name="genre"></param>
        /// <param name="firstyear"></param>
        /// <param name="lastyear"></param>
        /// <returns></returns>
        public List<Book> GetBooksOfGenreBtwYears(Genre genre, int firstyear, int lastyear)
        {
            using (var db = new AppContext())
            {
               
               return db.Books.Where(c => c.Year >= firstyear && c.Year <= lastyear && c.Genres.Contains(genre)).ToList();
               
            }
        }
        /// <summary>
        /// Получать количество книг определенного автора в библиотеке.
        /// </summary>
        /// <param name="genre"></param>
        /// <param name="firstyear"></param>
        /// <param name="lastyear"></param>
        /// <returns></returns>
        public int CountBooksOfAuthor(Author author)
        {
            using (var db = new AppContext())
            {
                return db.Books.Where(c => c.Author == author).Count();

            }
        }
        /// <summary>
        /// Получать количество книг определенного жанра в библиотеке
        /// </summary>
        /// <param name="author"></param>
        /// <returns></returns>
        public int CountBooksOfGenere(Genre genre)
        {
            using (var db = new AppContext())
            {
                return db.Books.Where(c => c.Genres.Contains(genre)).Count();

            }
        }
        /// <summary>
        /// Получать булевый флаг о том, есть ли книга определенного автора и с определенным названием в библиотеке.
        /// </summary>
        /// <param name="genre"></param>
        /// <returns></returns>
        public bool FlagByNameAndAuthor(string title, Author author)
        {
            using (var db = new AppContext())
            {
                return db.Books.Where(c => c.Title.Equals(title)&&c.Author == author).Any();

            }
        }

        /// <summary>
        /// Получение последней вышедшей книги. Выборка по году выпуска, из них - с максимальным id, т.е. добавленную последней
        /// </summary>
        /// <returns></returns>
        public Book GetLatestBook()
        {
            using (var db = new AppContext())
            {
                var lastyearbooks = db.Books.Where(c => c.Year == db.Books.Max(d => d.Year)).ToList();
                var latestid = lastyearbooks.Where(d => d.Id == lastyearbooks.Max(c => c.Id)).FirstOrDefault();
                return latestid;
            }
        }

        /// <summary>
        /// Получение списка всех книг, отсортированного в алфавитном порядке по названию
        /// </summary>
        /// <returns></returns>
        public List<Book> GetAllBooksSortedByTitle()
        {
            using (var db = new AppContext())
            {
                return db.Books.OrderBy(c => c.Title).ToList();
            }
        }

        /// <summary>
        /// Получение списка всех книг, отсортированного в порядке убывания года их выхода.
        /// </summary>
        /// <returns></returns>
        public List<Book> GetAllBooksSortedByYearDesc()
        {
            using (var db = new AppContext())
            {
                return db.Books.OrderByDescending(c => c.Year).ToList();
            }
        }
    }
}
