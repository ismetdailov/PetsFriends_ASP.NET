using Microsoft.AspNetCore.Http;
using PetsFriends.Data.Models;
using PetsFriends.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace PetsFriends.Web.ViewModels.Home
{
    public class IndexPostsViewModel : IMapFrom<PetsFriends.Data.Models.Post>
    {
        public IndexPostsViewModel()
        {
            this.Picture = new HashSet<Picture>();
        }
        public string Content { get; set; }

        public ICollection<Picture> Picture { get; set; }

    }
}
