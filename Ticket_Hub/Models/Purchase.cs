using System.ComponentModel.DataAnnotations;

namespace Ticket_Hub.Models
{
    public class Purchase
    {
        public int concertId;

        [Required]
        [EmailAddress]
        public string email { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Invalid name.")]
        public string name { get; set; }

        [Required]
        [Phone]
        public string phone { get; set; }

        [Required]
        [Range(1, 50)]
        public int quantity { get; set; }

        [Required]
        [CreditCard]
        public string creditCard { get; set; }

        [Required]
        [RegularExpression(@"^(0[1-9]|1[0-2])(2[5-9])$", ErrorMessage = "Invalid expiration date.")]
        public string expiration { get; set; }

        [Required]
        [RegularExpression(@"^\d{3}$", ErrorMessage = "Invalid security code.")]
        public string securityCode { get; set; }

        [Required]
        public string address { get; set; }

        [Required]
        public string city { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Invalid province name.")]
        [StringLength(25, MinimumLength = 2)]
        public string province { get; set; }

        [Required]
        [RegularExpression(@"^[A-Za-z]\d[A-Za-z][ -]?\d[A-Za-z]\d$", ErrorMessage = "Invalid postal code.")]
        public string postalCode { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Invalid country name.")]
        [StringLength(25, MinimumLength = 2)]
        public string country { get; set; }
    }
}
