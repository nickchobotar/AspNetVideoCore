using AspNetVideoCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace AspNetVideoCore.Data
{

    /// <summary>
    /// VideoDb-Context that inherits form the DbContext class. This class will be your connection to the database
    /// </summary>
    public class VideoDbContext : IdentityDbContext<User>
    {
        public DbSet<Video> Videos { get; set; }  // DbSet properties, which are mirrored as tables in DB

        // contructor
        //For the AddDbContext method to be able to add the context to the 
        //services collection, the VideoDbContext must have a constructor 
        //with a DbContextOptions<VideoDbContext> parameter, 
        //which passes the parameter object to its base constructor.

        public VideoDbContext(DbContextOptions<VideoDbContext> options)
        : base(options)
        {
        }

        
        //The OnModelCreating method must be overridden to 
        //    enable Entity Framework to build the entity model for the database.

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
