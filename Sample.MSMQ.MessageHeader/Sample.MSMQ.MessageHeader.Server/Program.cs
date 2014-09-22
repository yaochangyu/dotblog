using Sample.MSMQ.MessageHeader.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Messaging;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Sample.MSMQ.MessageHeader.Server
{
    internal class Program
    {
        public static String HOST_QUEUE_Order = ConfigurationManager.AppSettings["HOST_QUEUE_Order"];

        private static void Main(string[] args)
        {
            CreateSelfHostOrder();
            //CreateSelfHostOrderTaker();
        }

        public static void CreateSelfHostOrder()
        {
            if (!MessageQueue.Exists(HOST_QUEUE_Order))
            {
                MessageQueue.Create(HOST_QUEUE_Order, true);
                Console.WriteLine("佇列不存在.新增佇列");
            }
            else
            {
                Console.WriteLine("佇列已存在.");
            }

            ServiceHost selfHost = new ServiceHost(typeof(OrderRequest));

            selfHost.Opened += (o, e) =>
            {
                Console.WriteLine("接收端服務就緒.開始監聽....\n");
            };
            selfHost.Faulted += (o, e) =>
            {
                Console.WriteLine("接收端服務發生錯誤....\n");
                Console.WriteLine("按任意鍵離開服務.....");
                Console.ReadKey();
            };
            selfHost.UnknownMessageReceived += (o, e) =>
            {
                Console.WriteLine("接收端服務接收到未知的訊息....\n");
            };

            selfHost.Open();
            Console.WriteLine("按任意鍵離開服務.....");
            Console.ReadKey();

            try
            {
                if (selfHost.State == CommunicationState.Opened)
                {
                    selfHost.Close();
                }
            }
            catch (CommunicationObjectFaultedException)
            {
                Console.WriteLine(" Service cannot be closed...it already faulted");
            }
        }
    }
}