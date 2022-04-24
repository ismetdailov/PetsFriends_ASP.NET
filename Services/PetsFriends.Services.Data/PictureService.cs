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

        public PictureService(IDeletableEntityRepository<Picture> pictureRepository)
        {
            this.pictureRepository = pictureRepository;
        }
        public T GetById<T>(string id)
        {
            var Images = this.pictureRepository.AllAsNoTracking()
                   .Where(x => x.Id == id)
                   .To<T>().FirstOrDefault();

            return Images;
        }
    }
}
