using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFU25EF.Entities;

namespace SFU25EF
{
    public class UserRepository
    {
        public List<User> GetAllUsers()
        {
            using (var db = new AppContext())
            {
                return db.Users.ToList();
            }
        }

        public User GetUserByID(int id)
        {
            using (var db = new AppContext())
            {
                
                 return db.Users.Where(c => c.Id == id).FirstOrDefault();
                
            }
        }

        public void AddNewUser(User user)
        {
            using (var db = new AppContext())
            {
                db.Users.Add(user);
                db.SaveChanges();
            }
        }

        public void DeleteUser(User user)
        {
            using (var db = new AppContext())
            {
                db.Users.Remove(user);
                db.SaveChanges();
            }
        }

        public void UpdateNameByID(int id, string newname)
        {
            using (var db = new AppContext())
            {
                var user = db.Users.FirstOrDefault(c => c.Id == id);
                user.Name = newname;
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Получать булевый флаг о том, есть ли определенная книга на руках у пользователя.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="book"></param>
        /// <returns></returns>
        public bool FlagIfBookRentedByUser(User user, Book book)
        {
            using (var db = new AppContext())
            {

                return db.Users.Where(c => c == user && c.Books.Contains(book)).Any();

            }
        }

        /// <summary>
        /// Получать количество книг на руках у пользователя
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int CountBooksRentedByUser(User user)
        {
            using (var db = new AppContext())
            {

                return db.Users.Where(c => c == user).Select(c => c.Books.Count()).FirstOrDefault();

            }
        }
    }
}
