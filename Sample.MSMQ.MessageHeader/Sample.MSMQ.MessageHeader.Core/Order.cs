using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Sample.MSMQ.MessageHeader.Core
{
    [DataContract]
    public class Order
    {
        [DataMember]
        public Guid OrderId { get; set; }

        [DataMember]
        public DateTime OrderDate { get; set; }

        public override string ToString()
        {
            return string.Format("Order Info:\nOrder Id:{0}\nOrder Date:{1}", OrderId, OrderDate);
        }
    }
}