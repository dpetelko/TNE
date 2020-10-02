using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TNE.Models
{
    public class Division
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public Guid? AddressId { get; set; }
        public Address Address { get; set; } = new Address();
        [DefaultValue(false)]
        public bool Deleted { get; set; }

        public Division()
        {
            //Address = new Address();
        }
    }
}
