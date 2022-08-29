using RabbitMQ.Client;
using TheBestWayServerWorkerServices.EmailWorkerService.MailServices;
using TheBestWayShared.SharedForWorkerService.RabbitMQ;

namespace TheBestWayServerWorkerServices.EmailWorkerService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IHost host = Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostBuilder, services) =>
                {
                    services.AddSingleton<IRabbitMQClientService, RabbitMQClientService>();
                    services.AddSingleton<IConnectionFactory>(serviceProvider => new ConnectionFactory() { Uri = new Uri(hostBuilder.Configuration.GetConnectionString("RabbitMQ")) });
                    services.AddSingleton(typeof(SendMailService));
                    services.AddHostedService<Worker>();
                })
                .Build();

            host.Run();
        }
    }
}