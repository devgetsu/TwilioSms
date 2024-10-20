using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Rest.Verify.V2.Service;
using Twilio.Types;

namespace TwilioSms.API.Services
{
    public class SmsService : ISmsService
    {
        private readonly string _accountSid;
        private readonly string _authToken;
        private readonly string _serviceSid;
        private readonly IConfiguration _configuration;

        public SmsService(IConfiguration configuration)
        {
            _configuration = configuration;
            _accountSid = _configuration.GetSection("TwilloSettings").GetValue<string>("AccountSid")!;
            _authToken = _configuration.GetSection("TwilloSettings").GetValue<string>("AuthToken")!;
            _serviceSid = _configuration.GetSection("TwilloSettings").GetValue<string>("ServiceId")!;
            TwilioClient.Init(_accountSid, _authToken);
        }

        public void SendSms(string phoneNumber)
        {
            var messageOptions = new CreateMessageOptions(
                new PhoneNumber(phoneNumber));
            messageOptions.From = new PhoneNumber("+19494385214");
            messageOptions.Body = "This is static text.";

            var message = MessageResource.Create(messageOptions);
            Console.WriteLine($"Message Body: {message.Body}");
        }
    }
}
