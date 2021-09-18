using System;
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
        public uint Attack { get; set; }

        [Required]
        public uint Health { get; set; }

        [MaxLength(200)]
        [Required]
        public string Description { get; set; }

        public ICollection<UserCard> CardUsers { get; set; }
    }
}
