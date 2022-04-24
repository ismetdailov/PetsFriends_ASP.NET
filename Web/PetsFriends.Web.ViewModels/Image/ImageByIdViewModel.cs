using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetsFriends.Data.Models;

using System.Threading.Tasks;
using PetsFriends.Services.Mapping;
using AutoMapper;

namespace PetsFriends.Web.ViewModels.Image
{
    public class ImageByIdViewModel : IMapFrom<Picture>, IHaveCustomMappings
    {
        public byte[] PhotoAsBytes { get; set; }

        public PetsFriends.Data.Models.Post Post { get; set; }

        public string Extension { get; set; }

        public bool IsProfilePictuire { get; set; } = false;

        public bool IsCoverPictuireLeft { get; set; } = false;

        public bool IsCoverPictuireRight { get; set; } = false;

        public string RemoteImageUrl { get; set; }

        public Album Album { get; set; }

        public string AddedByPetId { get; set; }

        public ApplicationUser AddedByPet { get; set; }
        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<ApplicationUser, ImageByIdViewModel>();
        }
    }
}
