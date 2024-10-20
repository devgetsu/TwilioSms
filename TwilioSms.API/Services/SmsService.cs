using Twilio;
using Twilio.Rest.Verify.V2.Service;

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
            var verification = VerificationResource.Create(
                to: phoneNumber,
                channel: "sms",
                pathServiceSid: _serviceSid
            );

            Console.WriteLine($"Verification SID: {verification.Sid}");
        }
    }
}
