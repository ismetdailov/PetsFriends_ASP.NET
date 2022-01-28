namespace PetsFriends.Data.Models
{
    using PetsFriends.Data.Common.Models;

    internal class UsersFriends : BaseDeletableModel<int>
    {
        public int UserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public int FriendId { get; set; }

        public Friend Friends { get; set; }
    }
}
