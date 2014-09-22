using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Sample.MSMQ.Priority
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var queueName = ConfigurationManager.AppSettings["MSMQ_Name"];
            if (!MessageQueue.Exists(queueName))
            {
                MessageQueue.Create(queueName, false);
            }

            Send(MessagePriority.Normal, "1 Message Body.");
            Send(MessagePriority.Highest, "2 Message Body.");
            Send(MessagePriority.Lowest, "3 Message Body.");
            Send(MessagePriority.Low, "4 Message Body.");
            Send(MessagePriority.Highest, "5 Message Body.");
            Console.WriteLine("訊息發送成功，按任意鍵繼續");
            Console.ReadKey();
            Receive();
            Console.WriteLine("訊息接收成功，按任意鍵離開");
            Console.ReadKey();
        }

        public static void Send(MessagePriority priority, string messageBody)
        {
            var queueName = ConfigurationManager.AppSettings["MSMQ_Name"];
            MessageQueue queue = new MessageQueue(queueName);

            Message message = new Message();
            message.Body = messageBody;
            message.Label = messageBody;
            message.Priority = priority;
            queue.Send(message);
        }

        public static void Receive()
        {
            var queueName = ConfigurationManager.AppSettings["MSMQ_Name"];
            MessageQueue queue = new MessageQueue(queueName);
            queue.MessageReadPropertyFilter.Priority = true;
            queue.Formatter = new XmlMessageFormatter(new Type[] { typeof(string) });

            try
            {
                var length = queue.GetAllMessages().Length;
                var index = 0;
                while (true)
                {
                    if (length <= 0)
                    {
                        break;
                    }

                    var message = queue.Receive();
                    Console.WriteLine("Priority:{0} ,Body:{1}", message.Priority, message.Body);
                    index++;
                    if (index == length)
                    {
                        break;
                    }
                }

                //var messages = queue.GetAllMessages().Length;
                //foreach (var message in messages)
                //{
                //}
                //var aa = queue.Peek();
            }
            catch (MessageQueueException)
            {
                // Handle Message Queuing exceptions.
            }
            // Handle invalid serialization format.
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}