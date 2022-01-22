namespace PetsFriends.Data.Models
{

    using PetsFriends.Data.Common.Models;

    public class Notification : BaseDeletableModel<int>
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
