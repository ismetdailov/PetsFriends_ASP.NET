namespace PetsFriends.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using PetsFriends.Data.Common.Models;

    public class City : BaseDeletableModel<string>
    {
        public City()
        {
            this.Id = Guid.NewGuid().ToString();
            this.PetsUsers = new HashSet<ApplicationUser>();
        }

        [Required]
        public string Name { get; set; }

        public Country Country { get; set; }

        public ICollection<ApplicationUser> PetsUsers { get; set; }
    }
}
