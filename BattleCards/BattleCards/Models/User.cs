using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BattleCards.Models
{
    public class User
    {
        public User()
        {
            Id = new Guid().ToString();
            Cards = new HashSet<UserCard>();
        }

        [Required]
        public string Id { get; set; }

        [MaxLength(20)]
        [Required]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public int CardId { get; set; }

        public ICollection<UserCard> Cards { get; set; }
    }
}
