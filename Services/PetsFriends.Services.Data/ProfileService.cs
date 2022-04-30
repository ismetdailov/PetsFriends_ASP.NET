namespace PetsFriends.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using PetsFriends.Data.Common.Repositories;
    using PetsFriends.Data.Models;
    using PetsFriends.Services.Mapping;
    using PetsFriends.Web.ViewModels.Home;
    using PetsFriends.Web.ViewModels.Profile;

    public class ProfileService : IProfileService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> usersRepository;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IDeletableEntityRepository<ProfilePicture> profilePictureRepository;
        private readonly IDeletableEntityRepository<CoverPictureLeft> coverLeftRepository;
        private readonly IDeletableEntityRepository<CoverPictureRight> coverRightRepository;
        private readonly IDeletableEntityRepository<InformationAboutPet> infoRepository;

        public ProfileService(
            IDeletableEntityRepository<ApplicationUser> usersRepository,
            UserManager<ApplicationUser> userManager,
            IDeletableEntityRepository<ProfilePicture> profilePictureRepository,
            IDeletableEntityRepository<CoverPictureLeft> coverLeftRepository,
            IDeletableEntityRepository<CoverPictureRight> coverRightRepository,
            IDeletableEntityRepository<InformationAboutPet> infoRepository)
        {
            this.usersRepository = usersRepository;
            this.userManager = userManager;
            this.profilePictureRepository = profilePictureRepository;
            this.coverLeftRepository = coverLeftRepository;
            this.coverRightRepository = coverRightRepository;
            this.infoRepository = infoRepository;
        }

        public async Task AddInformationAboutPet(InfoAboutPetInputModel createInput, string petId)
        {
            var user = await this.usersRepository.All().FirstOrDefaultAsync(x => x.Id == petId);
            if (user != null)
            {
                var informationAbout = new InformationAboutPet()
                {
                    YearOld = createInput.YearOld,
                    ImLove = createInput.ImLove,
                    ImLike = createInput.ImLike,
                    Country = new Country() { Name = createInput.Country },
                    Gender = createInput.Gender,
                    ImHate = createInput.ImHate,
                    ImIterestedfor = createInput.ImIterestedfor,
                    MyOwnerIs = createInput.MyOwnerIs,
                    MyFavoriteFood = createInput.MyFavoriteFood,
                    City = new City() { Name = createInput.City.ToString() },
                    MyHobby = createInput.MyHobby,
                };
                user.InformationAboutPet = informationAbout;
                this.usersRepository.Update(user);
                await this.usersRepository.SaveChangesAsync();
            }
        }

        public T GetById<T>(string id)
        {
            var users = this.usersRepository.AllAsNoTracking()
                .Where(x => x.UserName == id)
                .To<T>().FirstOrDefault();

            return users;
        }

        public UserByIdViewMoodel GetByIdList(string id)
        {
            var userbyId = new UserByIdViewMoodel
            {
                UserName = id,
            };
            return userbyId;
        }

        public async Task<T> GetUserById<T>(string id)
        {
            var users = this.usersRepository.AllAsNoTracking()
                .Where(x => x.UserName == id)
                .To<T>().FirstOrDefaultAsync();
            return await users;
        }

        public CoverPictureLeft TakeCoverPictureLeft(string petId)
        {
            var user = this.usersRepository.AllAsNoTracking().FirstOrDefault(x => x.Id == petId);

            CoverPictureLeft coverLeft = this.coverLeftRepository.AllAsNoTracking().Where(x => x.UserId == user.Id).OrderByDescending(x => x.CreatedOn).FirstOrDefault();
            return coverLeft;
        }

        public CoverPictureRight TakeCoverPictureRight(string petId)
        {
            var user = this.usersRepository.AllAsNoTracking().FirstOrDefault(x => x.Id == petId);
            var coverPictureRight = this.coverRightRepository.AllAsNoTracking().Where(x => x.UserId == user.Id).OrderByDescending(x => x.CreatedOn).FirstOrDefault();
            return coverPictureRight;
        }

        public ProfilePicture TakeProfilePicture(string petId)
        {
            var user = this.usersRepository.AllAsNoTracking().FirstOrDefault(x => x.Id == petId);
            var profilePicture = this.profilePictureRepository.AllAsNoTracking().Where(x => x.UserId == user.Id).OrderByDescending(x => x.CreatedOn).FirstOrDefault();
            return profilePicture;
        }

        public async Task UploadProfileOrCoverImage(MyImagesInputModel createInput, string petId)
        {
            var user = this.usersRepository.All().FirstOrDefault(x => x.Id == petId);

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
                                    User = user,
                                };
                                await this.profilePictureRepository.AddAsync(profilePicture);
                                await this.profilePictureRepository.SaveChangesAsync();
                                user.ProfilePictures.Add(profilePicture);
                                this.usersRepository.Update(user);

                                // this.usersRepository.SaveChangesAsync();
                                // await this.usersRepository.SaveChangesAsync();
                                // this.usersRepository.Update(user);
                                // this.usersRepository.Update(user);
                                // this.usersRepository.SaveChangesAsync();

                                // this.usersRepository.SaveChangesAsync();
                                // await profilePictureRepository.AddAsync(profilePicture);
                                // await profilePictureRepository.SaveChangesAsync();
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
                                    User = user,
                                };
                                user.CoverPicturesLeft.Add(coverPictureLeft);
                                await this.coverLeftRepository.AddAsync(coverPictureLeft);
                                await this.coverLeftRepository.SaveChangesAsync();
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
                                await this.coverRightRepository.AddAsync(coverPictureRight);
                                await this.coverRightRepository.SaveChangesAsync();
                            }
                        }
                    }
                }
            }

            // await userManager.UpdateAsync(user);
            // this.usersRepository.Update(user);

            // this.usersRepository.SaveChangesAsync();
        }
    }
}
