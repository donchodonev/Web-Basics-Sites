using BattleCards.Data;
using BattleCards.Models;
using BattleCards.Services;
using BattleCards.ViewModels.Cards;
using SIS.HTTP;
using SIS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleCards.Controllers
{
    public class CardsController : Controller
    {
        private readonly ICardsService cardsService;

        public CardsController(ICardsService cardsService)
        {
            this.cardsService = cardsService;
        }

        public HttpResponse Add()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(string name, string image, string keyword, int attack, int health, string description)
        {
            if (!IsUserLoggedIn())
            {
                return Error("Please login first and then you can add a new card");
            }

            if (name.Length < 5 || name.Length > 15 || string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
            {
                return Error("Card name length must be between 5 and 15 characters long.");
            }

            if (string.IsNullOrWhiteSpace(image) || string.IsNullOrEmpty(image) || !Uri.TryCreate(image, UriKind.Absolute, out var output))
            {
                return Error("You must add a valid card image URL");
            }

            if (attack < 0)
            {
                return Error("Card attack points cannot be negative");
            }

            if (health < 0)
            {
                return Error("Card health points cannot be negative");
            }

            if (description.Length > 200)
            {
                return Error("Card description text must be a maximum of 200 characters");
            }

            cardsService.AddCard(name, image, keyword,attack,health,description);

            return Redirect("/Cards/All");
        }

        public HttpResponse Collection()
        {
            if (!IsUserLoggedIn())
            {
                return this.Error("In order to view your card collection please first log-in");
            }

            var userId = this.Request.SessionData["UserId"];

            AllCardsViewModel userCards = new AllCardsViewModel();

            userCards.Cards = cardsService.GetAllUserCards(userId).ToList();

            return this.View(userCards);
        }

        public HttpResponse All()
        {
            AllCardsViewModel cards = new AllCardsViewModel();

            cards.Cards = cardsService.GetAllCards().ToList();

            return this.View(cards);
        }

        public HttpResponse AddToCollection(int cardId)
        {
            var userId = this.Request.SessionData["UserId"];

            if (cardsService.UserOwnsCard(cardId, userId))
            {
                return Error("User already owns this card");
            }

            cardsService.AddCardToUserCollection(cardId, userId);

            return Redirect("/Cards/All");
        }

        public HttpResponse RemoveFromCollection(int cardId)
        {
            var userId = this.Request.SessionData["UserId"];

            if (!cardsService.UserOwnsCard(cardId, userId))
            {
                return Error($"User doesn't own {cardsService.GetCard(cardId).Name}");
            }

            cardsService.RemoveUserCard(cardId, userId);

            return Redirect("/Cards/Collection");
        }
    }
}
