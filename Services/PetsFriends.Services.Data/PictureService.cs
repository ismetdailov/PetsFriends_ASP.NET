using PetsFriends.Data.Common.Repositories;
using PetsFriends.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetsFriends.Services.Mapping;


namespace PetsFriends.Services.Data
{
    public class PictureService : IPictureService
    {
        private readonly IDeletableEntityRepository<Picture> pictureRepository;
        private readonly IDeletableEntityRepository<ProfilePicture> profilePictureRepository;
        private readonly IDeletableEntityRepository<CoverPictureLeft> coverPictureLeftRepository;
        private readonly IDeletableEntityRepository<CoverPictureLeft> coverPictureRightRepository;

        public PictureService(IDeletableEntityRepository<Picture> pictureRepository,
            IDeletableEntityRepository<ProfilePicture> profilePictureRepository,
            IDeletableEntityRepository<CoverPictureLeft> coverPictureLeftRepository,
            IDeletableEntityRepository<CoverPictureLeft> coverPictureRightRepository)
        {
            this.pictureRepository = pictureRepository;
            this.profilePictureRepository = profilePictureRepository;
            this.coverPictureLeftRepository = coverPictureLeftRepository;
            this.coverPictureRightRepository = coverPictureRightRepository;
        }
        public T GetById<T>(string id)
        {
            var Images = this.pictureRepository.AllAsNoTracking()
                   .Where(x => x.Id == id)
                   .To<T>().FirstOrDefault();

            return Images;
        }

        //public T GetById<T>(int id)
        //{
        //    var image = this.profilePictureRepository.AllAsNoTracking(x=>x.Id)
        //}
    }
}
