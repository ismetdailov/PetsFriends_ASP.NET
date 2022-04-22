using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<ApplicationUser> userManager;

        public ProfileService(IDeletableEntityRepository<ApplicationUser> usersRepository,UserManager<ApplicationUser> userManager)
        {
            this.usersRepository = usersRepository;
            this.userManager = userManager;
        }

        public async Task UploadProfileOrCoverImage(MyImagesInputModel createInput, string petId)
        {
            var user = this.usersRepository.AllAsNoTracking().FirstOrDefault(x => x.Id == petId);
            if (createInput.ProfilePicture != null)
            {
                foreach (var formFile in createInput.ProfilePicture)
                {
                    if (formFile != null)
                    {
                        if (formFile.Length > 0)
                        {
                            using (var stream = new MemoryStream())
                            {
                                await formFile.CopyToAsync(stream);
                                var profilePicture = new ProfilePicture
                                {
                                    Bytes = stream.ToArray(),
                                    CreatedOn = DateTime.Now,
                                    UserId = user.Id,
                                };
                                user.ProfilePictures.Add(profilePicture);
                            }
                        }
                    }
                }
            }

            else if (createInput.CoverPictureLeft != null)
            {
                foreach (var formFile in createInput.CoverPictureLeft)
                {
                    if (formFile != null)
                    {
                        if (formFile.Length > 0)
                        {
                            using (var stream = new MemoryStream())
                            {
                                await formFile.CopyToAsync(stream);
                                var coverPictureLeft = new CoverPictureLeft
                                {
                                    Bytes = stream.ToArray(),
                                    CreatedOn = DateTime.Now,
                                    UserId = user.Id,
                                };
                                user.CoverPicturesLeft.Add(coverPictureLeft);
                            }
                        }
                    }
                }
            }
            else
            {
                foreach (var formFile in createInput.CoverPictureRight)
                {
                    if (formFile != null)
                    {
                        if (formFile.Length > 0)
                        {
                            using (var stream = new MemoryStream())
                            {
                                await formFile.CopyToAsync(stream);
                                var coverPictureRight = new CoverPictureRight
                                {
                                    Bytes = stream.ToArray(),
                                    CreatedOn = DateTime.Now,
                                    UserId = user.Id,
                                };
                                user.coverPicturesRight.Add(coverPictureRight);

                            }
                        }
                    }
                }
            }
            //await userManager.UpdateAsync(user);
            //this.usersRepository.Update(user);
            await this.usersRepository.SaveChangesAsync();
        }
    }
}
