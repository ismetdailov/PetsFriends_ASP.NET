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
    internal class InformationAboutPetInputModel
    {
        [MaxLength(1000)]
        public Country Country { get; set; }

        [MaxLength(1000)]
        public City City { get; set; }

        // because turtles live longer than other pets UNFORTUNATELY

        [Range(0,600)]
        public int? YearOld { get; set; }

        [MaxLength(10000)]
        public string MyHobby { get; set; }

        [MaxLength(50000)]
        public string ImLike { get; set; }

        public Gender Gender { get; set; }

        [MaxLength(10000)]
        public string ImHate { get; set; }

        [MaxLength(10000)]
        public string ImLove { get; set; }

        [MaxLength(10000)]
        public string ImIterestedfor { get; set; }

        [MaxLength(10000)]
        public string MyOwnerIs { get; set; }

        [MaxLength(10000)]
        public string MyFavoriteFood { get; set; }

        [MaxLength(1000)]
        public string MyfamilyUrl { get; set; }

    }
}
