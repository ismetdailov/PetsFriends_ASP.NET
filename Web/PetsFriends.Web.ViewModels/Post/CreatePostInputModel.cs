namespace PetsFriends.Web.ViewModels.Post
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http;
    using PetsFriends.Data.Models;
    using PetsFriends.Web.ViewModels.Profile;

    public class CreatePostInputModel
    {
        public CreatePostInputModel()
        {
            this.Likes = new HashSet<Like>();
            this.Comments = new HashSet<Comment>();
        }

        [Required]
        [MaxLength(100000)]
        public string ContentPost { get; set; }

        [MaxLength(1 * 1024 * 1024)]
        public ICollection<IFormFile> Pictures { get; set; }

        public DateTime UpdatedOn { get; set; }

        public DateTime DateTimeCreate { get; set; }

        public int LikesCount { get; set; }

        public int ComentsCount { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<Like> Likes { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
