using Microsoft.Office.Tools.Excel;
using Microsoft.VisualStudio.Tools.Applications.Runtime;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;

namespace Sample.VSTO.ExcelWorkbook
{
    public partial class Sheet1
    {
        private void Sheet1_Startup(object sender, System.EventArgs e)
        {
        }

        private void Sheet1_Shutdown(object sender, System.EventArgs e)
        {
        }

        #region VSTO Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.GetAllData_button.Click += new System.EventHandler(this.GetAllData_button_Click);
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.Startup += new System.EventHandler(this.Sheet1_Startup);
            this.Shutdown += new System.EventHandler(this.Sheet1_Shutdown);
        }

        #endregion VSTO Designer generated code

        private void GetAllData_button_Click(object sender, EventArgs e)
        {
            //建立假資料
            var orders = new List<Order>()
            {
                new Order()
                {
                    OrderNo =Guid.NewGuid(),
                    OrderDate = DateTime.Now,
                    SupplierID = Guid.NewGuid(),
                    SupplierName = "鼎王",
                    OrderItems = new List<OrderItem>()
                    {
                        new OrderItem(Guid.NewGuid(),"泡麵",20,12),
                        new OrderItem(Guid.NewGuid(),"米粉",10,22),
                    }
                },
                new Order()
                {
                    OrderNo =Guid.NewGuid(),
                    OrderDate = DateTime.Now,
                    SupplierID = Guid.NewGuid(),
                    SupplierName = "未王"
                },
            };

            list1.DataSource = orders;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //建立假資料
            var orders = new List<Order>()
            {
                new Order()
                {
                    OrderNo =Guid.NewGuid(),
                    OrderDate = DateTime.Now,
                    SupplierID = Guid.NewGuid(),
                    SupplierName = "鼎王",
                    //OrderItems = new List<OrderItem>()
                    //{
                    //    new OrderItem(Guid.NewGuid(),"泡麵",20,12),
                    //    new OrderItem(Guid.NewGuid(),"米粉",10,22),
                    //}
                },
                new Order()
                {
                    OrderNo =Guid.NewGuid(),
                    OrderDate = DateTime.Now,
                    SupplierID = Guid.NewGuid(),
                    SupplierName = "未王"
                },
            };
            //var aa = Cells[6, 1];
            //var bb = Cells[6, 1];

            //var cc = this.Range["A6:E6"];
            //cc.Select();

            //var array = new object[1, 3];
            //for (var i = 0; i < 3; i++)
            //{
            //    array[0, i] = i;
            //}

            //var firstCell = this.Cells[1, 1];
            //var lastCell = this.Cells[1, 3];
            //var range = this.Range[firstCell, lastCell];
            //range.Value2 = array;
        }
    }
}