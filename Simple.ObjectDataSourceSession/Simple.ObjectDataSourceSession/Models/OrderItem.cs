using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Simple.ObjectDataSourceSession.Models
{
    public class OrderItem
    {
        public Guid OrderNo { get; set; }

        public string ProductId { get; set; }

        public string ProductName { get; set; }

        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }
    }
}