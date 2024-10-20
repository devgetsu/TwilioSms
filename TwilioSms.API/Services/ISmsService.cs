namespace TwilioSms.API.Services
{
    public interface ISmsService
    {
        void SendSms(string phoneNumber);
    }
}
