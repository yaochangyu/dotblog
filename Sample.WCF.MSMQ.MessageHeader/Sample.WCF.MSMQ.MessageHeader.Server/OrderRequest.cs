using Sample.WCF.MSMQ.MessageHeader.Core;
using System;
using System.ServiceModel;

namespace Sample.WCF.MSMQ.MessageHeader.Server
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class OrderRequest : IOrderRequest
    {
        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public void Submit(Order order)
        {
            Console.WriteLine("訂單處理成功\n\tOrderId: {0}\n\tSession Id: {1}", order.OrderId, OperationContext.Current.SessionId);
            try
            {
                var extension = OperationContext.Current.IncomingMessageHeaders.GetHeader<string>("Order",
                                         "Sample.MSMQ.MessageHeader.Core");
                if (!string.IsNullOrWhiteSpace(extension))
                {
                    Console.WriteLine("\t擴充欄位訊息\n\tExtension：{0}", extension);
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}