namespace PetsFriends.Data.Models
{
    using System.Collections.Generic;

    using PetsFriends.Data.Common.Models;

    public class Post : BaseDeletableModel<int>
    {
        public Post()
        {
            this.Comments = new HashSet<Comment>();
            this.Likes = new HashSet<Like>();
        }

        public string Title { get; set; }

        public string Content { get; set; }

        public int LikesCount => this.Likes.Count;

        public int ComentsCount => this.Comments.Count;

        public string ImageOrVideoUrl { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<Like> Likes { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

    }
}
