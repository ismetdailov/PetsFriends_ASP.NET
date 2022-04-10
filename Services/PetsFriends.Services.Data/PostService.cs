using Microsoft.AspNetCore.Http;
using PetsFriends.Data.Common.Repositories;
using PetsFriends.Data.Models;
using PetsFriends.Web.ViewModels.Post;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsFriends.Services.Data
{
    public class PostService : IPostService
    {
        private readonly IDeletableEntityRepository<Post> postRepository;
        private readonly IDeletableEntityRepository<Picture> pictureRepository;

        public PostService(IDeletableEntityRepository<Post> postRepository, IDeletableEntityRepository<Picture> pictureRepository)
        {
            this.postRepository = postRepository;
            this.pictureRepository = pictureRepository;
        }

        public async Task CreateAsync(CreatePostInputModel createInput, string petId)
        {
            var post = new Post
            {
                Content = createInput.ContentPost,
            };

            var filePath = Path.GetTempFileName();
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

            await this.postRepository.AddAsync(post);
            await this.postRepository.SaveChangesAsync();
        }
    }
}
