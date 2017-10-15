using System.Threading.Tasks;
using Xunit;
using NorthwindTraders.Application.UnitTests.Infrastructure;
using NorthwindTraders.Application.Customers.Commands.CreateCustomer;

namespace NorthwindTraders.Application.UnitTests.Customers.Commands
{
    public class CreateCustomerCommandTests : CommandTestBase
    {
        [Fact]
        public async Task ShouldInsertCustomerIntoDatabase()
        {
            var command = new CreateCustomerCommand(_context);

            var model = new CreateCustomerModel
            {
                Id = "FLYNN",
                CompanyName = "Flynn's Arcade",
                ContactName = "Kevin"
            };

            await command.Execute(model);

            var entity = await _context.Customers.FindAsync("FLYNN");

            Assert.NotNull(entity);
        }
    }
}