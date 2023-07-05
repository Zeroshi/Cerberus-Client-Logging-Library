using System;
using System.Text;
using System.Threading.Tasks;
using CerberusLogging.Interfaces.SendMessage;
using RabbitMQ.Client;

namespace CerberusLogging.Classes.Queues
{
    public class RabbitMqQueue : ISendMessage, IDisposable
    {
        private readonly string _queueName;
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public RabbitMqQueue(string connectionString, string queueName)
        {
            _queueName = queueName;

            //Create RabbitMq connection
            var factory = new ConnectionFactory { Uri = new Uri(connectionString) };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            _channel.QueueDeclare(queue: _queueName, durable: true, exclusive: false, autoDelete: false, arguments: null);
        }

        public async Task<bool> SendMessageAsync(string message, Guid messageId)
        {
            try
            {
                var body = Encoding.UTF8.GetBytes(message);
                await Task.Run(() => _channel.BasicPublish(exchange: "", routingKey: _queueName, basicProperties: null, body: body));

                Console.WriteLine($@"{messageId} was sent");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($@"{messageId} was not sent. Error: {ex}");
                return false;
            }
        }

        public void Dispose()
        {
            _channel.Dispose();
            _connection.Dispose();
        }
    }
}