using System;
using Microsoft.EntityFrameworkCore;
using NorthwindTraders.Domain;
using NorthwindTraders.Persistence;

namespace NorthwindTraders.Application.UnitTests.Infrastructure
{
	public class NorthwindContextFactory
	{
		public static NorthwindContext Create()
		{
			var options = new DbContextOptionsBuilder<NorthwindContext>()
				.UseInMemoryDatabase(Guid.NewGuid().ToString())
				.Options;

			var context = new NorthwindContext(options);

			context.Database.EnsureCreated();

			context.Customers.AddRange(new[] {
				new Customer { CustomerId = "ADAM", ContactName = "Adam Cogan" },
				new Customer { CustomerId = "JASON", ContactName = "Jason Taylor" },
				new Customer { CustomerId = "BREND", ContactName = "Brendan Richards" },
			});

			context.SaveChanges();

			return context;
		}

		public static void Destroy(NorthwindContext context)
		{
			context.Database.EnsureDeleted();

			context.Dispose();
		}
	}
}