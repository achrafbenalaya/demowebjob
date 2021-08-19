using Microsoft.Extensions.Hosting;
using System;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.WebJobs;

namespace demowebjob
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new HostBuilder();
            builder.ConfigureWebJobs(b =>
            {
                b.AddAzureStorageCoreServices();
                b.AddAzureStorage();
            });
            builder.ConfigureLogging((loggingBuilder) =>
            {
                loggingBuilder.AddConsole();
            });

            var host = builder.Build();
            using (host)
            {
                host.Run();
            }
        }


        public class Functions
        {
            public static void ProcessQueueMessage([QueueTrigger("my-queue")] string message, ILogger logger)
            {
                logger.LogInformation("START of Execution of your Web Job");
                logger.LogInformation(message);
                logger.LogInformation("END of Execution of your Web Job");
            }
        }


    }
}
