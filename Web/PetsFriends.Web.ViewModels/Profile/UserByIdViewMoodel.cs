using AutoMapper;
using Microsoft.AspNetCore.Identity;
using PetsFriends.Data.Models;
using PetsFriends.Data.Models.Enum;
using PetsFriends.Services.Mapping;
using PetsFriends.Web.ViewModels.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsFriends.Web.ViewModels.Profile
{
    public class UserByIdViewMoodel : IMapFrom<ApplicationUser>, IHaveCustomMappings
    {
        //public string Id { get; set; }
        public string UserName { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        // Deletable entity
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public Country Country { get; set; }

        public City City { get; set; }

        public DateTime BirthDate { get; set; }

        public DateTime RegisteredOn { get; set; }

        public Gender Gender { get; set; }

        public int FriendsCount => this.Friends.Count;

        public ICollection<ProfilePicture> ProfilePictures { get; set; }

        public ICollection<CoverPictureLeft> CoverPicturesLeft { get; set; }

        public ICollection<CoverPictureRight> CoverPicturesRight { get; set; }

        public ICollection<Group> Groups { get; set; }

        //public Messages Message { get; set; }
        public UserMessages UserMessages { get; set; }

        //public ICollection<Messages> Messages { get; set; }

        public ICollection<GroupOnUser> MyGroups { get; set; }

        //public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

        //public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        //public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }

        public virtual ICollection<PetsFriends.Data.Models.Post> Posts { get; set; }

        public virtual ICollection<PetsFriends.Data.Models.Friend> Friends { get; set; }

        public virtual ICollection<Notification> Notifications { get; set; }

        public virtual ICollection<Album> Albums { get; set; }

        public virtual ICollection<Picture> Pictures { get; set; }

        public PostListViewModel PostListViewModel { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<ApplicationUser, UserByIdViewMoodel>();
        }

    }
}
