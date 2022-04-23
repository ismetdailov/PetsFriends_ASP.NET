using AutoMapper;
using PetsFriends.Data.Models;
using PetsFriends.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsFriends.Web.ViewModels.Friend
{
    public class FindFriendViewModel : IMapFrom<ApplicationUser>, IHaveCustomMappings
    {
        public ApplicationUser User { get; set; }
        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<ApplicationUser, FindFriendViewModel>()
                .ForMember(x => x.User, opt =>
                    opt.MapFrom(x =>
                        x.ProfilePictures.FirstOrDefault() != null ?
                        x.UserName : null)).ForAllMembers(x=>x.Ignore());
        }
    }
}
