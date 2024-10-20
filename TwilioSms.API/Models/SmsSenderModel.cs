using System.ComponentModel.DataAnnotations;

namespace TwilioSms.API.Models
{
    public class SmsSenderModel
    {
        public required string PhoneNumber {  get; set; }
    }
}
