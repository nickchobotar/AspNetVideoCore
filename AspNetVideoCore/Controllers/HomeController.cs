﻿using AspNetVideoCore.Entities;
using AspNetVideoCore.Services;
using AspNetVideoCore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace AspNetVideoCore.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        private IVideoData _videos;  //_videos This field will hold the data fetched from the service.

        public HomeController(IVideoData videos)
            {
                _videos = videos;
            }

        //using LINQ Select method in the Index action to convert each video into a VideoViewModel object, and store it in the model field "var model".
        //fetch the video from the _videos collection using its id, and then convert the genre id to the name for the corresponding value in the Genres enum.
        [AllowAnonymous]
        public ViewResult Index()
        {
            var model = _videos.GetAll().Select(video =>   // GetAll() from IVideoData  -- > IEnumerable<Video> GetAll();          
                new VideoViewModel
                {
                    Id = video.Id,
                    Title = video.Title,
                    Genre = video.Genre.ToString()
                }
            );

            return View(model);
        }
        
        // Allows to search by Id parameter that will match a video id from the URL or the request data.
        // The Details view will display a single video in the browser, based on the id sent to the Details action
        public IActionResult Details (int id)  
        {
            var model = _videos.Get(id);  //  Video Get(int id) from IVideoData

            // if wrong model id is entered page is redirected to index page
            if (model == null)
            {
                return RedirectToAction("Index");
            }
            return View(
              new VideoViewModel
              {                  
                  Id = model.Id,
                  Title = model.Title,
                  Genre =  model.Genre.ToString()                  
              }
              
            );             
        }
        
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(VideoEditViewModel model)
        {
            if (ModelState.IsValid)
            {                
                var video = new Video
                {
                    Title = model.Title,
                    Genre = model.Genre
                };

                _videos.Add(video);  // Add is the method from IVideoData  ---  void Add(Video newVideo);
                _videos.Commit(); // ???

                return RedirectToAction("Details", new { id = video.Id });
            }
            return View();

        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var video = _videos.Get(id);
            if (video == null) return RedirectToAction("Index");
            return View(video);
        }


        [HttpPost]
        public IActionResult Edit(int id, VideoEditViewModel model)
        {
            var video = _videos.Get(id);
            if (video == null || !ModelState.IsValid) return View(model);
            video.Title = model.Title;
            video.Genre = model.Genre;
            _videos.Commit();
            return RedirectToAction("Details", new { id = video.Id });
        }




    }







}

    