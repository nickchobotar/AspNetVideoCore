using AspNetVideoCore.Data;
using AspNetVideoCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetVideoCore.Services
{
    public class SqlVideoData: IVideoData
    {
        private VideoDbContext _db;  // context needed to communicate with the database.

        public SqlVideoData(VideoDbContext db)
        {
            _db = db;
        }


        public void Add(Video video)  //newVideo
        {
            _db.Add(video);
            _db.SaveChanges();
        }

        public Video Get(int id)
        {
            return _db.Find<Video>(id);
        }

        public IEnumerable<Video> GetAll()
        {
            return _db.Videos;
        }
    }
}
