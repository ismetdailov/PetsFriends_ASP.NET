namespace PetsFriends.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using PetsFriends.Data.Common.Repositories;
    using PetsFriends.Data.Models;
    using PetsFriends.Web.ViewModels.Search;

    public class SearchService : ISearchService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> usersRepository;

        public SearchService(IDeletableEntityRepository<ApplicationUser> usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        public async Task SearchAsync(SearchListViewModel searchModel, string petId)
        {
            var user = this.usersRepository.AllAsNoTracking().FirstOrDefault(x => x.Id == petId);
            if (searchModel.Username != null)
            {
                var searchUsers = this.usersRepository.AllAsNoTracking()
                       .Where(x => x.UserName.ToLower().Contains(searchModel.Username.ToLower().Trim()))
                       .Skip(0)
                       .Take(10)
                       .ToList();
                if (searchUsers.Contains(user))
                {
                    searchUsers.Remove(user);
                }
            }
        }
    }
}
