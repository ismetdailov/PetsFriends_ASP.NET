namespace PetsFriends.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using PetsFriends.Data.Common.Models;

    public class Notification : BaseDeletableModel<int>
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
