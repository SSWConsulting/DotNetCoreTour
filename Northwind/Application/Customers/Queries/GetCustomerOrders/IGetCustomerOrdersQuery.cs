using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindTraders.Application.Customers.Queries.GetCustomerOrders
{
    public interface IGetCustomerOrdersQuery
    {
        Task<IEnumerable<CustomerOrdersModel>> Execute(CustomerOrdersQueryModel queryModel);
    }
}
