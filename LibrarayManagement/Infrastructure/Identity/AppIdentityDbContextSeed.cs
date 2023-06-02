using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUserAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    DisplayName = "admin",
                    Email = "admin@gmail.com",
                    UserName = "admin@gmail.com"
                };

                await userManager.CreateAsync(user, "Pa$$w0rd");
            }
        }
    }
}