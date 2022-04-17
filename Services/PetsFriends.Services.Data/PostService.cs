using Microsoft.AspNetCore.Http;
using PetsFriends.Data.Common.Repositories;
using PetsFriends.Data.Models;
using PetsFriends.Web.ViewModels.Home;
using PetsFriends.Web.ViewModels.Post;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetsFriends.Services.Mapping;
namespace PetsFriends.Services.Data
{
    public class PostService : IPostService
    {
        private readonly IDeletableEntityRepository<Post> postRepository;
        private readonly IDeletableEntityRepository<Picture> pictureRepository;
        private readonly IDeletableEntityRepository<ApplicationUser> usersRepository;

        public PostService(IDeletableEntityRepository<Post> postRepository, IDeletableEntityRepository<Picture> pictureRepository, IDeletableEntityRepository<ApplicationUser> usersRepository)
        {
            this.postRepository = postRepository;
            this.pictureRepository = pictureRepository;
            this.usersRepository = usersRepository;
        }

        public async Task CreateAsync(CreatePostInputModel createInput, string petId)
        {
          
            var post = new Post
            {
                UserId = petId,
                CreatedOn = DateTime.Now,
                Content = createInput.ContentPost,
            };

            if (createInput.Pictures != null)
            {
                foreach (var formFile in createInput.Pictures)
                {
                    if (formFile.Length > 0)
                    {
                        using (var stream = new MemoryStream())
                        {
                            await formFile.CopyToAsync(stream);

                            var picture = new Picture
                            {
                                PhotoAsBytes = stream.ToArray(),
                                AddedByPetId = petId,
                            };
                            post.Picture.Add(picture);

                            await this.pictureRepository.AddAsync(picture);
                        }
                    }
                }
            }

            await this.postRepository.AddAsync(post);
            await this.postRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetAllPosts<T>()
        {

            return this.postRepository.AllAsNoTracking().OrderByDescending(x => x.CreatedOn).To<T>().ToList();
        }

        public async Task DeleteAsync(int id)
        {
            var post = this.postRepository.All().FirstOrDefault(x => x.Id == id);
            this.postRepository.Delete(post);
            await this.postRepository.SaveChangesAsync();
        }
        public async Task LikePost(string postId)
        {
          
        }

    }
}
