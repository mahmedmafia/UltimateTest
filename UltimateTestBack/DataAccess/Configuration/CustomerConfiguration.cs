
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configuration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasData(
                new Customer
                {
                    Id=1,
                    Code = "122",
                    Description = "Good customer",
                    Mobile = "01202112",
                    Name = "Farid",
                },
                new Customer
                {
                    Id=2,
                    Code = "515",
                    Description = "customer",
                    Mobile = "021312312",
                    Name = "Saner",
                }
                ); ;
        }
    }
}
