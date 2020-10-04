using System;
using System.ComponentModel.DataAnnotations;
using TNE.Services.Validators;

namespace TNE.Dto
{
    public class DivisionDto
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "The {0} length must be between {2} and {1} characters.")]
        [UniqueField]
        public string Name { get; set; }
        public Guid AddressId { get; set; }
        public int PostCode { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string Region { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Building { get; set; }
        [Required]
        public bool Deleted { get; set; }

        public override bool Equals(object obj)
        {
            return obj is DivisionDto dto &&
                   Id.Equals(dto.Id) &&
                   Name == dto.Name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name);
        }
    }

}
