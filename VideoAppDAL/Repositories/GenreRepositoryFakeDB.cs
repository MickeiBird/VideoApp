using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoAppDAL.Entities;

namespace VideoAppDAL.Repositories
{
    class GenreRepositoryFakeDB : IGenreRepository
    {
        private static int Id = 1;
        private static List<Genre> Genres = new List<Genre>();

        public Genre CreateGenre(Genre gen)
        {
            Genre newGenre;
            Genres.Add(newGenre = new Genre()
            {
                Id = Id++,
                Name = gen.Name
            });
            return newGenre;
        }

        public Genre Delete(int Id)
        {
            var gen = Get(Id);
            Genres.Remove(gen);
            return gen;
        }

        public Genre Get(int Id)
        {
            return Genres.FirstOrDefault(x => x.Id == Id);
        }

        public List<Genre> GetAll()
        {
            return new List<Genre>(Genres);
        }
    }
}
