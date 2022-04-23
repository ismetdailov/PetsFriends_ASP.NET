using PetsFriends.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsFriends.Web.ViewModels.Message
{
    public class MessageViewModel
    {
        public string SenderId { get; set; }

        public ApplicationUser SenderPet { get; set; }

        public string MessageText { get; set; }

        public DateTime DateSent { get; set; }

        public bool IsSeen { get; set; }

        public string SenderFullName { get; set; }

        public string PetReciverId { get; set; }
        public ApplicationUser ReciverPet { get; set; }

    }
}
