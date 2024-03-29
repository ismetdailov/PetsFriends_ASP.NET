﻿namespace PetsFriends.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using PetsFriends.Data.Common.Models;

    public class Messages : BaseDeletableModel<int>
    {
        [Required]
        public string Content { get; set; }

        [Required]
        public string GroupId { get; set; }

        public Group Group { get; set; }

        [Required]
        [ForeignKey(nameof(GroupId))]
        public string PetId { get; set; }

        public ApplicationUser Pet { get; set; }

        [Required]
        public string ReciverId { get; set; }

        [ForeignKey(nameof(ReciverId))]
        public ApplicationUser ReciverPet { get; set; }

        [Required]
        public DateTime SendedOn { get; set; }
    }
}
