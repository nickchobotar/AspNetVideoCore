using AspNetVideoCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AspNetVideoCore.Entities
{
    public class Video
    {
        public int Id { get; set; }

        [Required, MaxLength(80)]
        public string Title { get; set; }

        [Display(Name ="Film Genre")]
        public Genres Genre { get; set; }
    }
}
