using System.ComponentModel.DataAnnotations;

namespace KihoonShopes.Entities
{
    public class Customer
    {
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Please enter customer name!!")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Please enter customer address!!")]
        public string? Address1 { get; set; }

        public string? Address2 { get; set; }
        [Required(ErrorMessage = "Please enter customer city!!")]
        public string? City { get; set; } = null!;

        [Required(ErrorMessage = "Please enter your Province or State!!")]
        [StringLength(2, ErrorMessage = "it shuld be two characters only")]
        public string? ProvinceOrState { get; set; } = null!;

        [Required(ErrorMessage = "Please enter customer postalcode")]
        [RegularExpression("(^\\d{5}(-\\d{4})?$)|(^[ABCEGHJKLMNPRSTVXY]{1}\\d{1}[A-Z]{1} *\\d{1}[A-Z]{1}\\d{1}$)", ErrorMessage = "Please Enter as a right format like N2D-2R3")]
        public string? ZipOrPostalCode { get; set; } = null!;

        [Required(ErrorMessage = "Please enter customer phone number")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Please Enter as a right format like 647-000-0000")]
        public string? Phone { get; set; }
        [Required(ErrorMessage = "Please enter customer contact last name")]
        public string? ContactLastName { get; set; }
        [Required(ErrorMessage = "Please enter customer contact first name.")]
        public string? ContactFirstName { get; set; }

        [EmailAddress(ErrorMessage = "Please Enter as a right format")]
        public string? ContactEmail { get; set; }

        public bool IsDeleted { get; set; } = false;

        public List<Invoice>? Invoices { get; set; }
    }
}
