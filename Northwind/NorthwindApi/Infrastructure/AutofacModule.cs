using System.Reflection;
using Autofac;
using NorthwindTraders.Application.Customers.Commands.CreateCustomer;
using NorthwindTraders.Application.Customers.Commands.DeleteCustomer;
using NorthwindTraders.Application.Customers.Commands.UpdateCustomer;
using NorthwindTraders.Application.Customers.Queries.GetCustomerDetail;
using NorthwindTraders.Application.Customers.Queries.GetCustomersList;
using Module = Autofac.Module;

namespace NorthwindTraders.NorthwindApi.Infrastructure
{
    public class AutofacModule : Module
    {
        

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes((typeof(GetCustomersListQuery)).GetTypeInfo().Assembly)
                .Where(t => t.Name.EndsWith("Command") || t.Name.EndsWith("Query"))
                .AsImplementedInterfaces();
        }

    }
}
