namespace PetsFriends.Data.Models
{
    using PetsFriends.Data.Common.Models;

    public class Like : BaseDeletableModel<int>
    {
        public int PostId { get; set; }

        public Post Post { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

    }
}
