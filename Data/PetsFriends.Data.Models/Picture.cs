using PetsFriends.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsFriends.Data.Models
{
    public class Picture : BaseDeletableModel<string>
    {
        public Picture()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Extension { get; set; }

        public bool IsProfilePictuire { get; set; } = false;

        public bool IsCoverPictuire { get; set; } = false;

        public string RemoteImageUrl { get; set; }

        public int AlbumId { get; set; }

        public string AddedByPetId { get; set; }

        public Album Album { get; set; }

        public ApplicationUser AddedByPet { get; set; }
    }
}
