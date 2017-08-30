using System;
using System.Collections.Generic;
using System.Text;

namespace VideoAppBLL.BusinessObjects
{
    public class GenreBO
    {
        public int Id { get; set; }
        public String Name { get; set; }

        public GenreBO(int Id, String Name)
        {
            this.Id = Id;
            this.Name = Name;
        }

        public GenreBO()
        {

        }

    }
}
