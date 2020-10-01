using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TNE.Models
{
    public class Transformer
    {
        public Guid Id { get; set; }
        public string Number { get; set; }
        public string Type { get; set; }
        public DateTime VerificationDate { get; set; }
        public int TransformationRate { get; set; }
        public Guid ControlPointId { get; set; }
        public ControlPoint ControlPoint { get; set; } = new ControlPoint();
        [DefaultValue(Status.InStorage)]
        public Status Status { get; set; }
        public override string ToString()
        {
            return $"Transformer" +
                $"[ Id:{Id}, " +
                $"Number:{Number}, " +
                $"Type:{Type}, " +
                $"VerificationDate:{VerificationDate}, " +
                $"TransformationRate:{TransformationRate}, " +
                $"ControlPointName:{ControlPoint.Name} " +
                $"Status:{Status} ]";
        }
    }
}
