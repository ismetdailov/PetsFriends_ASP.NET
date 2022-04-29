using PetsFriends.Data.Common.Repositories;
using PetsFriends.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetsFriends.Services.Mapping;
namespace PetsFriends.Services.Data
{
    public class FriendService : IFriendService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> usersRepository;

        public FriendService(IDeletableEntityRepository<ApplicationUser> usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        public IEnumerable<T> GetAllUsers<T>(string id)
        {
            return this.usersRepository.AllAsNoTracking().Where(x => x.Id != id).OrderByDescending(x => x.CreatedOn).To<T>().ToList();
        }

    }
}
