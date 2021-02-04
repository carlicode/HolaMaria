using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace HolaMaria
{
    public static class Function1
    {
        [FunctionName("AddStudent")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "student")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            //Parse the request

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var parameters = requestBody.Split('&').ToDictionary(x => x.Split('=')[0].ToLower(), x => x.Split('=')[1]);
            var memory = JObject.Parse(HttpUtility.UrlDecode(parameters["memory"]));
            var answers = memory["twili"]["collected_data"]["add_student"]["answers"];

            //return a valid response to Twilio
            var response = new
            {
                actions = new[]
                {
                    new { say = $"Thanks, now, let us start with your doubts, what is your question? "}
                }
            };
            return new JsonResult(response);
        }
    }
}
