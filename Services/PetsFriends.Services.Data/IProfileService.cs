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

        T GetById<T>(string id);
    }
}
