using Entities.Models;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ICustomerRepository
    {
        public Task<(IEnumerable<Customer> customers, int numberOfPages)> GetAllCustomersAsync(RequestParameters requestParams,bool trackChagnes);
        public Task<Customer> GetCustomerAsync(int customerId,bool trackChanges);
        public Task<Customer> GetFullCustomerDetailsAsync(int customerId, bool trackChanges);
        public void CreateCustomer(Customer Customer);

        public void DeleteCustomer(Customer Customer);
    }
}
