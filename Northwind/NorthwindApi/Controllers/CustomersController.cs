using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NorthwindTraders.Application.Customers.Commands.CreateCustomer;
using NorthwindTraders.Application.Customers.Commands.DeleteCustomer;
using NorthwindTraders.Application.Customers.Commands.UpdateCustomer;
using NorthwindTraders.Application.Customers.Queries.GetCustomerDetail;
using NorthwindTraders.Application.Customers.Queries.GetCustomersList;

namespace NorthwindTraders.NorthwindApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Customers")]
    public class CustomersController : Controller
    {
        private readonly IGetCustomersListQuery _getCustomersListQuery;
        private readonly IGetCustomerDetailQuery _getCustomerDetailQuery;
        private readonly ICreateCustomerCommand _createCustomerCommand;
        private readonly IUpdateCustomerCommand _updateCustomerCommand;
        private readonly IDeleteCustomerCommand _deleteCustomerCommand;

        public CustomersController(
            IGetCustomersListQuery getCustomersListQuery,
            IGetCustomerDetailQuery getCustomerDetailQuery,
            ICreateCustomerCommand createCustomerCommand,
            IUpdateCustomerCommand updateCustomerCommand,
            IDeleteCustomerCommand deleteCustomerCommand)
        {
            _getCustomersListQuery = getCustomersListQuery;
            _getCustomerDetailQuery = getCustomerDetailQuery;
            _createCustomerCommand = createCustomerCommand;
            _updateCustomerCommand = updateCustomerCommand;
            _deleteCustomerCommand = deleteCustomerCommand;
        }

        // GET api/customers
        [HttpGet]
        public async Task<IEnumerable<CustomerListModel>> Get()
        {
            return await _getCustomersListQuery.Execute();
        }

        // GET api/customers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute]string id)
        {
            var customer = await _getCustomerDetailQuery.Execute(id);
            if (customer == null)
            {
                return NotFound();
            }

            return new ObjectResult(customer);
        }

        // POST api/customers
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateCustomerModel customer)
        {
            if (customer == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _createCustomerCommand.Execute(customer);

            return CreatedAtRoute("Create", new { customer.Id }, customer);
        }

        
        // PUT api/customers/5
        [HttpPut("{id}")]
        [ValidateModel]
        public async Task<CustomerDetailModel> Update(string id, [FromBody]UpdateCustomerModel customer)
        {
            return await _updateCustomerCommand.Execute(customer);
        }

        
        // DELETE api/customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute]string id)
        {
            await _deleteCustomerCommand.Execute(id);

            return new NoContentResult();
        }
    }
}