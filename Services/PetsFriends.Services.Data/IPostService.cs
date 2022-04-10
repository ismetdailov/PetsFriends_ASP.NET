using Microsoft.AspNetCore.Http;
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
    }
}
