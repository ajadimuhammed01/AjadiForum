using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AjadiForum.Models;

namespace AjadiForum.Data
{
    public interface IPost
    {
        Post GetById(int id);
        IEnumerable<Post> GetAll();
        IEnumerable<Post> GetFilteredPosts(Forum forum,string searchQuery);
        IEnumerable<Post> GetFilteredPosts(string searchQuery);
        IEnumerable<Post> GetPostsByForum(int id);
        IEnumerable<Post> GetLatestPosts(int id);
        Task Add(Post post);
        Task Delete(int id);
        Task EditPostContent(int id, string newContent);
        string GetForumImageUrl(int id);
      
        //Task AddReply(PostReply reply);
    }
}
