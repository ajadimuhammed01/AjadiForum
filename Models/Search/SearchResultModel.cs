using AjadiForum.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AjadiForum.Models.Search
{
    public class SearchResultModel
    {
        public IEnumerable<PostListingModel> Posts { get; set; }
        public string searchQuery { get; set; } 
        public bool EmptySearchResults { get; set; }
    }
}
