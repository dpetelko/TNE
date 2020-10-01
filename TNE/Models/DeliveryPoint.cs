using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TNE.Models
{
    public class DeliveryPoint
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int MaxPower { get; set; }
        public Guid? ProviderId { get; set; }
        public Provider Provider { get; set; } = new Provider();
        public List<BillingPoint> BillingPoints { get; set; }
        [DefaultValue(false)]
        public bool Deleted { get; set; }

        public override string ToString()
        {
            return $"DeliveryPoint" +
                $"[ Id:{Id}, " +
                $"Name:{Name}, " +
                $"MaxPower:{MaxPower}, " +
                $"ProviderName:{Provider.Name} " +
                $"Deleted:{Deleted} ]";
        }
    }
}
