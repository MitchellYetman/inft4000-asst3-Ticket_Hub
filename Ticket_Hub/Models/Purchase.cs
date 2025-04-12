using System.ComponentModel.DataAnnotations;

namespace Ticket_Hub.Models
{
    public class Purchase
    {
        [Required]
        public int ConcertId;

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        [Required]
        [Range(1, 10)]
        public int Quantity { get; set; }

        [Required]
        [CreditCard(ErrorMessage = "Invalid credit card number.")]
        public string CreditCard { get; set; }

        [Required]
        [RegularExpression(@"^(0[1-9]|1[0-2])(2[5-9])$", ErrorMessage = "Invalid expiration date.")]
        public string Expiration { get; set; }

        [Required]
        [RegularExpression(@"^\d{3}$", ErrorMessage = "Invalid security code.")]
        public string SecurityCode { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Invalid province name.")]
        [StringLength(25, MinimumLength = 2)]
        public string Province { get; set; }

        [Required]
        [RegularExpression(@"^[A-Za-z]\d[A-Za-z][ -]?\d[A-Za-z]\d$", ErrorMessage = "Invalid postal code.")]
        public string PostalCode { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Invalid country name.")]
        [StringLength(25, MinimumLength = 2)]
        public string Country { get; set; }
    }
}
