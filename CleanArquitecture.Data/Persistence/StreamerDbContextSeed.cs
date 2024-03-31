using CleanArquitectureNet.Domain;
using Microsoft.Extensions.Logging;

namespace CleanArquitectureNet.Infrastructure.Persistence
{
    public class StreamerDbContextSeed
    {
        public static async Task SeedAsync(StreamerDbContext context, ILogger<StreamerDbContext> logger)
        {
            if(!context.Streamers!.Any())
            {
                context.Streamers!.AddRange(GetPreconfiguredStreames());
                await context.SaveChangesAsync();
                logger.LogInformation("Estamos insertando nuevos records a DB {context}", typeof(StreamerDbContext).Name);
            }
        }

        private static IEnumerable<Streamer> GetPreconfiguredStreames()
        {
            return new List<Streamer>
            {
                new Streamer {CreatedBy = "vaxidrez", Nombre = "Max", Url = "http://www.max.com" },
                new Streamer {CreatedBy = "vaxidrez", Nombre = "Amazon VIP", Url = "http://www.amazonvip.com" }
            };
        }
    }
}
