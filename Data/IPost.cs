using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AjadiForum.Models
namespace AjadiForum.Data
{
    public class IPost
    {
        Post GetById(int id);
        IEnumerable<Post> GetAll();
        IEnumerable<Post> GetFilteredPosts(string searchQuery);

        Task Add(Post post);
        Task Delete(int id);
        Task EditPostContent(int id, string newContent);
        //Task AddReply(PostReply reply);
    }
}
