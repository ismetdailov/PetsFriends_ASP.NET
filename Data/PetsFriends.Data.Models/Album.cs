namespace PetsFriends.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using PetsFriends.Data.Common.Models;

    public class Album : BaseDeletableModel<int>
    {
        public Album()
        {
            this.Pictures = new HashSet<Picture>();
        }

        [Required]
        public string Name { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<Picture> Pictures { get; set; }
    }
}
