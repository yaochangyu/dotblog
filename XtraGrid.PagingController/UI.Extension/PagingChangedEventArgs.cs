using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Infrastructure;

namespace UI.Extension
{
    public class PagingChangedEventArgs : EventArgs
    {
        public Page Page { get; set; }
        public EnumPageMode PagingMode { get; set; }
    }
}
