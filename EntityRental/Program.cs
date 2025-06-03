using Microsoft.Extensions.Configuration;

namespace EntityRental
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appConfig.json")
                .Build();

            var connectionString = configuration.GetConnectionString("postgres");
            Console.WriteLine($"Connection String: {connectionString}");
        }
    }
}
