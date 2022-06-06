using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFU25EF.Entities;


namespace SFU25EF
{
    public class GenreRepositary
    {
        /// <summary>
        /// Получить все жанры
        /// </summary>
        /// <returns></returns>
        public List<Genre> GetAllGenres()
        {
            using (var db = new AppContext())
            {
                return db.Genres.ToList();
            }
        }

        /// <summary>
        /// Получить жанр по ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Genre GetGenreByID(int id)
        {
            using (var db = new AppContext())
            {
                return db.Genres.Where(c => c.Id == id).FirstOrDefault();
            }
        }
    }
}
