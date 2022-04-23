using PetsFriends.Web.ViewModels.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsFriends.Services.Data
{
    public interface ISearchService
    {
        Task SearchAsync(SearchListViewModel searchModel, string petId);
    }
}
