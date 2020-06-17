using Common.Bus;
using Inventory.Api.Events.Handlers;
using Inventory.Api.Events.Impl;
using Microsoft.AspNetCore.Builder;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Inventory.Api.Config
{
    public static class EventHandlerUsage
    {
        public static void UseEventHandler(this IApplicationBuilder app) 
        {
            var receiver = app.ApplicationServices.GetService<IServiceBus>();

            // Handlers
            var productStockEventHandler = app.ApplicationServices.GetService<IHandler<IEnumerable<ProductStockEvent>>>();

            Register(receiver, "INVENTORY-STOCK", productStockEventHandler);
        }

        private static void Register<T>(
            IServiceBus service,
            string queue,
            IHandler<T> handler) where T: class
        {
            var client = service.GetQueueClient(queue);

            var messageHandlerOptions = new MessageHandlerOptions(ExceptionReceivedHandler)
            {
                MaxConcurrentCalls = 1,
                AutoComplete = false
            };

            client.RegisterMessageHandler(async (Message message, CancellationToken token) => {
                var payload = JsonSerializer.Deserialize<T>(
                    Encoding.UTF8.GetString(message.Body)
                );

                await client.CompleteAsync(message.SystemProperties.LockToken);
                await handler.Execute(payload);
            }, messageHandlerOptions);
        }

        private static Task ExceptionReceivedHandler(ExceptionReceivedEventArgs exceptionReceivedEventArgs)
        {
            // your custom message log
            return Task.CompletedTask;
        }
    }
}
