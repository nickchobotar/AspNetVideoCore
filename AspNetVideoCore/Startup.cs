using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using AspNetVideoCore.Services;
using AspNetVideoCore.Data;
using Microsoft.EntityFrameworkCore;
using AspNetVideoCore.Entities;
using Microsoft.AspNetCore.Identity;

namespace AspNetVideoCore
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true);

            if (env.IsDevelopment())
                builder.AddUserSecrets<Startup>();

            Configuration = builder.Build();
        }        

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var conn = Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<VideoDbContext>(options =>
            options.UseSqlServer(conn));

            services.AddMvc();

            services.AddSingleton(provider => Configuration);
            services.AddSingleton<IMessageService, ConfigurationMessageService>();

            //create instances of the SqlVideoData class
            //changed the method from AddSingleton to AddScoped for the service to work with Entity Framework
            services.AddScoped<IVideoData, SqlVideoData>();

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<VideoDbContext>();



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        
      // NOTORIOUS MIDDLEWARE 
         
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IMessageService msg)
        {
            app.UseAuthentication();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // app.UseStaticFiles();
            //app.UseMvcWithDefaultRoute();

            app.UseMvc(routes =>      /// Convention-Based Routing
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });



            app.Run(async (context) =>
            {
                 //var message = Configuration["Message"];
                await context.Response.WriteAsync(msg.GetMessage());
            });
        }
    }
}
