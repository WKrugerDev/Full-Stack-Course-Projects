using Microsoft.AspNetCore.Identity;
using UserAuthApi.Api.DTOs;
using UserAuthApi.Api.Models;

namespace UserAuthApi.Api.Services
{
    public class AuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AuthService(UserManager<ApplicationUser> userManager, 
                       SignInManager<ApplicationUser> signInManager)
        {   
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> RegisterAsync(RegisterDto dto)
        {
            var user = new ApplicationUser
            {
                Email = dto.Email,
                Name = dto.Name,
                Surname = dto.Surname,
                DisplayName = string.IsNullOrWhiteSpace(dto.DisplayName)
                    ? $"{dto.Name} {dto.Surname}"
                    : dto.DisplayName
            };

            //Handle username
            if(string.IsNullOrWhiteSpace(dto.Username))
            {
                var baseUsername = $"{dto.Name}.{dto.Surname}".ToLower();
                var username = baseUsername;
                var counter = 1;

                //keep trying until unique
                while (await _userManager.FindByNameAsync(username) != null)
                {
                    username = $"{baseUsername}{counter}";
                    counter++;
                }
                user.UserName = username;
            }
            else
            {
                //Check if chosen username is taken
                if(await _userManager.FindByNameAsync(dto.Username) != null)
                {
                    return IdentityResult.Failed (new IdentityError
                    {
                       Description = "Username already taken." 
                    });

                }
            }

            return await _userManager.CreateAsync(user, dto.Password);
        }

        public async Task<SignInResult> LoginAsync(LoginDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.UsernameOrEmail)
                        ?? await _userManager.FindByNameAsync(dto.UsernameOrEmail);
            
            if (user == null)
                return SignInResult.Failed;

            return await _signInManager.PasswordSignInAsync(user, dto.Password, dto.RememberMe, lockoutOnFailure: true);
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}