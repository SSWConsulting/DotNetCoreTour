using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NorthwindTraders.Application.Customers.Queries.GetCustomerOrders;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace NorthwindTraders.NorthwindApi.Controllers
{
    [Produces("application/json")]
    [Route("api/CustomerOrders")]
    public class CustomerOrdersController : Controller
    {
        private readonly IGetCustomerOrdersQuery _getCustomerOrdersQuery;

        public CustomerOrdersController(IGetCustomerOrdersQuery getCustomerOrdersQuery)
        {
            _getCustomerOrdersQuery = getCustomerOrdersQuery;
        }

        [SwaggerOperation("GetCustomerOrders")]
        [HttpGet]
        public async Task<IEnumerable<CustomerOrdersModel>> GetCustomerOrders([FromQuery]string nameSearch)
        {
            return await _getCustomerOrdersQuery.Execute(new CustomerOrdersQueryModel()
            {
                NameSearch = nameSearch,
                PageIndex = 0,
                PageSize = 5
            });
        }


    }
}
