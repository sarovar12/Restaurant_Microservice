﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.MessageBus.Interfaces
{
    public interface IMessageBus
    {
        Task PublishMessage(object message,string topic_queue_Name, string connectionString);
    }
}
