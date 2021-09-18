using BattleCards.Data;
using BattleCards.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleCards.Services
{
    public class CardsService : ICardsService
    {
        private readonly ApplicationDbContext db;

        public CardsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void AddCard(string name, string imageUrl, string keyword, int attack, int health, string description)
        {
            db.Cards.Add(new Card()
            {
                Name = name,
                ImageUrl = imageUrl,
                Keyword = keyword,
                Attack = attack,
                Health = health,
                Description = description
            });

            db.SaveChanges();
        }

        public IEnumerable<Card> GetAllCards()
        {
            return db.Cards;
        }

        public Card GetCardByUserId(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
