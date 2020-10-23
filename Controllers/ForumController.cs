using Microsoft.AspNetCore.Mvc;
using AjadiForum.Data;
using System.Collections.Generic;
using AjadiForum.Models;
using System.Linq;
using AjadiForum.Models.ViewModels;

namespace AjadiForum.Controllers
{
    public class ForumController : Controller
    {
        private readonly IForum _forumService;
        private readonly IPost _postService;

        public ForumController(IForum forumService, IPost postService)
        {
            _forumService = forumService;
            _postService = postService;
        }

        public IActionResult Index()
        {
             var forums = _forumService.GetAll()
                        .Select(Forum => new ForumListingModel
                        {
                            Id = Forum.Id,
                            Name = Forum.Title,
                            Description = Forum.Description
                        });
            var model = new ForumIndexModel
            {
                ForumList = forums
            };
            
            return View(model); 
        }

        public IActionResult Topic(int id)
        {
            var forum = _forumService.GetById(id);
            var posts = _postService.GetPostsByForum(id);

            var postListings = posts.Select(post => new PostListingModel {
                 Id = post.Id,
                 AuthorId = post.User.Id,
                 AuthorRating = post.User.Rating,
                 Title = post.Title,
                 DatePosted = post.Created.ToString(),
                 RepliesCount = post.Replies.Count(),
                // Forum = BuildForumListing(post)
            });

            return View();
        }

       /*  private ForumListingModel BuildForumListing(Post post)
        {
        
        } */
    }
}