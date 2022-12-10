using AutoMapper;
using Contracts;
using Microsoft.Extensions.Configuration;
using Service.Contracts;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<ICustomerService> _customerService;
        private readonly Lazy<IAuthenticationService> _authenticationService;

        public ServiceManager(IMapper mapper,IRepositoryManager repository, IConfiguration configuration)
        {
            this._customerService = new Lazy<ICustomerService>(() => new CustomerService(repository, mapper) );
            this._authenticationService = new Lazy<IAuthenticationService>(() => new AuthenticationService(configuration));
        }
        public ICustomerService CustomerService => _customerService.Value;

        public IAuthenticationService AuthService => _authenticationService.Value;
    }
}