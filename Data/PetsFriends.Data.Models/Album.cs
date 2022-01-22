namespace PetsFriends.Data.Models
{
    using System.Collections.Generic;

    using PetsFriends.Data.Common.Models;

    public class Album : BaseDeletableModel<int>
    {
        public Album()
        {
            this.Pictures = new HashSet<Picture>();
        }

        public string Name { get; set; }

        public int PicturesCount => this.Pictures.Count;

        public string PictureId { get; set; }

        public virtual ICollection<Picture> Pictures { get; set; }
    }
}
