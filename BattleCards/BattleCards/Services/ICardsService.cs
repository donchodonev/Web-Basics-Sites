using BattleCards.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleCards.Services
{
    public interface ICardsService
    {
        public void AddCard(string name, string imageUrl, string keyword, int attack, int health, string description);

        public Card GetCardByUserId(string userId);

        public IEnumerable<Card> GetAllCards();
    }
}
