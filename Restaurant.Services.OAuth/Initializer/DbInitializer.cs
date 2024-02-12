using IdentityModel;
using Microsoft.AspNetCore.Identity;
using Restaurant.Services.OAuth.DatabaseContext;
using Restaurant.Services.OAuth.Models;
using System.Security.Claims;

namespace Restaurant.Services.OAuth.Initializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public DbInitializer(RoleManager<IdentityRole> roleManager,ApplicationDbContext applicationDbContext, UserManager<ApplicationUser> userManager)
        {

            _roleManager = roleManager;
            _context = applicationDbContext;
            _userManager = userManager;

        }
        public void Initialize()
        {
            if(_roleManager.FindByNameAsync(StaticData.Admin).Result == null)
            {
                _roleManager.CreateAsync(new IdentityRole(StaticData.Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(StaticData.Customer)).GetAwaiter().GetResult();
            }
            else
            {
                return;
            }
            ApplicationUser adminUser = new ApplicationUser()
            {
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                EmailConfirmed = true,
                PhoneNumber= "1111111111",
                FirstName= "Sarovar",
                LastName ="Admin"
            };
            _userManager.CreateAsync(adminUser,"Sarovar@123").GetAwaiter().GetResult();
            _userManager.AddToRoleAsync(adminUser, StaticData.Admin).GetAwaiter().GetResult();
            var temp1 = _userManager.AddClaimsAsync(adminUser, new Claim[] {
                new Claim(JwtClaimTypes.Name,adminUser.FirstName+" "+ adminUser.LastName),
                new Claim(JwtClaimTypes.GivenName,adminUser.FirstName),
                new Claim(JwtClaimTypes.FamilyName,adminUser.LastName),
                new Claim(JwtClaimTypes.Role,StaticData.Admin),
            }).Result;

            ApplicationUser customerUser = new ApplicationUser()
            {
                UserName = "customer@gmail.com",
                Email = "customer@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "111111111111",
                FirstName = "Customer",
                LastName = "Bhandari"
            };

            _userManager.CreateAsync(customerUser, "Customer@123").GetAwaiter().GetResult();
            _userManager.AddToRoleAsync(customerUser, StaticData.Customer).GetAwaiter().GetResult();

            var temp2 = _userManager.AddClaimsAsync(customerUser, new Claim[] {
                new Claim(JwtClaimTypes.Name,customerUser.FirstName+" "+ customerUser.LastName),
                new Claim(JwtClaimTypes.GivenName,customerUser.FirstName),
                new Claim(JwtClaimTypes.FamilyName,customerUser.LastName),
                new Claim(JwtClaimTypes.Role,StaticData.Customer),
            }).Result;
        }
    }
}
