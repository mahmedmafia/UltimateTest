using Shared.DTO;
using Shared.RequestFeatures;

namespace Service.Contracts
{
    public interface ICustomerService
    {
        Task<(IEnumerable<CustomerDto> customers, int numberOfPages)> GetAllCustomersAsync(RequestParameters requestParams,bool trackChanges = false);
        Task<CustomerDto> GetCustomerFullDetailsAsync(int customerId, bool trackChanges);
        Task CreateCustomerAsync(CustomerModificationDto customerDto);
        Task DeleteCustomerAsync(int id);
        Task UpdateCustomerAsync(int id, CustomerModificationDto customerDto);

    }
}