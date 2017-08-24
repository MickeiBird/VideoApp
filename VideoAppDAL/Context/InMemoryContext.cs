using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VideoAppEntity;

namespace VideoAppDAL.Context
{
    class InMemoryContext : DbContext
    {
        static DbContextOptions<InMemoryContext> options = 
            new DbContextOptionsBuilder<InMemoryContext>()
            .UseInMemoryDatabase("TheDB")
            .Options;

        //Options that we want in memory
        public InMemoryContext() : base(options)
        {

        }

        public DbSet<Video> Videoes { get; set; }
    }
}
