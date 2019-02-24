using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Sample.Models;

namespace Twilio.Sample.Controllers
{
    public class HomeController : Controller
    {
        private TwilioSettings TwilioSettings { get; set; }

        public HomeController(IOptions<AppSettings> settings)
        {
            TwilioSettings = settings.Value.TwilioSettings;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(SMS model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                TwilioClient.Init(TwilioSettings.AccountSid, TwilioSettings.AuthToken);

                var message = MessageResource.Create(
                    body: model.Body,
                    from: new Types.PhoneNumber(TwilioSettings.PhoneNumber),
                    to: new Types.PhoneNumber(model.PhoneNumber.Replace("-", string.Empty))
                );
                ViewBag.Message = "Message sent sucesfully!";
            }
            catch
            {
                ViewBag.Message = "Enable to sent message!";
            }

            return View();
        }
    }
}