namespace Twilio.Sample.Models
{
    public class AppSettings
    {
        public TwilioSettings TwilioSettings { get; set; }
    }

    public class TwilioSettings
    {
        public string AccountSid { get; set; }
        public string AuthToken { get; set; }
        public string PhoneNumber { get; set; }
    }
}
