using PetsFriends.Data.Common.Models;

using System;

namespace PetsFriends.Data.Models
{
    public class Picture : BaseDeletableModel<string>
    {
        public Picture()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public byte[] PhotoAsBytes { get; set; }

        public int? PostId { get; set; }

        public Post Post { get; set; }

        public string Extension { get; set; }

        public bool IsProfilePictuire { get; set; } = false;

        public bool IsCoverPictuireLeft { get; set; } = false;

        public bool IsCoverPictuireRight { get; set; } = false;

        public string RemoteImageUrl { get; set; }

        public int? AlbumId { get; set; }

        public Album Album { get; set; }

        public string AddedByPetId { get; set; }

        public ApplicationUser AddedByPet { get; set; }
    }
}
