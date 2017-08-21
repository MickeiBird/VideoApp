using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoAppDAL;
using VideoAppEntity;

namespace VideoAppBLL.Services
{
    public class VideoService : IVideoService
    {
        public Video Create(Video vid)
        {
            Video newVideo;
            FakeDB.Vidoes.Add(newVideo = new Video()
            {
                Id = FakeDB.Id++,
                Name = vid.Name,
                Genre = vid.Genre,
                Year = vid.Year
            });
            return newVideo;
        }

        public Video Delete(int Id)
        {
            var vid = Get(Id);
            FakeDB.Vidoes.Remove(vid);
            return vid;
        }

        public Video Get(int Id)
        {
            return FakeDB.Vidoes.FirstOrDefault(x => x.Id == Id);
        }

        public List<Video> GetAll()
        {
            return new List<Video>(FakeDB.Vidoes);
        }

        public Video Update(Video vid)
        {
            var videoFromDb = Get(vid.Id);
            if (videoFromDb == null)
            {
                throw new InvalidOperationException("Video not found");
            }
            videoFromDb.Name = vid.Name;
            videoFromDb.Genre = vid.Genre;
            videoFromDb.Year = vid.Year;
            return videoFromDb;
        }
    }
}
