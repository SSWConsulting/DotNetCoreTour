using System.Threading.Tasks;
using NorthwindTraders.Application.Customers.Queries.GetCustomerDetail;

namespace NorthwindTraders.Application.Customers.Commands.UpdateCustomer
{
    public interface IUpdateCustomerCommand
    {
        Task<CustomerDetailModel> Execute(UpdateCustomerModel model);
    }
}
