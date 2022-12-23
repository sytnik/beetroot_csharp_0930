using Microsoft.AspNetCore.Mvc;

namespace Lesson33Api2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DataController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<DataController> _logger;

        public DataController(ILogger<DataController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public void Post(FormData data)
        {
            var name = data.textName;
        }

        public record FormData(string? textName, string? description, int someNumeric);
    }
}