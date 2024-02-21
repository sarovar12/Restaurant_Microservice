﻿using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Restaurant.MessageBus.Interfaces;
using System.Text;

namespace Restaurant.MessageBus.Services
{
    public class MessageBus : IMessageBus
    {
        private readonly IConfiguration _configuration;
        public MessageBus(IConfiguration configuration)
        {
           _configuration = configuration;

        }
        public async Task PublishMessage(object message, string topic_queue_Name, string connectionString)
        {

            await using var client = new ServiceBusClient(connectionString);
            ServiceBusSender sender = client.CreateSender(topic_queue_Name);
            var jsonMessage = JsonConvert.SerializeObject(message);
            ServiceBusMessage finalMessage = new ServiceBusMessage(Encoding
                .UTF8.GetBytes(jsonMessage))
            {
                CorrelationId = Guid.NewGuid().ToString(),
            };

            await sender.SendMessageAsync(finalMessage);
            await client.DisposeAsync();
        }
    }
}
