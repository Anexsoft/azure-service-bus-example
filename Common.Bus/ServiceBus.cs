using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;

namespace Common.Bus
{
    public interface IServiceBus 
    {
        QueueClient GetQueueClient(string queue);
    }

    public class ServiceBus : IServiceBus
    {
        private readonly IConfiguration _configuration;

        public ServiceBus(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public QueueClient GetQueueClient(string queue)
        {
            return new QueueClient(
                _configuration.GetValue<string>("AzureServiceBusConnectionString"),
                queue
            );
        }
    }
}
