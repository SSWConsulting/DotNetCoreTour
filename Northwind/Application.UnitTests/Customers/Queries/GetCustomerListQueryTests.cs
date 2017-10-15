using Xunit;
using NorthwindTraders.Application.Customers.Queries.GetCustomersList;
using NorthwindTraders.Persistence;
using System.Threading.Tasks;
using System.Linq;
using NorthwindTraders.Application.UnitTests.Infrastructure;

namespace NorthwindTraders.Application.UnitTests.Customers.Queries
{
	[Collection("QueryCollection")]
    public class GetCustomersListQueryTests
    {
        private readonly NorthwindContext _context;

        public GetCustomersListQueryTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
        }

        [Fact]
        public async Task ShouldReturnAllCustomers()
        {
            var query = new GetCustomersListQuery(_context);

            var result = await query.Execute();

            Assert.Equal(3, result.Count());
        }
    }
}
