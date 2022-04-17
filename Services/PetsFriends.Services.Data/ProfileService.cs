using PetsFriends.Data.Common.Repositories;
using PetsFriends.Data.Models;
using PetsFriends.Web.ViewModels.Profile;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsFriends.Services.Data
{
    public class ProfileService : IProfileService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> usersRepository;

        public ProfileService(IDeletableEntityRepository<ApplicationUser> usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        public async Task UploadProfileOrCoverImage(ProfileAndCoverPicturesInputModel createInput, string petId)
        {
            var user = this.usersRepository.AllAsNoTracking().FirstOrDefault(x => x.Id == petId);

            if (createInput.ProfilePicture != null)
            {
                if (createInput.ProfilePicture.Length > 0)
                {
                    using (var stream = new MemoryStream())
                    {
                        await createInput.ProfilePicture.CopyToAsync(stream);
                        user.ProfilePicture = stream.ToArray();
                    }
                }
            }
            else if (createInput.CoverPictureLeft != null || createInput.CoverPictureRight != null)
            {
                if (createInput.CoverPictureLeft != null)
                {
                    if (createInput.CoverPictureLeft.Length > 0)
                    {
                        using (var stream = new MemoryStream())
                        {
                            await createInput.CoverPictureLeft.CopyToAsync(stream);
                            user.CoverPictureLeft = stream.ToArray();
                        }
                    }
                }
                else
                {
                    if (createInput.CoverPictureRight.Length > 0)
                    {
                        using (var stream = new MemoryStream())
                        {
                            await createInput.CoverPictureRight.CopyToAsync(stream);
                            user.CoverPictureRight = stream.ToArray();
                        }
                    }
                }
            }

            await this.usersRepository.SaveChangesAsync();
        }
    }
}
