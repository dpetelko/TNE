using System;

namespace TNE.Models
{
    public class ElectricityMeter : Device, IEquatable<ElectricityMeter>
    {
        public ElectricityMeter() { }

        public override bool Equals(object obj)
        {
            return Equals(obj as ElectricityMeter);
        }

        public bool Equals(ElectricityMeter other)
        {
            return other != null &&
                   Id.Equals(other.Id) &&
                   Number == other.Number &&
                   Type == other.Type;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Number, Type);
        }

        public override string ToString()
        {
            return $"ElectricityMeter" +
                $"[ Id:{Id}, " +
                $"Number:{Number}, " +
                $"Type:{Type}, " +
                $"VerificationDate:{LastVerificationDate}, " +
                $"InterTestingPeriodInDays:{InterTestingPeriodInDays}, " +
                $"ControlPoint:{ControlPoint} " +
                $"Status:{Status} ]";
        }
    }
}