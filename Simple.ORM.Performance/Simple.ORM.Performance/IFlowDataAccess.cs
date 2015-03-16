using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.ORM.Performance
{
    public interface IFlowDataAccess
    {
        int RowCount { get; set; }

        object GetAllInventory();
    }
}