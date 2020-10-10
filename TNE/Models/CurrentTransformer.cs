using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TNE.Models
{
    public class CurrentTransformer : Device, IEquatable<CurrentTransformer>
    {
        public int TransformationRate { get; set; }

        public CurrentTransformer() { }

        public override bool Equals(object obj)
        {
            return Equals(obj as CurrentTransformer);
        }

        public bool Equals(CurrentTransformer other)
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
            return $"Transformer" +
                $"[ Id:{Id}, " +
                $"Number:{Number}, " +
                $"Type:{Type}, " +
                $"VerificationDate:{LastVerificationDate}, " +
                $"InterTestingPeriodInDays:{InterTestingPeriodInDays}, " +
                $"TransformationRate:{TransformationRate}, " +
                $"ControlPoint:{ControlPoint} " +
                $"Status:{Status} ]";
        }
    }
}
