using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DTO;
using ActionFilters;
using Shared.RequestFeatures;
using System.Dynamic;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController:ControllerBase
    {
        private readonly IServiceManager _service;

        public CustomerController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomersAsync([FromQuery] RequestParameters requestParams)
        {
            var response = await this._service.CustomerService.GetAllCustomersAsync(requestParams);
            Response.Headers.Add("numberOfPages", response.numberOfPages.ToString());
            dynamic expandoObject = new ExpandoObject();
            expandoObject.data = response.customers;
            expandoObject.numbOfPages = response.numberOfPages;
            return Ok(expandoObject);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCustomer(int id)
        {
            return Ok(await this._service.CustomerService.GetCustomerFullDetailsAsync(id,false));
        }

        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] CustomerModificationDto customerDto)
        {
            await this._service.CustomerService.CreateCustomerAsync(customerDto);
            return Ok();
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            await this._service.CustomerService.DeleteCustomerAsync(id);
            return NoContent();
        }
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateCustomer(int id,[FromBody] CustomerModificationDto company)
        {
            await _service.CustomerService.UpdateCustomerAsync(id, company);
            return NoContent();
        }
    }
}
