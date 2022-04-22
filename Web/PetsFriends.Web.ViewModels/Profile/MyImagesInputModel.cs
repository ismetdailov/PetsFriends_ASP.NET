using Microsoft.AspNetCore.Http;
using PetsFriends.Data.Models;
using PetsFriends.Web.ViewModels.Post;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsFriends.Web.ViewModels.Profile
{
    public class MyImagesInputModel
    {
        //[MaxLength(100)]
        //public string Name { get; set; }

        [MaxLength(15 * 1024 * 1024)]
        public ICollection<IFormFile> ProfilePicture { get; set; }

        [MaxLength(15 * 1024 * 1024)]
        public ICollection<IFormFile> CoverPictureLeft { get; set; }

        [MaxLength(15 * 1024 * 1024)]
        public ICollection<IFormFile> CoverPictureRight { get; set; }

        //public virtual ICollection<IFormFile> Pictures { get; set; }
    }
}
