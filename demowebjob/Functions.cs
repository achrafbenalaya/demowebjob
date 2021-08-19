using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace demowebjob
{
    public class Functions
    {
        public static void Run([TimerTrigger("0 * * * * *")] TimerInfo myTimer, ILogger log)
        {

            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            log.LogInformation("doing some job");
        }
    }

}
