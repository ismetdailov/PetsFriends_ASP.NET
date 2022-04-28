using Microsoft.AspNetCore.Http;
using PetsFriends.Data.Models;
using PetsFriends.Web.ViewModels.Home;
using PetsFriends.Web.ViewModels.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsFriends.Services.Data
{
    public interface IProfileService
    {
        Task UploadProfileOrCoverImage(MyImagesInputModel createInput, string petId);

        Task AddInformationAboutPet(InfoAboutPetInputModel createInput, string petId);
        T GetById<T>(string id);

        ProfilePicture TakeProfilePicture(string petId);

        CoverPictureLeft TakeCoverPictureLeft(string petId);

        CoverPictureRight TakeCoverPictureRight(string petId);
    }
}
