using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsFriends.Web.ViewModels.Search
{
    public class SearchListViewModel
    {
        public string Username { get; set; }
        public ICollection<SearchViewModel> Searches { get; set; }
    }
}
