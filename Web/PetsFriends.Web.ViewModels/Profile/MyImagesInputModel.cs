namespace PetsFriends.Web.ViewModels.Profile
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http;
    using PetsFriends.Data.Models;
    using PetsFriends.Web.ViewModels.Post;

    public class MyImagesInputModel
    {
        [MaxLength(15 * 1024 * 1024)]
        public ICollection<IFormFile> ProfilePicture { get; set; }

        [MaxLength(15 * 1024 * 1024)]
        public ICollection<IFormFile> CoverPictureLeft { get; set; }

        [MaxLength(15 * 1024 * 1024)]
        public ICollection<IFormFile> CoverPictureRight { get; set; }
    }
}
