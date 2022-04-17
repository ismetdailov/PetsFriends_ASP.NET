using Microsoft.AspNetCore.Http;
using PetsFriends.Data.Models;
using PetsFriends.Web.ViewModels.Home;
using PetsFriends.Web.ViewModels.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsFriends.Services.Data
{
    public interface IPostService
    {
        Task CreateAsync(CreatePostInputModel createInput, string petId);

        IEnumerable<T> GetAllPosts<T>();

        Task DeleteAsync(int id);

        Task LikePost(string postId);
    }
}
