using AspNetVideoCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetVideoCore.Data
{
    
    public class VideoDbContext : DbContext // DbContext class -- connection to the database.
    {
        public DbSet<Video> Videos { get; set; }  // DbSet properties, which are mirrored as tables in DB

        public VideoDbContext(DbContextOptions<VideoDbContext> options)
        : base(options)
        {
        }

       
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
