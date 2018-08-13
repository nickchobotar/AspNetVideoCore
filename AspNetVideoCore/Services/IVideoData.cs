using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspNetVideoCore.Entities;


namespace AspNetVideoCore.Services
{
    public interface IVideoData
    {
        IEnumerable<Video> GetAll();  // IEnumerable supports ITERATION over a collection of a specified type.

        // To fetch the video matching the passed-in id in Details action method,
        //you must add a new method called Get to the IVideoData interface
        Video Get(int id);

        //Because you have implemented the IVideoData Interface as a service that is injected into the constructor,
        //    you have to add an Add method to it, and implement it in the MockVideoData class. 
        //This will make it possible to call the Add method on the _videos variable to add a new video
        void Add(Video newVideo);

        //The int value will in some instances reflect the number of records that were affected by the commit.
        int Commit();
    }
}
