using AspNetVideoCore.Data;
using AspNetVideoCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetVideoCore.Services
{
    //    To use the database in the application, you can implement the
    //      IVideoData interface in a new service component class.
    //change the service registration in the
        //Configure-Services method in the Startup class to create instances of the new component


    public class SqlVideoData: IVideoData
    {
        private VideoDbContext _db;  // _db is a variable that holds context needed to communicate with the database.

        public SqlVideoData(VideoDbContext db)
        {
            _db = db;
        }

        public void Add(Video video)  //newVideo
        {
            _db.Add(video);  //Add(Object) Begins tracking the given entity until inserted into the database when SaveChanges() is called
            //_db.SaveChanges(); //Saves all changes made in this context to the database.

        }

        public Video Get(int id)
        {
            return _db.Find<Video>(id); // .find - > Finds an entity with the given primary key values
        }

        public IEnumerable<Video> GetAll()  //returns all the videos in the Videos table.
        {
            return _db.Videos; 
        }

        public int Commit()
        {
            return _db.SaveChanges();
        }
    }
}
