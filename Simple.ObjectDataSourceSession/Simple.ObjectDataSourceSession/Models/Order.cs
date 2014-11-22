using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Simple.ObjectDataSourceSession.Models
{
    public class Order
    {
        public static IEnumerable<Order> GetOrders()
        {
            List<Order> results = new List<Order>();
            //var order = new Order(Guid.NewGuid(), new DateTime(2011, 11, 23, 2, 11, 2), Guid.NewGuid(), "華逤");
            var orderA = new Order()
            {
                OrderNo = Guid.NewGuid(),
                OrderDate = new DateTime(2011, 11, 23, 2, 11, 2),
                SupplierId = Guid.NewGuid(),
                SupplierName = "Afa",
            };
            var orderB = new Order()
            {
                OrderNo = Guid.NewGuid(),
                OrderDate = new DateTime(2012, 1, 23, 3, 9, 22),
                SupplierId = Guid.NewGuid(),
                SupplierName = "Bfa",
            };
            var orderItemAs = new List<OrderItem>()
            {
                new OrderItem()
                {
                    OrderNo = orderA.OrderNo,
                    ProductId="T111",
                    ProductName="NB",
                    Quantity = 2,
                    UnitPrice = (decimal)11.2
                },
                new OrderItem()
                {
                    OrderNo = orderA.OrderNo,
                    ProductId="T112",
                    ProductName="NB1",
                    Quantity = 12,
                    UnitPrice = (decimal)41.3
                },
            };
            var orderItemBs = new List<OrderItem>()
            {
                new OrderItem()
                {
                    OrderNo = orderB.OrderNo,
                    ProductId="G311",
                    ProductName="Fan",
                    Quantity = 22,
                    UnitPrice = (decimal)121.3
                },
                new OrderItem()
                {
                    OrderNo = orderB.OrderNo,
                    ProductId="T32",
                    ProductName="Battery",
                    Quantity = 32,
                    UnitPrice = (decimal)51.9
                },
                new OrderItem()
                {
                    OrderNo = orderB.OrderNo,
                    ProductId="T232",
                    ProductName="Software",
                    Quantity = 9,
                    UnitPrice = (decimal)99
                },
            };
            orderA.OrderItems = orderItemAs;
            orderB.OrderItems = orderItemBs;
            results.Add(orderA);
            results.Add(orderB);
            return results;
        }

        public Order()
        {
            if (this.OrderItems == null)
                this.OrderItems = new List<OrderItem>();
        }

        public Guid OrderNo { get; set; }

        public DateTime OrderDate { get; set; }

        public Guid SupplierId { get; set; }

        public string SupplierName { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }

        public override string ToString()
        {
            string description =
                string.Format(
                    "General Informaion:\n\tOrder No.\t: {0}\n\tOrder Date\t: {1}\n\tSupplier No.\t: {2}\n\tSupplier Name\t: {3}",
                    this.OrderNo,
                    this.OrderDate.ToString("yyyy/MM/dd"),
                    this.SupplierId,
                    this.SupplierName);
            StringBuilder productList = new StringBuilder();
            productList.AppendLine("\nProducts:");

            int index = 0;
            foreach (OrderItem item in this.OrderItems)
            {
                productList.AppendLine(
                    string.Format("\n{4}. \tNo.\t\t: {0}\n\tName\t\t: {1}\n\tPrice\t\t: {2}\n\tQuantity\t: {3}",
                        item.ProductId,
                        item.ProductName,
                        item.UnitPrice,
                        item.Quantity, ++index));
            }

            return description + productList.ToString();
        }
    }
}