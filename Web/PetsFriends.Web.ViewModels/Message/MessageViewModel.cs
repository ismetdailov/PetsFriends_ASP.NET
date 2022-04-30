namespace PetsFriends.Web.ViewModels.Message
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using PetsFriends.Data.Models;

    public class MessageViewModel
    {
        public ApplicationUser SenderPet { get; set; }

        public string MessageText { get; set; }

        public DateTime DateSent { get; set; }

        public bool IsSeen { get; set; }

        public ApplicationUser ReciverPet { get; set; }

        public ICollection<Messages> Messages { get; set; }
    }
}
