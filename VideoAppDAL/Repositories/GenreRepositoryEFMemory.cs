using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoAppDAL.Context;
using VideoAppDAL.Entities;

namespace VideoAppDAL.Repositories
{
    class GenreRepositoryEFMemory : IGenreRepository
    {
        InMemoryContext context;

        public GenreRepositoryEFMemory(InMemoryContext context)
        {
            this.context = context;
        }

        public Genre CreateGenre(Genre gen)
        {
            context.Genres.Add(gen);
            return gen;
        }

        public Genre Delete(int Id)
        {
            var vid = Get(Id);
            context.Genres.Remove(vid);
            return vid;
        }

        public Genre Get(int Id)
        {
            return context.Genres.FirstOrDefault(x => x.Id == Id);
        }

        public List<Genre> GetAll()
        {
            return context.Genres.ToList();
        }
    }
}
