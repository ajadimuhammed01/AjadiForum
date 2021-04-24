using AjadiForum.Data;
using AjadiForum.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AjadiForum.Services
{
    public class PostService : IPost
    {
        private readonly ApplicationDbContext _context;

        public PostService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task Add(Post post)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task EditPostContent(int id, string newContent)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetAll()
        {
            return _context.Posts
                .Include(post => post.User)
                .Include(post => post.Replies).ThenInclude(reply => reply.User)
                .Include(post => post.Forum);

        }

        public Post GetById(int id)
        {
            return _context.Posts.Where(post => post.Id == id)
                .Include(post => post.User)
                .Include(post => post.Replies)
                      .ThenInclude(reply => reply.User)
                .Include(post => post.Forum)
                .First();
        }

        public IEnumerable<Post> GetFilteredPosts(Forum forum, string searchQuery)
        {

            return string.IsNullOrEmpty(searchQuery) 
                ? forum.Posts 
                : /*otherwise*/ forum.Posts
                .Where(post => post.Title.Contains(searchQuery) 
                || post.Content.Contains(searchQuery));
        }

        public IEnumerable<Post> GetFilteredPosts(string searchQuery)
        {
            return GetAll().Where(post
                => post.Title.Contains(searchQuery)
                 || post.Content.Contains(searchQuery));
        }

        public string GetForumImageUrl(int id)
        {
            var post = GetById(id);
            return post.Forum.ImageUrl;
        }

        public IEnumerable<Post> GetLatestPosts(int count)
        {
            var allPosts = GetAll().OrderByDescending(post => post.Created);
            return allPosts.Take(count);
        }

        public IEnumerable<Post> GetPostsByForum(int id)
        {
            return 
            _context.Forums.Where(forum => forum.Id == id).First().Posts;
        }
    }
}
