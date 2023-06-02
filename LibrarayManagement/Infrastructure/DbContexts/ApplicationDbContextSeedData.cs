
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Infrastructure.DbContexts
{
    public class ApplicationDbContextSeedData
    {
        public static async Task SeedAsync(ApplicationDbContext applicationDb,
            ILoggerFactory loggerFactory)
        {
            try
            {
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<ApplicationDbContextSeedData>();
                logger.LogError(ex.Message);
            }
        }
    }
}
