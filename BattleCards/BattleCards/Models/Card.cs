﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BattleCards.Models
{
    public class Card
    {
        public Card()
        {
            CardUsers = new HashSet<UserCard>();
        }

        [Required]
        public int Id { get; set; }

        [MaxLength(15)]
        [Required]
        public string Name { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public string Keyword { get; set; }

        [Required]
        public int Attack { get; set; }

        [Required]
        public int Health { get; set; }

        [MaxLength(200)]
        [Required]
        public string Description { get; set; }

        public virtual ICollection<UserCard> CardUsers { get; set; }
    }
}
