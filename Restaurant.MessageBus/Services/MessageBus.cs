

using Azure.Messaging.ServiceBus;
using Restaurant.MessageBus.Interfaces;

namespace Restaurant.MessageBus.Services
{
    public class MessageBus : IMessageBus
    {
        public async Task PublishMessage(object message, string topic_queue_Name)
        {
            await using var client = new ServiceBusClient();
        }
    }
}
