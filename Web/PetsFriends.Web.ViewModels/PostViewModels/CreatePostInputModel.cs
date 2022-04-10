namespace PetsFriends.Web.ViewModels.Post
{
    using Microsoft.AspNetCore.Http;
    using PetsFriends.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public  class CreatePostInputModel
    {
        [Required]
        [MaxLength(100000)]
        public string ContentPost { get; set; }

        [MaxLength(10 * 1024 * 1024)]
        public ICollection<IFormFile> Pictures { get; set; }

    }
}
