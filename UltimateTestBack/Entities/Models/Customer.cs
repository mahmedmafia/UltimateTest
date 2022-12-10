using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Customer
    {
        [Column("CustomerId")]
        public int Id { get; set; }
        [Required]
        public string? Code { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Mobile { get; set; }
        public string? Description { get; set; }
        public ICollection<Address> Addresses { get; set; }


    }
}