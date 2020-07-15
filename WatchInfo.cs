using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace FunctionApp1
{
    public static class WatchInfo
    {
        [FunctionName("WatchInfo")]
        public static async Task<ActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation($"{nameof(WatchInfo)} HTTP trigger function processed a request.");

            if ((string)req.Query["model"] is var model && model is { })
            {
                // Dummy data for now
                var watchinfo = new
                {
                    Manufacturer = "Orient",
                    CaseType = "Solid",
                    Bezel = "Titanium",
                    Dial = "Roman",
                    CaseFinish = "Silver",
                    Jewels = 15,
                };
                return new OkObjectResult(watchinfo);
            }
            return new BadRequestObjectResult("Please provide a watch model in the query string");
        }
    }
}
