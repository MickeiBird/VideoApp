using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoAppBLL.BusinessObjects;
using VideoAppDAL;
using VideoAppDAL.Entities;

namespace VideoAppBLL.Services
{
    public class GenreService : IGenreService
    {
        DALFacade facade;

        public GenreService(DALFacade facade)
        {
            this.facade = facade;
        }

        public GenreBO Create(GenreBO gen)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newGen = uow.GenreRepository.CreateGenre(Convert(gen));
                uow.Complete();
                return Convert(newGen);
            }
        }

        public GenreBO Delete(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newGen = uow.GenreRepository.Delete(Id);
                uow.Complete();
                return Convert(newGen);
            }
        }

        public GenreBO Get(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                return Convert(uow.GenreRepository.Get(Id));
            }
        }

        public List<GenreBO> GetAll()
        {
            using (var uow = facade.UnitOfWork)
            {
                return uow.GenreRepository.GetAll().Select(Convert).ToList();
            }
        }

        public GenreBO Update(GenreBO gen)
        {
            using (var uow = facade.UnitOfWork)
            {
                var genreFromDb = uow.GenreRepository.Get(gen.Id);
                if (genreFromDb == null)
                {
                    throw new InvalidOperationException("Genre not found");
                }
                genreFromDb.Name = gen.Name;

                uow.Complete();
                return Convert(genreFromDb);
            }
        }

        private Genre Convert(GenreBO gen)
        {
            return new Genre()
            {
                Id = gen.Id,
                Name = gen.Name
            };
        }

        private GenreBO Convert(Genre gen)
        {
            return new GenreBO()
            {
                Id = gen.Id,
                Name = gen.Name
            };
        }
    }
}
