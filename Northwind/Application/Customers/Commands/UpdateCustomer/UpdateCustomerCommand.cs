using Microsoft.EntityFrameworkCore;
using NorthwindTraders.Persistence;
using System.Threading.Tasks;
using NorthwindTraders.Application.Customers.Queries.GetCustomerDetail;

namespace NorthwindTraders.Application.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerCommand : IUpdateCustomerCommand
    {
        private readonly NorthwindContext _context;
        private readonly IGetCustomerDetailQuery _getCustomerDetailQuery;

        public UpdateCustomerCommand(NorthwindContext context, 
            IGetCustomerDetailQuery getCustomerDetailQuery)
        {
            _context = context;
            _getCustomerDetailQuery = getCustomerDetailQuery;
        }

        public async Task<CustomerDetailModel> Execute(UpdateCustomerModel model)
        {
            var entity = await _context.Customers.SingleAsync(c => c.CustomerId == model.Id);

            entity.Address = model.Address;
            entity.City = model.City;
            entity.CompanyName = model.CompanyName;
            entity.ContactName = model.ContactName;
            entity.ContactTitle = model.ContactTitle;
            entity.Country = model.Country;
            entity.Fax = model.Fax;
            entity.Phone = model.Phone;
            entity.PostalCode = model.PostalCode;

            await _context.SaveChangesAsync();

            return await _getCustomerDetailQuery.Execute(entity.CustomerId);
        }
    }
}
