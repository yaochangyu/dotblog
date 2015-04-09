using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Simple.OperCookie
{
    internal class Info
    {
        public string Name { get; set; }

        public string Path { get; set; }

        public DateTime Stamp { get; set; }

        public string Data { get; set; }

        public Guid Id { get; set; }
    }
}