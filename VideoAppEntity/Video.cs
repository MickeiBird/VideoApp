using System;
using System.Collections.Generic;
using System.Text;

namespace VideoAppEntity
{
    public class Video
    {
        public int Id { get; set; }
        public string Genre { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }

        public Video(int Id, string Name, string Genre, int Year)
        {
            this.Id = Id;
            this.Name = Name;
            this.Genre = Genre;
            this.Year = Year;
        }

        public  Video()
        {

        }

    }
}
