namespace PetsFriends.Data.Models.Enum
{

    using PetsFriends.Data.Common.Models;

    public class InformationAboutPet : BaseDeletableModel<int>
    {
        public string Country { get; set; }

        public string City { get; set; }

        public int? YearOld { get; set; }

        public string MyHobby { get; set; }

        public string ImLike { get; set; }

        public Gender Gender { get; set; }

        public string ImHate { get; set; }

        public string ImLove { get; set; }

        public string ImIterestedfor { get; set; }

        public string MyOwnerIs { get; set; }

        public string MyFavoriteFood { get; set; }

        public string MyfamilyUrl { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

    }
}
