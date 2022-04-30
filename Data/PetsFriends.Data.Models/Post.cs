namespace PetsFriends.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using PetsFriends.Data.Common.Models;

    public class Post : BaseDeletableModel<int>
    {
        public Post()
        {
            this.Comments = new HashSet<Comment>();
            this.Likes = new HashSet<Like>();
            this.Picture = new HashSet<Picture>();
        }

        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]

        public DateTime UpdatedOn { get; set; }

        public DateTime CreateDateTime { get; set; }

        public int LikesCount => this.Likes.Count;

        public int ComentsCount => this.Comments.Count;

        public string ImageOrVideoUrl { get; set; }

        public ICollection<Picture> Picture { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<Like> Likes { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
