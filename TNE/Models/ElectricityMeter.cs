using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TNE.Models
{
    public class ElectricityMeter
    {
        public Guid Id { get; set; }
        public string Number { get; set; }
        public string Type { get; set; }
        public DateTime VerificationDate { get; set; }
        public Guid ControlPointId { get; set; }
        public ControlPoint ControlPoint { get; set; }
        public bool Deleted { get; set; }
        public override string ToString()
        {
            return $"ElectricityMeter" +
                $"[ Id:{Id}, " +
                $"Number:{Number}, " +
                $"Type:{Type}, " +
                $"VerificationDate:{VerificationDate}, " +
                $"ControlPointName:{ControlPoint.Name} " +
                $"Deleted:{Deleted} ]";
        }
    }
}