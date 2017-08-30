using System;
using System.Collections.Generic;
using System.Text;
using VideoAppDAL.Repositories;
using VideoAppDAL.UOW;

namespace VideoAppDAL
{
    public class DALFacade
    {
        public IVideoRepository VideoRepository
        {
            get
            {
                return new VideoRepositoryEFMemory(
                    new Context.InMemoryContext());
            }
        }

        public IGenreRepository GenreRepository
        {
            get
            {
                return new GenreRepositoryEFMemory(
                    new Context.InMemoryContext());
            }
        }

        public IUnitOfWork UnitOfWork
        {   
            get
            {
                return new UnitOfWorkMem();
            }
        }
    }
}
