
using AutoMapper;
using Contracts;
using Entities.Models;
using Service.Contracts;
using Shared.DTO;
using Shared.RequestFeatures;

namespace Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public CustomerService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<(IEnumerable<CustomerDto> customers, int numberOfPages)> GetAllCustomersAsync(RequestParameters requestParams, bool trackChanges = false)
        {
            var response = await _repository.Customer.GetAllCustomersAsync(requestParams, trackChanges);
            var customersDto = _mapper.Map<IEnumerable<CustomerDto>>(response.customers);
            return (customersDto, response.numberOfPages);
        }

        public async Task CreateCustomerAsync(CustomerModificationDto customerDto)
        {
            var customerEntity=_mapper.Map<Customer>(customerDto);
             _repository.Customer.CreateCustomer(customerEntity);
            await _repository.SaveAsync();
        }

        public async Task DeleteCustomerAsync(int id)
        {
            var customerEntity = await _repository.Customer.GetCustomerAsync(id,false);
            _repository.Customer.DeleteCustomer(customerEntity);
            await _repository.SaveAsync();
        }

        public async Task<CustomerDto> GetCustomerFullDetailsAsync(int id, bool trackChanges)
        {
            var customerEntity = await _repository.Customer.GetFullCustomerDetailsAsync(id, false);
            return _mapper.Map<CustomerDto>(customerEntity);
        }

     

        public async Task UpdateCustomerAsync(int id, CustomerModificationDto customerDto)
        {
            var customerEntity = await _repository.Customer.GetFullCustomerDetailsAsync(id, true);
            customerEntity.Id = id;
            _mapper.Map(customerDto, customerEntity);
            await _repository.SaveAsync();
        }

       
    }
}
