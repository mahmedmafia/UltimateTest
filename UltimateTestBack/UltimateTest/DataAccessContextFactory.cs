using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace UltimateTest
{
    public class DataAccessContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder().
                SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<DataContext>()
                .UseSqlServer(
                configuration.GetConnectionString("sqlConnection"),
                b => b.MigrationsAssembly("UltimateTest"));
        return new DataContext(builder.Options);                

        }
    }
}
