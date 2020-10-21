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

        public ForumController(IForum forumService)
        {
            _forumService = forumService;
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
    }
}