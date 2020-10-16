using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TNE.Services.Validators;

namespace TNE.Models
{
    public class Division
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        [UniqueField]
        public string Name { get; set; }
        public Guid AddressId { get; set; }
        public Address Address { get; set; } = new Address();
        [DefaultValue(false)]
        public bool Deleted { get; set; }

        public Division()
        {
        }
    }
}
