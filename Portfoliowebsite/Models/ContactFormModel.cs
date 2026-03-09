using System.ComponentModel.DataAnnotations;

namespace Portfoliowebsite.Models
{
    public class ContactFormModel
    {
        [Display(Name = "Naam")]
        [Required(ErrorMessage = "Vul uw naam in.")]
        [StringLength(50, ErrorMessage = "Maximaal 50 tekens.")]
        // Unicode letters + spaties (accenten inbegrepen via \p{L})
        [RegularExpression(@"^[A-Za-zÀ-ÖØ-öø-ÿ\s]+$", ErrorMessage = "Alleen letters en spaties zijn toegestaan.")]
        public string? Name { get; set; }

        [Display(Name = "Mail")]
        [Required(ErrorMessage = "Vul uw E-mail adress in")]
        [StringLength(254, ErrorMessage = "Maximaal 254 tekens.")]
        // Standaard Unicode karakters regex opgehaald van https://stackoverflow.com/questions/21608294/regex-for-validating-emails
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Graag het mail format invoeren als: voorbeeld@mail.nl")]
        public string? Mail { get; set; }

        [Display(Name = "Subject")]
        [Required(ErrorMessage = "Vul een onderwerp in")]
        // Maximum lengte blijkt 998 karakters te zijn heb gekozen voor 250 omdat het onderwerp anders bijzonder moeilijk te lezen wordt (dit is pas 156 karakters btw)
        [StringLength(250, ErrorMessage = "Maximaal 250 tekens.")]
        public string? Subject { get; set; }

        [Display(Name = "Message")]
        [Required(ErrorMessage = "Voer uw bericht in")]
        // Geen limiet gekozen voor tekst invoer of limitaties meeste servers ondersteunen minstens 10mb aan tekst
        public string? Message { get; set; }
    }
}
