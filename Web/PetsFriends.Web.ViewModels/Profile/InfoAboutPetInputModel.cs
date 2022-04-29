using PetsFriends.Data.Models;
using PetsFriends.Data.Models.Enum;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsFriends.Web.ViewModels.Profile
{
    public class InfoAboutPetInputModel
    {
        [MaxLength(1000)]
        [Display(Name = "Add your country")]
        public string Country { get; set; }

        [MaxLength(1000)]
        [Display(Name = "Add your ciry")]
        public string City { get; set; }

        // because turtles live longer than other pets UNFORTUNATELY

        [Range(0, 600)]
        [Display(Name = "Add your years old")]
        public int? YearOld { get; set; }

        [MaxLength(10000)]
        [Display(Name = "Add your hobi")]
        public string MyHobby { get; set; }

        [MaxLength(50000)]
        [Display(Name = "Add what you are like")]
        public string ImLike { get; set; }

        [Display(Name = "Add your gender")]
        public Gender Gender { get; set; }

        [MaxLength(10000)]
        public string ImHate { get; set; }

        [MaxLength(10000)]
        [Display(Name = "What you love?")]
        public string ImLove { get; set; }

        [MaxLength(10000)]
        [Display(Name = "What is yours interested?")]
        public string ImIterestedfor { get; set; }

        [MaxLength(10000)]
        public string MyOwnerIs { get; set; }

        [MaxLength(10000)]

        [Display(Name = "What is your favorite food?")]
        public string MyFavoriteFood { get; set; }

        [MaxLength(1000)]
        [Display(Name = "Add contact whith your owner")]
        public string MyfamilyUrl { get; set; }

        [Display(Name = "Add your  birth day")]
        public DateTime BirthDate { get; set; }
        public ApplicationUser Pet { get; set; }

    }
}
