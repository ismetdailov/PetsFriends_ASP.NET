namespace PetsFriends.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http;
    using PetsFriends.Data.Models;
    using PetsFriends.Web.ViewModels.Home;
    using PetsFriends.Web.ViewModels.Post;

    public interface IPostService
    {
        Task CreateAsync(CreatePostInputModel createInput, string petId);

        IEnumerable<T> GetAllPosts<T>();

        IEnumerable<T> GetMyPosts<T>(string petId);

        Task DeleteAsync(int id);

        Task LikePost(int postId, string petId);

        int GetLikesCount(int postId);
    }
}
