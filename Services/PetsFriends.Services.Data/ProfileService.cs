using Microsoft.AspNetCore.Authorization;
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
using PetsFriends.Services.Mapping;

namespace PetsFriends.Services.Data
{
    public class ProfileService : IProfileService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> usersRepository;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IDeletableEntityRepository<ProfilePicture> profilePictureRepository;
        private readonly IDeletableEntityRepository<CoverPictureLeft> coverLeftRepository;
        private readonly IDeletableEntityRepository<CoverPictureRight> coverRightRepository;

        public ProfileService(IDeletableEntityRepository<ApplicationUser> usersRepository,
            UserManager<ApplicationUser> userManager,
            IDeletableEntityRepository<ProfilePicture> profilePictureRepository,
            IDeletableEntityRepository<CoverPictureLeft> coverLeftRepository,
            IDeletableEntityRepository<CoverPictureRight> coverRightRepository)
        {
            this.usersRepository = usersRepository;
            this.userManager = userManager;
            this.profilePictureRepository = profilePictureRepository;
            this.coverLeftRepository = coverLeftRepository;
            this.coverRightRepository = coverRightRepository;
        }

        public T GetById<T>(string id)
        {
                var users = this.usersRepository.AllAsNoTracking()
                    .Where(x => x.UserName == id)
                    .To<T>().FirstOrDefault();

                return users;
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
                               await profilePictureRepository.AddAsync(profilePicture);
                                await profilePictureRepository.SaveChangesAsync();
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
                                await coverLeftRepository.AddAsync(coverPictureLeft);
                                await coverLeftRepository.SaveChangesAsync();
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
                                    User = user,
                                };
                                user.coverPicturesRight.Add(coverPictureRight);
                                await coverRightRepository.AddAsync(coverPictureRight);
                                await coverRightRepository.SaveChangesAsync();

                            }
                        }
                    }
                }
            }
            //await userManager.UpdateAsync(user);
            //this.usersRepository.Update(user);

            //this.usersRepository.SaveChangesAsync();
        }
    }
}
