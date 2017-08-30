using System;
using System.Collections.Generic;
using System.Text;
using VideoAppBLL.BusinessObjects;

namespace VideoAppBLL
{
    public interface IGenreService
    {
        //C
        GenreBO Create(GenreBO gen);
        //R
        List<GenreBO> GetAll();
        GenreBO Get(int Id);
        //U
        GenreBO Update(GenreBO gen);
        //D
        GenreBO Delete(int Id);
    }
}
