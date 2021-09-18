using System;
using System.Collections.Generic;
using System.Text;

namespace BattleCards.Services
{
    public interface IUsersService
    {
        public void Register(string username, string email, string password);

        public bool EmailExists(string email);

        public bool UsernameExists(string username);

        public string GetPasswordHash(string inputPassword);

        public string GetPassword(string username);

        public string GetId(string username, string password);
    }
}
