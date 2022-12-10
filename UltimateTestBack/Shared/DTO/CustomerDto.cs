using System.ComponentModel.DataAnnotations;

namespace Shared.DTO
{
    public record CustomerDto
    {
        public int Id { get; set; }
        public string? Code { get; set; }

        public string? Name { get; set; }

        public string? Mobile { get; set; }

        public string? Description { get; set; }
        public ICollection<AddressDto>? Addresses { get; set; }
    }
    public record CustomerModificationDto
    {
        [Required(ErrorMessage = "Code is a required field.")]
        public string? Code { get; set; }

        [Required(ErrorMessage = "Name is a required field.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Mobile is a required field.")]
        public string? Mobile { get; set; }

        public string? Description { get; set; }
        public ICollection<AddressDto> Addresses { get; set; }
    }
}
