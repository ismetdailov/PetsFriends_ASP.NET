using PetsFriends.Web.ViewModels.Friend;
using PetsFriends.Web.ViewModels.Post;
using PetsFriends.Web.ViewModels.Profile;
using PetsFriends.Web.ViewModels.Search;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsFriends.Web.ViewModels.Home
{
    public class PostListViewModel : CreatePostInputModel
    {
        public PostListViewModel()
        {
            //this.SearchLists = new HashSet<SearchListViewModel>();

            this.Posts = new HashSet<IndexPostsViewModel>();
            this.Friends = new HashSet<UserByIdViewMoodel>();

        }

        public CreatePostInputModel CreatePostInput { get; set; }

        public ICollection<SearchViewModel> SearchLists { get; set; }

        public IEnumerable<IndexPostsViewModel> Posts { get; set; }

        public IEnumerable<UserByIdViewMoodel> Friends { get; set; }

        public MyImagesInputModel MyImagesInputModels { get; set; }
    }
}
