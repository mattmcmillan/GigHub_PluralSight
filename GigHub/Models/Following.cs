﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GigHub.Models
{
    public class Following
    {
        [Key]
        [Column(Order = 1)]
        public string FollowerId { get; set; }

        [Key]
        [Column(Order = 2)]
        public string UserFollowedId { get; set; }

        public ApplicationUser Follower { get; set; }
        public ApplicationUser UserFollowed { get; set; }
    }
}