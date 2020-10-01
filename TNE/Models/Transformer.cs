using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TNE.Models
{
    public class Transformer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Number { get; set; }
        public string Type { get; set; }
        public DateTime VerificationDate { get; set; }
        public int TransformationRate { get; set; }
        public virtual ControlPoint ControlPoint { get; set; }
        [DefaultValue(Status.InStorage)]
        public Status Status { get; set; }
        public Transformer() { }
    }
}
