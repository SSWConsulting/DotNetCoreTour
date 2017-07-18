using System;
using System.Collections.Generic;
using System.Text;

namespace NorthwindTraders.Application.Customers.Queries.GetCustomerOrders
{
    public class CustomerOrdersQueryModel
    {
        public int? PageIndex { get; set; } = 0;

        public int? PageSize { get; set; } = 5;

        public string NameSearch { get; set; }

        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }
    }
}
