using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TNE.Models
{
    public class ControlPoint : IEquatable<ControlPoint>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public Guid? ElectricityMeterId { get; set; }
        [ForeignKey("ElectricityMeterId")]
        public virtual ElectricityMeter ElectricityMeter { get; set; }
        public Guid? CurrentTransformerId { get; set; }
        [ForeignKey("CurrentTransformerId")]
        public virtual CurrentTransformer CurrentTransformer { get; set; }
        public Guid? VoltageTransformerId { get; set; }
        [ForeignKey("VoltageTransformerId")]
        public virtual VoltageTransformer VoltageTransformer { get; set; }
        public Guid? ProviderId { get; set; }
        public virtual Provider Provider { get; set; }
        //public List<BillingPoint> BillingPoints { get; set; }
        [DefaultValue(false)]
        public bool Deleted { get; set; }

        public ControlPoint() { }

        public override bool Equals(object obj)
        {
            return Equals(obj as ControlPoint);
        }

        public bool Equals(ControlPoint other)
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
            return $"ControlPoint" +
                $"[ Id:{Id}, " +
                $"Name:{Name}, " +
                $"ElectricityMeter:{ElectricityMeter}, " +
                $"CurrentTransformer:{CurrentTransformer}, " +
                $"VoltageTransformer:{VoltageTransformer}, " +
                $"Provider:{Provider} " +
                $"Deleted:{Deleted} ]";
        }
    }
}
