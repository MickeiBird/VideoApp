using System;
using System.Collections.Generic;
using System.Text;
using VideoAppDAL.Entities;

namespace VideoAppBLL.BusinessObject
{
    public class VideoBO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Genre Genre { get; set; }
        public int Year { get; set; }

        public VideoBO(int Id, string Name, Genre Genre, int Year)
        {
            this.Id = Id;
            this.Name = Name;
            this.Genre = Genre;
            this.Year = Year;
        }

        public VideoBO()
        {

        }

    }
}
