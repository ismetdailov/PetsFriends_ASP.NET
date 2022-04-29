using PetsFriends.Data.Models;
using PetsFriends.Web.ViewModels.Home;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsFriends.Web.ViewModels.Search
{
    public class SearchViewModel
    {


        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}
