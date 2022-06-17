using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Linq;

namespace APTestFunctionApp1
{
    public static class WellKnown
    {
        [FunctionName("WellKnown")]
        public static async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = ".well-known/{p1?}")] HttpRequest req,
        string p1,
        ExecutionContext context
    )
        {
            string root = context.FunctionAppDirectory;

            string filePath = Path.Combine(root, ".well-known", p1);

            return File.Exists(filePath) ?
                    (IActionResult)new FileStreamResult(File.OpenRead(filePath), "text/css; charset=utf-8") :
                    new NotFoundResult();
        }
    }
}
