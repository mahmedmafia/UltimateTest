using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly DataContext _context;
        private readonly Lazy<ICustomerRepository> _customerRepo;

        public RepositoryManager(DataContext context)
        {
            _context = context;
            this._customerRepo = new Lazy<ICustomerRepository>(() => new CustomerRepository(_context));
        }

        public ICustomerRepository Customer => _customerRepo.Value;

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
