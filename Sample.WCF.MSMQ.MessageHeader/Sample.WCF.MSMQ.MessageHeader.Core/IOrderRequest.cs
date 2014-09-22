using System.ServiceModel;

namespace Sample.WCF.MSMQ.MessageHeader.Core
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