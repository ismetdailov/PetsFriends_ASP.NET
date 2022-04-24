using PetsFriends.Web.ViewModels.Post;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsFriends.Web.ViewModels.Profile
{
    public class ProfilePostInPutModel : CreatePostInputModel
    {
        public string PetId { get; set; }

    }
}
