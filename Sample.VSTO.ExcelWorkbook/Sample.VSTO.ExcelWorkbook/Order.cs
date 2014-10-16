using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace Sample.VSTO.ExcelWorkbook
{
    public class Order
    {
        public Order()
        {
            if (this.OrderItems == null)
                this.OrderItems = new List<OrderItem>();
        }

        public Order(Guid orderNo, DateTime orderDate, Guid supplierID, string supplierName)
        {
            this.OrderNo = orderNo;
            this.OrderDate = orderDate;
            this.SupplierID = supplierID;
            this.SupplierName = supplierName;
        }

        [DisplayName("訂單編號")]
        public Guid OrderNo { get; set; }

        [DisplayName("訂單日期")]
        public DateTime OrderDate { get; set; }

        [DisplayName("供應商編號")]
        public Guid SupplierID { get; set; }

        [DisplayName("供應商名稱")]
        public string SupplierName { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }

        public override string ToString()
        {
            string description = string.Format("General Informaion:\n\tOrder No.\t: {0}\n\tOrder Date\t: {1}\n\tSupplier No.\t: {2}\n\tSupplier Name\t: {3}",
                this.OrderNo,
                this.OrderDate.ToString("yyyy/MM/dd"),
                this.SupplierID,
                this.SupplierName);
            StringBuilder productList = new StringBuilder();
            productList.AppendLine("\nProducts:");

            int index = 0;
            foreach (OrderItem item in this.OrderItems)
            {
                productList.AppendLine(string.Format("\n{4}. \tNo.\t\t: {0}\n\tName\t\t: {1}\n\tPrice\t\t: {2}\n\tQuantity\t: {3}",
                    item.ProductID,
                    item.ProductName,
                    item.UnitPrice,
                    item.Quantity, ++index));
            }

            return description + productList.ToString();
        }
    }
}