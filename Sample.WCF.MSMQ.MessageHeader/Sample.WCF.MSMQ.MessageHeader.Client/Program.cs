using Sample.WCF.MSMQ.MessageHeader.Core;
using System;
using System.ServiceModel;
using System.Threading;
using System.Transactions;

namespace Sample.WCF.MSMQ.MessageHeader.Client
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ConnectHostIncludeExtend();
            //ConnectHost();
        }

        internal static void ConnectHost()
        {
            Console.WriteLine("發送端程式啟動");
        label1:
            ChannelFactory<IOrderRequest> proxy = new ChannelFactory<IOrderRequest>("OrderRequest");

            IOrderRequest channel = proxy.CreateChannel();
            Console.WriteLine("按任意鍵繼續，按ESC離開");
            var order = new Order() { OrderId = Guid.NewGuid(), OrderDate = DateTime.Now };
            var key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.Escape)
            {
                Console.WriteLine("再會~!");
                proxy.Close();
                Thread.Sleep(1000);
                return;
            }
            try
            {
                Console.WriteLine(order);

                using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.Required))
                {
                    channel.Submit(order);
                    proxy.Close();
                    transaction.Complete();
                    Console.WriteLine("交易完成");
                }
                goto label1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                goto label1;
            }
        }

        internal static void ConnectHostIncludeExtend()
        {
            Console.WriteLine("發送端程式啟動");
        label1:
            ChannelFactory<IOrderRequest> proxy = new ChannelFactory<IOrderRequest>("OrderRequest");

            IOrderRequest channel = proxy.CreateChannel();
            Console.WriteLine("按任意鍵繼續，按ESC離開");
            var order = new Order() { OrderId = Guid.NewGuid(), OrderDate = DateTime.Now };
            var key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.Escape)
            {
                Console.WriteLine("再會~!");
                Thread.Sleep(1000);
                proxy.Close();
                return;
            }
            try
            {
                using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.Required))
                using (new OperationContextScope(channel as IContextChannel))
                {
                    //用Session關聯
                    var session = OperationContext.Current.SessionId;
                    var extension = string.Format("擴充欄位,Session:{0}", session);
                    var header = new MessageHeader<string>(extension);
                    OperationContext.Current.OutgoingMessageHeaders.Add(
                        header.GetUntypedHeader("Order", "Sample.MSMQ.MessageHeader.Core"));
                    Console.WriteLine(order);
                    Console.WriteLine(extension);

                    channel.Submit(order);
                    proxy.Close();
                    transaction.Complete();
                    Console.WriteLine("交易完成");
                }
                goto label1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                goto label1;
            }
        }
    }
}