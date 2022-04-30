namespace PetsFriends.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using PetsFriends.Web.ViewModels.Search;

    public interface ISearchService
    {
        Task SearchAsync(SearchListViewModel searchModel, string petId);
    }
}
