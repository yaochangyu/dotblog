using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Sample.MSMQ.MessageHeader.Core
{
    //[ServiceContract()]
    //[ServiceContract(Namespace = "http://Sample.MSMQ.MessageHeader.Core", SessionMode = SessionMode.Required)]
    [ServiceContract(SessionMode = SessionMode.Required)]
    public interface IOrderRequest
    {
        [OperationContract(IsOneWay = true)]
        void Submit(Order order);
    }
}