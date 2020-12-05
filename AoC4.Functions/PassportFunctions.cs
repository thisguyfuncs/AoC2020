using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace AoC4.Functions
{
    public static class PassportFunctions
    {
        [FunctionName("ValidatePassport")]
        public static void Run([ServiceBusTrigger("passport-scanned", Connection = "")]string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");


        }
    }
}
