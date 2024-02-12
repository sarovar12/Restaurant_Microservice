using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Restaurant.Services.Authentication.DatabaseContext;
using Restaurant.Services.Authentication.Models;
using Restaurant.Services.Authentication.Models.DTO;

namespace Restaurant.Services.Authentication.Service
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;


        public AuthService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        public async Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO)
        {
            var user = await _context.ApplicationUsers.FirstOrDefaultAsync(user => user.UserName.ToLower() == loginRequestDTO.Username.ToLower());
            bool isValid = await _userManager.CheckPasswordAsync(user, loginRequestDTO.Password);
            if (user == null || isValid == false)
            {
                return new LoginResponseDTO()
                {
                    User = null,
                    Token = ""
                };
            }

            UserDTO userDTO = new()
            {
                Email = user.Email,
                ID = user.Id,
            };
            LoginResponseDTO loginResponseDTO = new LoginResponseDTO()
            {
                User = userDTO,
                Token = ""
            };
            return loginResponseDTO;
        } 
        
    

    public async Task<string> Register(RegistrationRequestDTO registrationRequestDTO)
    {
        ApplicationUser user = new()
        {
            UserName = registrationRequestDTO.Email,
            Email = registrationRequestDTO.Email,
            NormalizedEmail = registrationRequestDTO.Email.ToUpper(),
            Name = registrationRequestDTO.Name,
            PhoneNumber = registrationRequestDTO.PhoneNumber,
        };
        try
        {
            var result = await _userManager.CreateAsync(user, registrationRequestDTO.Password);
            if (result.Succeeded)
            {
                var userToReturn = _context.ApplicationUsers.First(user => user.UserName == registrationRequestDTO.Email);
                UserDTO userDTO = new()
                {
                    Email = userToReturn.Email,
                    ID = userToReturn.Id,
                    Name = userToReturn.Name,
                    PhoneNumber = userToReturn.PhoneNumber
                };
                return "";
            }
            else
            {
                return result.Errors.FirstOrDefault().Description;
            }
        }
        catch (Exception ex)
        {
            return "Error Encountered";
        }
    }
}
}
