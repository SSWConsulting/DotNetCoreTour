using System.Threading.Tasks;
using NorthwindTraders.Application.Customers.Queries.GetCustomerDetail;
using NorthwindTraders.Application.UnitTests.Infrastructure;
using NorthwindTraders.Persistence;
using Xunit;

namespace NorthwindTraders.Application.UnitTests.Customers.Queries
{
	[Collection("QueryCollection")]
    public class GetCustomerDetailQueryTests
    {
        private readonly NorthwindContext _context;

        public GetCustomerDetailQueryTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
        }

        [Fact]
        public async Task ShouldReturnCustomerDetailGivenValidId()
        {
            var query = new GetCustomerDetailQuery(_context);

            var result = await query.Execute("JASON");

            Assert.NotNull(result);
            Assert.Equal("JASON", result.Id);
            Assert.Equal("Jason Taylor", result.ContactName);
        }
    }
}