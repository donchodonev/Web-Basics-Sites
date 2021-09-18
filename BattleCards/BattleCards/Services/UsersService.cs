using BattleCards.Data;
using BattleCards.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleCards.Services
{
    public class UsersService : IUsersService
    {
        private readonly ApplicationDbContext database;

        public UsersService(ApplicationDbContext db)
        {
            this.database = db;
        }

        public bool EmailExists(string email)
        {
            return database.Users.Any(x => x.Email == email);
        }

        public string GetId(string username)
        {
            return database.Users.FirstOrDefault(x => x.Username == username).Id;
        }

        public string GetPassword(string username)
        {
            return database.Users.FirstOrDefault(x => x.Username == username).Password;
        }

        public string GetPasswordHash(string inputPassword)
        {
            var bytes = System.Text.Encoding.UTF8.GetBytes(inputPassword);
            using (var hash = System.Security.Cryptography.SHA512.Create())
            {
                var hashedInputBytes = hash.ComputeHash(bytes);

                var hashedInputStringBuilder = new System.Text.StringBuilder(128);
                foreach (var b in hashedInputBytes)
                    hashedInputStringBuilder.Append(b.ToString("X2"));
                return hashedInputStringBuilder.ToString();
            }
        }

        public void Register(string username, string email, string password)
        {
            database.Users.Add(new User
            {
                Username = username,
                Email = email,
                Password = GetPasswordHash(password)
            });

            database.SaveChanges();
        }

        public bool UsernameExists(string username)
        {
            return database.Users.Any(x => x.Username == username);
        }
    }
}
