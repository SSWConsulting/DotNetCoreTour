using System.Threading.Tasks;
using NorthwindTraders.Application.Customers.Commands.UpdateCustomer;
using Xunit;
using NorthwindTraders.Application.UnitTests.Infrastructure;
using NorthwindTraders.Application.Customers.Queries.GetCustomerDetail;

namespace NorthwindTraders.Application.UnitTests.Customers.Commands
{
    public class UpdateCustomerCommandTests : CommandTestBase
    {
        [Fact]
        public async Task ShouldUpdateCustomerInDatabase()
        {
			var customerDetailQuery = new GetCustomerDetailQuery(_context);
			var command = new UpdateCustomerCommand(_context, customerDetailQuery);

            var model = new UpdateCustomerModel {
                Id = "JASON",
                CompanyName = "Jason Inc",
                ContactName = "Jason Taylor"
            };

            await command.Execute(model);

            var entity = await _context.Customers.FindAsync("JASON");

            Assert.Equal("Jason Inc", entity.CompanyName);
        }
    }
}