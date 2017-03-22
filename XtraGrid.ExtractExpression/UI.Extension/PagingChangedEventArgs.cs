using System;
using Infrastructure;

namespace UI.Extension
{
    public class PagingChangedEventArgs : EventArgs
    {
        public Page Page { get; set; }
        public EnumPageMode PagingMode { get; set; }
    }
}