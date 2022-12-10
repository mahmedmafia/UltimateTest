using System.Linq.Expressions;

namespace Contracts
{
    public interface IRepositoryManager
    {
      ICustomerRepository Customer { get; }
       Task SaveAsync();



    }
}