namespace PetsFriends.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http;
    using PetsFriends.Data.Common.Repositories;
    using PetsFriends.Data.Models;
    using PetsFriends.Services.Mapping;
    using PetsFriends.Web.ViewModels.Home;
    using PetsFriends.Web.ViewModels.Post;

    public class PostService : IPostService
    {
        private readonly IDeletableEntityRepository<Post> postRepository;
        private readonly IDeletableEntityRepository<Picture> pictureRepository;
        private readonly IDeletableEntityRepository<ApplicationUser> usersRepository;
        private readonly IDeletableEntityRepository<Like> likeRepository;

        public PostService(
            IDeletableEntityRepository<Post> postRepository,
            IDeletableEntityRepository<Picture> pictureRepository,
            IDeletableEntityRepository<ApplicationUser> usersRepository,
            IDeletableEntityRepository<Like> likeRepository)
        {
            this.postRepository = postRepository;
            this.pictureRepository = pictureRepository;
            this.usersRepository = usersRepository;
            this.likeRepository = likeRepository;
        }

        public async Task CreateAsync(CreatePostInputModel createInput, string petId)
        {
            var post = new Post
            {
                UserId = petId,
                CreatedOn = DateTime.Now,
                Content = createInput.ContentPost,
                Likes = createInput.Likes,
                Comments = createInput.Comments,
                User = createInput.User,
            };
            post.Likes = createInput.Likes;
            post.Comments = createInput.Comments;
            post.User = createInput.User;

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

        public async Task LikePost(int postId, string petId)
        {
            var post = this.postRepository.All().FirstOrDefault(x => x.Id == postId);
            if (post != null)
            {
                var like = this.likeRepository.All().Where(x => x.PostId == postId).FirstOrDefault(x => x.UserId == petId);
                var likes = this.likeRepository.All().ToList();
                var likeFromUser = post.Likes.FirstOrDefault(x => x.UserId == petId);
                if (like == null)
                {
                    var newLike = new Like
                    {
                        UserId = petId,
                        PostId = post.Id,
                    };

                    post.Likes.Add(newLike);
                    await this.likeRepository.AddAsync(newLike);
                }
                else
                {
                    this.likeRepository.HardDelete(like);
                }
            }

            await this.likeRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetMyPosts<T>(string petId)
        {
            return this.postRepository.AllAsNoTracking().Where(x => x.UserId == petId).OrderByDescending(x => x.CreatedOn).To<T>().ToList();
        }

        public int GetLikesCount(int postId)
        {
            var post = this.postRepository.AllAsNoTracking().Where(x => x.Id == postId).FirstOrDefault();

            return post.LikesCount;
        }
    }
}
