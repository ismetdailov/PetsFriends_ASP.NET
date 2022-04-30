namespace PetsFriends.Web.ViewModels.Profile
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using PetsFriends.Web.ViewModels.Post;

    public class ProfilePostInPutModel : CreatePostInputModel
    {
        public string PetId { get; set; }
    }
}
