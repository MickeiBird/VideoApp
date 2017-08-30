using System;
using System.Collections.Generic;
using System.Text;
using VideoAppDAL.Entities;

namespace VideoAppDAL
{
    public interface IGenreRepository
    {
        //C
        Genre CreateGenre(Genre gen);
        //R
        List<Genre> GetAll();
        Genre Get(int Id);
        //D
        Genre Delete(int Id);
    }
}
