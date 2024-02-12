using Restaurant.Services.Authentication.Models;

namespace Restaurant.Services.Authentication.Service
{
    public interface IJwtGenerator
    {
        string GenerateToken(ApplicationUser applicationUser);
    }
}
