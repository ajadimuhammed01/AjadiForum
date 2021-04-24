using AjadiForum.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AjadiForum.Data
{
    public interface IApplicationUser
    {
        ApplicationUser GetById(string id);
        IEnumerable<ApplicationUser> GetAll();
        Task SetProfileImageAsync(string id, Uri uri);
        Task IncrementRating(string id, Type type);
    }
}
