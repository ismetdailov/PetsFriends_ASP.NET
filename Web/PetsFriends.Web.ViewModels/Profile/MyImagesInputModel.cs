using Microsoft.AspNetCore.Http;
using PetsFriends.Data.Models;
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
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(10 * 1024 * 1024)]
        public IFormFile ProfilePicture { get; set; }

        [MaxLength(10 * 1024 * 1024)]
        public IFormFile CoverPictureLeft { get; set; }

        [MaxLength(10 * 1024 * 1024)]
        public IFormFile CoverPictureRight { get; set; }

        public virtual ICollection<IFormFile> Pictures { get; set; }
    }
}
