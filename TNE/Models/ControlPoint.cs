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
    public class ControlPoint
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
        [ForeignKey("CurrentTransformerId"), CascadingParameter]
        [InverseProperty("ControlPoint")]
        public virtual Transformer CurrentTransformer { get; set; }
        public Guid? VoltageTransformerId { get; set; }
        [ForeignKey("VoltageTransformerId")]
        public virtual Transformer VoltageTransformer { get; set; }
        public Guid? ProviderId { get; set; }
        public Provider Provider { get; set; }
        public List<BillingPoint> BillingPoints { get; set; }
        [DefaultValue(false)]
        public bool Deleted { get; set; }
        public override string ToString()
        {
            return $"ControlPoint" +
                $"[ Id:{Id}, " +
                $"Name:{Name}, " +
                $"ElectricityMeterNumber:{ElectricityMeter.Number}, " +
                $"CurrentTransformerNumber:{CurrentTransformer.Number}, " +
                $"VoltageTransformerNumber:{VoltageTransformer.Number}, " +
                $"ProviderName:{Provider.Name} " +
                $"Deleted:{Deleted} ]";
        }
    }
}
