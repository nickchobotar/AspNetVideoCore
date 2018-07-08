using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspNetVideoCore.Entities;

namespace AspNetVideoCore.Services
{
    public class MockVideoData : IVideoData
    {

        // _videos of type IEnumerable<Video> . This field will hold the video data, loaded from a constructor
        //private IEnumerable<Video> _videos;              


        //To add the new video to the _videos collection, you must change its data type to List. You can’t add values to an IEnumerable collection.
        private List<Video> _videos;


        public MockVideoData() // contructor
        {
            _videos = new List<Video>
                {
                new Video { Id = 1, Genre = Models.Genres.Comedy, Title = "Shreck" },
                new Video { Id = 2, Genre = Models.Genres.Animated, Title = "Despicable Me" },
                new Video { Id = 3, Genre = Models.Genres.Action, Title = "Megamind" }
                };
        }

        
        public IEnumerable<Video> GetAll()   /// GetAll, which will return an IEnumerable<Video> collection.
        {
            return _videos; // _videos of type IEnumerable<Video> . This field will hold the video data, loaded from a constructor
        }

        // it return the video matching the id parameter value. Use LINQ to fetch the video with the FirstOrDefault method.

        public Video Get(int id)
        {
            return _videos.FirstOrDefault(v => v.Id.Equals(id));
        }

        public void Add(Video newVideo)
        {
            newVideo.Id = _videos.Max(v => v.Id) + 1;
            _videos.Add(newVideo);
        }
    }
}
