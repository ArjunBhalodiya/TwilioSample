using System.ComponentModel.DataAnnotations;

namespace Twilio.Sample.Models
{
    public class SMS
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Enter phone number.")]
        [Phone(ErrorMessage = "Enter correct phone number.")]
        public string PhoneNumber { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Enter message.")]
        public string Body { get; set; }
    }
}
