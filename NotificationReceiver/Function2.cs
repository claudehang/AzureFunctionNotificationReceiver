using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace NotificationReceiver
{
    public static class Function2
    {
        [FunctionName("Function2")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("\n\n\n==================");
            var content = await new StreamReader(req.Body).ReadToEndAsync();

            string responseMessage = $"This HTTP triggered function executed successfully. content =\n{content}";
            log.LogInformation($"content = {content}");
            return new OkObjectResult(responseMessage);
        }
    }
}
