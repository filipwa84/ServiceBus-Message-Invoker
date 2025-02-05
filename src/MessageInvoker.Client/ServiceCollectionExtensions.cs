﻿using Azure.Messaging.ServiceBus.Invoker;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure.Messaging.ServiceBus.Invoker
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServiceBusMessageInvocationClient(this IServiceCollection services, string connectionString)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            return services.AddSingleton<IMessageInvocationClient>(provider => new MessageInvocationClient(provider, connectionString, ServiceBusTransportType.AmqpWebSockets));
        }

        public static IServiceCollection AddServiceBusMessageInvocationClient(this IServiceCollection services, string connectionString, ServiceBusTransportType transportType)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            return services.AddSingleton<IMessageInvocationClient>(provider => new MessageInvocationClient(provider, connectionString, transportType));
        }
    }
}
