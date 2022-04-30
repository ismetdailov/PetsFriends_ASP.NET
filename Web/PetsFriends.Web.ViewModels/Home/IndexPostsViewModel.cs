namespace PetsFriends.Web.ViewModels.Home
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http;
    using PetsFriends.Data.Models;
    using PetsFriends.Services.Mapping;

    public class IndexPostsViewModel : IMapFrom<PetsFriends.Data.Models.Post>
    {
        public IndexPostsViewModel()
        {
            this.Picture = new HashSet<Picture>();
            this.Likes = new HashSet<Like>();
            this.Comments = new HashSet<Comment>();
        }

        public int Id { get; set; }

        public string Content { get; set; }

        public string UserId { get; set; }

        public PetsFriends.Data.Models.Post Post { get; set; }

        public virtual ApplicationUser User { get; set; }

        public ICollection<Picture> Picture { get; set; }

        public DateTime UpdatedOn { get; set; }

        public DateTime DateTimeCreate { get; set; }

        public int LikesCount => this.Likes.Count;

        public int ComentsCount => this.Comments.Count;

        public virtual ICollection<Like> Likes { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
