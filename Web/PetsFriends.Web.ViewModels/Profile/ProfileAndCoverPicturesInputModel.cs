using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsFriends.Web.ViewModels.Profile
{
    public class ProfileAndCoverPicturesInputModel
    {
        public IFormFile ProfilePicture { get; set; }

        public IFormFile CoverPictureLeft { get; set; }

        public IFormFile CoverPictureRight { get; set; }
    }
}
