using System.Threading.Tasks;
using NorthwindTraders.Application.Customers.Commands.DeleteCustomer;
using Xunit;
using NorthwindTraders.Application.UnitTests.Infrastructure;

namespace NorthwindTraders.Application.UnitTests.Customers.Commands
{
    public class DeleteCustomerCommandTests : CommandTestBase
    {
        [Fact]
        public async Task ShouldDeleteCustomerFromDatabase()
        {
            var command = new DeleteCustomerCommand(_context);

            await command.Execute("JASON");

            var entity = await _context.Customers.FindAsync("JASON");

            Assert.Null(entity);
        }
    }
}