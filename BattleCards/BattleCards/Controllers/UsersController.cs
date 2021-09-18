using BattleCards.Data;
using BattleCards.Services;
using SIS.HTTP;
using SIS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleCards.Controllers
{
    public class UsersController : Controller
    {
        private const int UsernameMinLength = 5;
        private const int UsernameMaxLength = 20;
        private const int PasswordMinLength = 6;
        private const int PasswordMaxLength = 20;

        private readonly IUsersService userService;

        public UsersController(IUsersService userService)
        {
            this.userService = userService;
        }
        public HttpResponse Login()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(string username, string password)
        {
            if (username.Length < UsernameMinLength || username.Length > UsernameMaxLength || string.IsNullOrEmpty(username) || string.IsNullOrWhiteSpace(username))
            {
                return this.Error($"Username length must be between {UsernameMinLength} and {UsernameMaxLength} characters long");
            }

            if (password.Length < PasswordMinLength || password.Length > PasswordMaxLength || string.IsNullOrEmpty(password) || string.IsNullOrWhiteSpace(password))
            {
                return this.Error($"Password length must be between {PasswordMinLength} and {PasswordMaxLength} characters long");
            }









            return this.Redirect("/Cards/All");
        }

        public HttpResponse Register()
        {
            return this.View();
        }

        [HttpPost()]
        public HttpResponse Register(string username, string email, string password, string confirmPassword, Random randomNum)
        {
            if (username.Length < UsernameMinLength || username.Length > UsernameMaxLength || string.IsNullOrEmpty(username) || string.IsNullOrWhiteSpace(username))
            {
                return this.Error($"Username length must be between {UsernameMinLength} and {UsernameMaxLength} characters long");
            }

            if (userService.UsernameExists(username))
            {
                return this.Error($"A user with this username already exists, please user a different username. Examples: {username}{randomNum.Next(100, 1001)} .");
            }

            if (userService.EmailExists(email))
            {
                return this.Error($"A user with this email address already exists, please user a different email address.");
            }

            if (password.Length < PasswordMinLength || password.Length > PasswordMaxLength || string.IsNullOrEmpty(password) || string.IsNullOrWhiteSpace(password))
            {
                return this.Error($"Password length must be between {PasswordMinLength} and {PasswordMaxLength} characters long");
            }

            if (password != confirmPassword)
            {
                return this.Error("Password confirmation failed, please make the password entered in the \"ConfirmPassword\" field matches the previously written password");
            }

            userService.Register(username, email, password);

            return this.Redirect("/Users/Login");
        }
    }
}
