using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoAppDAL.Context;
using VideoAppDAL.Entities;

namespace VideoAppDAL.Repositories
{
    class VideoRepositoryEFMemory : IVideoRepository
    {
        InMemoryContext context;

        public VideoRepositoryEFMemory(InMemoryContext context)
        {
            this.context = context;
        }
        public Video Create(Video vid)
        {
            context.Videoes.Add(vid);
            return vid;
        }

        public Video Delete(int Id)
        {
            var vid = Get(Id);
            context.Videoes.Remove(vid);
            return vid;
        }

        public Video Get(int Id)
        {
            return context.Videoes.FirstOrDefault(x => x.Id == Id);

        }

        public List<Video> GetAll()
        {
            return context.Videoes.ToList();
        }
    }
}
