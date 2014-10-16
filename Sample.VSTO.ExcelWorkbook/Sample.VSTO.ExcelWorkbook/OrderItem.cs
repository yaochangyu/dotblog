using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.VSTO.ExcelWorkbook
{
    public class OrderItem
    {
        public OrderItem(Guid productID, string productName, decimal unitPrice, int quantity)
        {
            this.ProductID = productID;
            this.ProductName = productName;
            this.UnitPrice = unitPrice;
            this.Quantity = quantity;
        }

        public Guid ProductID { get; set; }

        public string ProductName { get; set; }

        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }
    }
}