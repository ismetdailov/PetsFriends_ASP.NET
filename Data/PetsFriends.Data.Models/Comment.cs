namespace PetsFriends.Data.Models
{
    using System.Collections.Generic;

    using PetsFriends.Data.Common.Models;

    public class Comment : BaseDeletableModel<int>
    {
        public Comment()
        {
            this.Comments = new HashSet<Comment>();
            this.Likes = new HashSet<Like>();
        }

        public int PostId { get; set; }

        public virtual Post Post { get; set; }

        public int? ParentId { get; set; }

        public virtual Comment Parent { get; set; }

        public int LikesCount => this.Likes.Count;

        public string Content { get; set; }

        public string UserId { get; set; }

        public int CommentsCount => this.Comments.Count;

        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<Like> Likes { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

    }
}
