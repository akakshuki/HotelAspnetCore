using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Data.EF
{
    public class HotelDataContextFactory : IDesignTimeDbContextFactory<HotelDataContext>
    {
        //setting data context
        public HotelDataContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsetting.json")
                .Build();

            var connectionString = configuration.GetConnectionString("HotelDB");

            var optionsBuilder = new DbContextOptionsBuilder<HotelDataContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new HotelDataContext(optionsBuilder.Options);
        }
    }
}