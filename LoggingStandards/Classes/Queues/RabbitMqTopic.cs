//using System;
//using System.Text;
//using System.Threading.Tasks;
//using CerberusLogging.Interfaces.SendMessage;
//using RabbitMQ.Client;

//namespace CerberusLogging.Classes.Queues
//{
//    public class RabbitMqTopic : ISendMessage
//    {
//        //private readonly string _routingKey;
//        private readonly string _routingKey;

//        public RabbitMqQueue(string routingKey)
//        {
//            _routingKey = routingKey;
//        }

//        public async Task<bool> SendMessageAsync(string message, Guid messageId)
//        {
//            try
//            {
//                var factory = new ConnectionFactory() { HostName = "localhost" };
//                using (var connection = factory.CreateConnection())
//                using (var channel = connection.CreateModel())
//                {
//                    channel.ExchangeDeclare(exchange: "topic_logs",
//                                            type: "topic");



//                    var body = Encoding.UTF8.GetBytes(message);
//                    channel.BasicPublish(exchange: "topic_logs",
//                                         routingKey: _routingKey,
//                                         basicProperties: null,
//                                         body: body);
//                    Console.WriteLine(messageId + " was sent");

//                    return true;
//                }
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine(messageId + " was not sent");
//                return false;
//            }
//        }
//    }
//}
