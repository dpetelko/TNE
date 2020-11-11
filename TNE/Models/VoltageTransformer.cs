using System;
using TNE.Dtos;

namespace TNE.Models
{
    public class VoltageTransformer : Device, IEquatable<VoltageTransformer>
    {
        public int TransformationRate { get; set; }

        public VoltageTransformer() { }

        public VoltageTransformer(VoltageTransformerDto dto)
        {
            Id = dto.Id;
            Number = dto.Number;
            Type = dto.Type;
            LastVerificationDate = dto.LastVerificationDate;
            InterTestingPeriodInDays = dto.InterTestingPeriodInDays;
            Status = dto.Status;
            TransformationRate = dto.TransformationRate;
            ControlPointId = dto.ControlPointId;
        }

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
                $"VerificationDate:{LastVerificationDate}, " +
                $"InterTestingPeriodInDays:{InterTestingPeriodInDays}, " +
                $"TransformationRate:{TransformationRate}, " +
                $"ControlPoint:{ControlPoint} " +
                $"Status:{Status} ]";
        }
    }
}
