using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsFriends.Web.ViewModels.Home
{
    public class PostListViewModel
    {
        public IEnumerable<IndexPostsViewModel> Posts { get; set; }
    }
}
