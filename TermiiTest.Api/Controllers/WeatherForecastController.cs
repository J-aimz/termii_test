using Microsoft.AspNetCore.Mvc;
using Termii.Core.Models.Services.Foundations.Termii.Switch;

namespace TermiiTest.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly ITermiiMessagingService _termiiMessagingService;

        public WeatherForecastController(ITermiiMessagingService termiiMessagingService)
        {
            _termiiMessagingService = termiiMessagingService;
        }

        [HttpGet("send-messages")]
        public async Task<IActionResult> SendMessages()
        {
            await _termiiMessagingService.SendMessage();
            return Ok();
        }
    }
}
