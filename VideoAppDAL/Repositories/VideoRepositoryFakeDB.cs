using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoAppEntity;

namespace VideoAppDAL.Repositories
{
    class VideoRepositoryFakeDB : IVideoRepository
    {
        private static int Id = 1;
        private static List<Video> Vidoes = new List<Video>();

        public Video Create(Video vid)
        {
            Video newVideo;
            Vidoes.Add(newVideo = new Video()
            {
                Id = Id++,
                Name = vid.Name,
                Genre = vid.Genre,
                Year = vid.Year
            });
            return newVideo;
        }

        public Video Delete(int Id)
        {
            var vid = Get(Id);
            Vidoes.Remove(vid);
            return vid;
        }

        public Video Get(int Id)
        {
            return Vidoes.FirstOrDefault(x => x.Id == Id);
        }

        public List<Video> GetAll()
        {
            return new List<Video>(Vidoes);
        }
    }
}
