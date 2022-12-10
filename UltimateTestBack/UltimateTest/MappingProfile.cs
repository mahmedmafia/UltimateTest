using AutoMapper;
using Entities.Models;
using Shared.DTO;

namespace UltimateTest
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerModificationDto, Customer>();
            CreateMap<AddressDto, Address>().ReverseMap();
        }
    }
}
