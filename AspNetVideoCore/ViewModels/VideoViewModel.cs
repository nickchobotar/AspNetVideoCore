using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetVideoCore.ViewModels
{
    // use the VideoViewModel to send data to the Index view

    public class VideoViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; } // not an Genre ID just Genre name STRING 
    }

}


/*
* 
* Now that the view model has been created, you need to send it to the view as its model. @model
* This requires some changes to the HomeController class and the Index view. 
* You need to fetch the video from the _videos collection using its id, 
*      and then convert the genre id to the name for the corresponding value in the Genres enum.
* 
* using LINQ Select method in the Index action to convert each video into a VideoViewModel object, and store it in the model field.
*/
