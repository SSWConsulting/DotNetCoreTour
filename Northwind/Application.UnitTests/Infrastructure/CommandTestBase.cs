using System;
using NorthwindTraders.Persistence;

namespace NorthwindTraders.Application.UnitTests.Infrastructure
{
	public class CommandTestBase : IDisposable
	{
		protected readonly NorthwindContext _context;

		public CommandTestBase()
		{
			_context = NorthwindContextFactory.Create();
		}

		public void Dispose()
		{
			NorthwindContextFactory.Destroy(_context);
		}
	}
}