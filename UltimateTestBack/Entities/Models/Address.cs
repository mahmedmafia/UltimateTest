using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Address
    {
        [Column("AddressId")]
        public int Id { get; set; }

        [Required(ErrorMessage = "City is a required field.")]
        public string? City { get; set; }

        [Required(ErrorMessage = "Zone is a required field.")]
        public string? Zone { get; set; }

        [Required(ErrorMessage = "Street is a required field.")]
        public string? Street { get; set; }

        [Required(ErrorMessage = "Building is a required field.")]
        public int Building { get; set; }

        [Required(ErrorMessage = "Floor is a required field.")]
        public int Floor { get; set; }

        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }
    }
}