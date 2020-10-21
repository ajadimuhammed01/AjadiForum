using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AjadiForum.Models.ViewModels
{
    public class ForumIndexModel
    {
        public IEnumerable<ForumListingModel> ForumList { get; set; }
    }
}
