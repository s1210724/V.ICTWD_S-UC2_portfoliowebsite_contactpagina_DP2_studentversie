using Microsoft.AspNetCore.Mvc;
using Portfoliowebsite.Models;
using Portfoliowebsite.Services;

namespace Portfoliowebsite.Controllers
{
    public class ContactController : Controller
    {

        private readonly IEmailSender _email;
        public ContactController(IEmailSender email) => _email = email;

        public IActionResult Index() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ContactFormPost(ContactFormModel model, CancellationToken ct)
        {
            if (!ModelState.IsValid)
                return View("Index", model);

            // get all values and remove whitespace at the start and end of the string
            var name = model.Name.Trim();
            var email = model.Mail.Trim();
            var subject = model.Subject.Trim();
            var message = model.Message.Trim();

            // add tempdata for thankyou form
            TempData["ThanksName"] = name;
            TempData["ThanksEmail"] = email;
            TempData["ThanksMessage"] = message;

            // Send email to the contact inbox using try catch to handle execptions
            try
            {
                await _email.SendAsync(name, email, subject, message);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Er is een fout opgetreden bij het verzenden van de e-mail.");
                return View("Index", model);
            }

            return RedirectToAction(nameof(Thanks));
        }

        public IActionResult Thanks()
        {
            return View();
        }
    }
}
