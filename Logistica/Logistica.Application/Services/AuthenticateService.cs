using Logistica.Application.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistica.Application.Services
{
    public class AuthenticateService : IAuthenticate
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AuthenticateService(SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<bool> Authenticate(string username, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(username, password,
               isPersistent: false, lockoutOnFailure: false);

            return result.Succeeded;
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<bool> RegisterUser(string username, string email, string password)
        {
            var appUser = new IdentityUser
            {
                UserName = username,
                Email = email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(appUser, password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(appUser, isPersistent: false);
            }
            return result.Succeeded;
        }
    }
}
