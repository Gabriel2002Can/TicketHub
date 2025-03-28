using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace TicketHub
{

    public class TicketPurchase
    {
        [Required]
        public int ConcertId { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Your name must be between 1 and 100 characters long.")]
        public string Name { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        [Required]
        [Range(1, 10, ErrorMessage = "You can only buy a quantity of tickets between 1 and 10.")]
        public int Quantity { get; set; }

        [Required]
        [CreditCard]
        public string CreditCard { get; set; }

        [Required]
        [RegularExpression(@"^(0[1-9]|1[0-2])/(0[1-9]|[12][0-9]|3[01])/\d{4}$", ErrorMessage ="Your expire date needs be in a valid MM/DD/YYYY format.")]
        public string Expiration { get; set; }

        [Required]
        [StringLength(4,MinimumLength =3, ErrorMessage ="Your security code must be between 3 and 4 digits long.")]
        public string SecurityCode { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 1, ErrorMessage ="Your address needs to be between 1 and 200 characters long.")]
        public string Address { get; set; }

        [Required]
        [StringLength(90, MinimumLength = 1, ErrorMessage = "Your city needs to be between 1 and 90 characters long.")]
        public string City { get; set; }

        [Required]
        [StringLength(90, MinimumLength = 1, ErrorMessage = "Your province needs to be between 1 and 90 characters long.")]
        public string Province { get; set; }

        [Required]
        [StringLength(90, MinimumLength = 1, ErrorMessage = "Your postal code needs to be between 1 and 90 characters long.")]
        public string PostalCode { get; set; }

        [Required]
        [StringLength(65, MinimumLength = 2, ErrorMessage = "Your country needs to be between 2 and 65 characters long.")]
        public string Country { get; set; }
    }
}
