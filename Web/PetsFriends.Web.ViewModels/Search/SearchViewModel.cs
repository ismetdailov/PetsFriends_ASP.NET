namespace PetsFriends.Web.ViewModels.Search
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using PetsFriends.Data.Models;
    using PetsFriends.Web.ViewModels.Home;

    public class SearchViewModel
    {
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}
