using Simple.ObjectDataSourceSession.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI.WebControls;

namespace Simple.ObjectDataSourceSession.Controls
{
    [DataObject(true)]
    public class OrderUseCase
    {
        private List<Order> _Orders = null;

        public OrderUseCase()
        {
            if (HttpContext.Current.Session["SESSION_ORDER"] == null)
            {
                this._Orders = Order.GetOrders().ToList();
                HttpContext.Current.Session["SESSION_ORDER"] = _Orders;
            }
            else
            {
                this._Orders = HttpContext.Current.Session["SESSION_ORDER"] as List<Order>;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public IEnumerable<Order> GetAllOrders()
        {
            return this._Orders;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public IEnumerable<OrderItem> GetAllOrderItems(Guid orderNo)
        {
            var queryOrder = this._Orders.SingleOrDefault(o => o.OrderNo == orderNo);
            if (queryOrder == null)
            {
                return null;
            }

            var queryOrderItems = queryOrder.OrderItems.Where(o => o.OrderNo == orderNo);
            return queryOrderItems;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public IEnumerable<OrderItem> GetAllOrderItems(Guid orderNo, string SupplierName)
        {
            var queryOrder = this._Orders.SingleOrDefault(o => o.OrderNo == orderNo);
            if (queryOrder == null)
            {
                return null;
            }

            var queryOrderItems = queryOrder.OrderItems.Where(o => o.OrderNo == orderNo);
            return queryOrderItems;
        }
    }
}