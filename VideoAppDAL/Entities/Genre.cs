using System;
using System.Collections.Generic;
using System.Text;

namespace VideoAppDAL.Entities
{
   public class Genre
    {
        public int Id { get; set; }
        public String Name { get; set; }

        public Genre(int Id, String Name)
        {
            this.Id = Id;
            this.Name = Name;
        }

        public Genre()
        {

        }


    }
}
