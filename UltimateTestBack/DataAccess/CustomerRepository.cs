using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(DataContext context) : base(context)
        {
        }

        public void CreateCustomer(Customer Customer)
        {
            this.Create(Customer); 
        }

        public void DeleteCustomer(Customer Customer)
        {
           this.Delete(Customer);
        }

        public async Task<(IEnumerable<Customer> customers,int numberOfPages)> GetAllCustomersAsync(RequestParameters requestParams,bool trackChagnes)
        {
            var customers= await this.FindAll(trackChagnes)
                .OrderBy(x=> x.Id)
                .Skip((requestParams.PageNumber-1)*requestParams.PageSize)
                .Take(requestParams.PageSize)
                .ToListAsync();
            var count= await this.FindAll(false).CountAsync();
            return (customers,  (int)Math.Ceiling((double)count/requestParams.PageSize));
        }

        public async Task<Customer> GetCustomerAsync(int customerId, bool trackChanges)
        {
            return await this.FindByCondition(x => x.Id.Equals(customerId),trackChanges).FirstOrDefaultAsync();
        }

        public async Task<Customer> GetFullCustomerDetailsAsync(int customerId, bool trackChanges)
        {
            return await this.FindByCondition(x => x.Id.Equals(customerId), trackChanges).Include(x => x.Addresses).FirstOrDefaultAsync() ;
        }
    }
}
