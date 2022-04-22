// ReSharper disable VirtualMemberCallInConstructor
namespace PetsFriends.Data.Models
{
    using System;
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Identity;
    using PetsFriends.Data.Common.Models;
    using PetsFriends.Data.Models.Enum;

    public class ApplicationUser : IdentityUser, IAuditInfo, IDeletableEntity
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Roles = new HashSet<IdentityUserRole<string>>();
            this.Claims = new HashSet<IdentityUserClaim<string>>();
            this.Logins = new HashSet<IdentityUserLogin<string>>();
            this.Posts = new HashSet<Post>();
            this.Friends = new HashSet<Friend>();
            this.Notifications = new HashSet<Notification>();
            this.Pictures = new HashSet<Picture>();
            this.Albums = new HashSet<Album>();
            this.ProfilePictures = new HashSet<ProfilePicture>();
            this.CoverPicturesLeft = new HashSet<CoverPictureLeft>();
            this.coverPicturesRight = new HashSet<CoverPictureRight>();
        }

        // Audit info
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
        public  ICollection<ProfilePicture> ProfilePictures { get; set; }

        public ICollection<CoverPictureLeft> CoverPicturesLeft { get; set; }

        public ICollection<CoverPictureRight> coverPicturesRight { get; set; }


        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }

        public virtual ICollection<Post> Posts { get; set; }

        public virtual ICollection<Friend> Friends { get; set; }

        public virtual ICollection<Notification> Notifications { get; set; }

        public virtual ICollection<Album> Albums { get; set; }

        public virtual ICollection<Picture> Pictures { get; set; }

    }
}
