using Microsoft.AspNetCore.Mvc;
using TwilioSms.API.Models;
using TwilioSms.API.Services;

namespace TwilioSms.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController(ISmsService smsService) : ControllerBase
    {
        private readonly ISmsService _smsService = smsService;

        [HttpPost]
        public void SendSms(SmsSenderModel model)
        {
            _smsService.SendSms(model.PhoneNumber);
        }
    }
}
