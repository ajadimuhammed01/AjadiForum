using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AjadiForum.Models;
using AjadiForum.Data;
using AjadiForum.Models.ViewModels;

namespace AjadiForum.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPost _postService;

        public HomeController(IPost postService)
        {
            _postService = postService;
        }

        public IActionResult Index()
        {
            var model = BuildHomeIndexModel();
            return View(model);
        }

        private HomeIndexModel BuildHomeIndexModel()
        {
            var latest = _postService.GetLatestPosts(10);

            var posts = latest.Select(post => new PostListingModel
            {
                Id = post.Id,
                Title = post.Title,
                AuthorName = post.User.UserName,
                AuthorId = post.User.Id,
                AuthorRating = post.User.Rating,
                DatePosted = post.Created.ToString(),
                ForumName = post.Forum.Title,
                Content = post.Content,
               // ForumImageUrl = _postService.GetForumImageUrl(post.Id),
                ForumImageUrl = post.Forum.ImageUrl,
                ForumId = post.Forum.Id
            });

            return new HomeIndexModel()
            {
                LatestPosts = posts
            };
        }

        
       
    }
}
