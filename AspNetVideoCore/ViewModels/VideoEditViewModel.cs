using AspNetVideoCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AspNetVideoCore.ViewModels
{
    // This view model will be used when the controller receives a post from a video’s Edit or Create view.

    public class VideoEditViewModel
    {
        public int Id { get; set; }

        [Required, MaxLength(80)]
        public string Title { get; set; }
        public Genres Genre { get; set; }
    }
}

    //Add a property called Genre of type Genres.
    //This property will contain the genre selected in the form when the submit button is clicked, 
    //and a post is made back to the controller on the server.