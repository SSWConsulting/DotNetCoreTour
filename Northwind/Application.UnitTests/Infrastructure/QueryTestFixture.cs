using System;
using NorthwindTraders.Persistence;
using Xunit;

namespace NorthwindTraders.Application.UnitTests.Infrastructure
{
	public class QueryTestFixture : IDisposable
	{
		public NorthwindContext Context { get; private set; }

		public QueryTestFixture()
		{
			Context = NorthwindContextFactory.Create();
		}

		public void Dispose()
		{
			NorthwindContextFactory.Destroy(Context);
		}
	}

	[CollectionDefinition("QueryCollection")]
	public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}