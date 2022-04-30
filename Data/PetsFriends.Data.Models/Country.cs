namespace PetsFriends.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using PetsFriends.Data.Common.Models;

    public class Country : BaseDeletableModel<int>
    {
        public Country()
        {
            this.Cities = new HashSet<City>();
            this.PetUsers = new HashSet<ApplicationUser>();
        }

        [Required]
        public string Name { get; set; }

        public ICollection<City> Cities { get; set; }

        public ICollection<ApplicationUser> PetUsers { get; set; }
    }
}
