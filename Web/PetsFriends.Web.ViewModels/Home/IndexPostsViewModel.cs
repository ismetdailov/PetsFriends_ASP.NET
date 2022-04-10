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
    public class IndexPostsViewModel
    {
        public int id { get; set; }

        public string PostContent { get; set; }

        public ICollection<Picture> Pictures { get; set; }

    }
}
