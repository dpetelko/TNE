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
        public virtual ElectricityMeter ElectricityMeter { get; set; }// = new ElectricityMeter();
        public Guid? CurrentTransformerId { get; set; }
        [ForeignKey("CurrentTransformerId"), CascadingParameter]
        [InverseProperty("ControlPoint")]
        public virtual Transformer CurrentTransformer { get; set; }// = new Transformer();
        public Guid? VoltageTransformerId { get; set; }
        [ForeignKey("VoltageTransformerId")]
        public virtual Transformer VoltageTransformer { get; set; }// = new Transformer();
        public Guid? ProviderId { get; set; }
        public virtual Provider Provider { get; set; }// = new Provider();
        public List<BillingPoint> BillingPoints { get; set; }
        [DefaultValue(false)]
        public bool Deleted { get; set; }

        public ControlPoint()
        {
            //ElectricityMeter = new ElectricityMeter();
            //CurrentTransformer = new Transformer();
            //VoltageTransformer = new Transformer();
            //Provider = new Provider();
        }

        public override string ToString()
        {
            return $"ControlPoint" +
                $"[ Id:{Id}, " +
                $"Name:{Name}, " +
                $"ElectricityMeter:{ElectricityMeter}, " +
                $"CurrentTransformer:{CurrentTransformer}, " +
                $"VoltageTransformer:{VoltageTransformer}, " +
                $"Provider:{Provider.Name} " +
                $"Deleted:{Deleted} ]";
        }
    }
}
