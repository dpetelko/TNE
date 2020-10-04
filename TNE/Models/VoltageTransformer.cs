using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TNE.Models
{
    public class VoltageTransformer : Device, IEquatable<VoltageTransformer>
    {
        public int TransformationRate { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as VoltageTransformer);
        }

        public bool Equals(VoltageTransformer other)
        {
            return other != null &&
                   Id.Equals(other.Id) &&
                   Number == other.Number &&
                   Type == other.Type &&
                   TransformationRate == other.TransformationRate;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Number, Type, TransformationRate);
        }

        public override string ToString()
        {
            return $"VoltageTransformer" +
                $"[ Id:{Id}, " +
                $"Number:{Number}, " +
                $"Type:{Type}, " +
                $"VerificationDate:{VerificationDate}, " +
                $"TransformationRate:{TransformationRate}, " +
                $"ControlPoint:{ControlPoint} " +
                $"Status:{Status} ]";
        }
    }
}
