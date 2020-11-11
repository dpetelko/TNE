using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TNE.Models
{
    public class DeliveryPoint : IEquatable<DeliveryPoint>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int MaxPower { get; set; }
        public Guid? ProviderId { get; set; }
        public virtual Provider Provider { get; set; }
        //public List<BillingPoint> BillingPoints { get; set; }
        [DefaultValue(false)]
        public bool Deleted { get; set; }

        public DeliveryPoint() { }

        public override bool Equals(object obj)
        {
            return Equals(obj as DeliveryPoint);
        }

        public bool Equals(DeliveryPoint other)
        {
            return other != null &&
                   Id.Equals(other.Id) &&
                   Name == other.Name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name);
        }
        public override string ToString()
        {
            return $"DeliveryPoint" +
                $"[ Id:{Id}, " +
                $"Name:{Name}, " +
                $"MaxPower:{MaxPower}, " +
                $"Provider:{Provider} " +
                $"Deleted:{Deleted} ]";
        }
    }
}
