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

            //var subject = "Terugbelverzoek via website";
            //var body =
            //    $"Naam : {model.Name}\n" +
            //    $"Telefoon: {model.Phone}\n" +
            //    $"Verzonden: {DateTimeOffset.Now:dd-MM-yyyy HH:mm:ss zzz}";

            //try
            //{
            //    await _emailSender.SendAsync(Recipient, subject, body, ct);
            //}
            //catch (Exception ex)
            //{
            //    _logger.LogError(ex, "Fout bij versturen terugbelverzoek");
            //    ModelState.AddModelError(string.Empty, "Er ging iets mis bij het versturen. Probeer het later opnieuw.");
            //    return View("Index", model);
            //}

            //TempData["SuccessMessage"] = "Bedankt! Uw terugbelverzoek is ontvangen door Optistyle.";
            return RedirectToAction(nameof(Thanks));
        }

        public IActionResult Thanks()
        {
            return View();
        }
    }
}
