
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configuration
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasData(
                      new Address
                      {
                          Id=1,
                          City = "CWQ",
                          Building = 2,
                          Floor = 2,
                          Street = "SA",
                          Zone = "HAs",
                          CustomerId = 1
                      },
                        new Address
                        {
                            Id=2,
                            City = "qwq",
                            Building = 2,
                            Floor = 2,
                            Street = "asa",
                            Zone = "safa",
                            CustomerId = 1
                        },
                     new Address
                     {
                         Id=3,
                         City = "aSA",
                         Building = 2,
                         Floor = 2,
                         Street = "qeq",
                         Zone = "vzv",
                         CustomerId = 2
                     },
                        new Address
                        {
                            Id=4,
                            City = "assa",
                            Building = 2,
                            Floor = 2,
                            Street = "vzvz",
                            Zone = "xzxz",
                            CustomerId = 2
                        }
                ); ;
        }
    }
}
