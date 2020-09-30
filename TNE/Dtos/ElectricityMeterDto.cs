using System;
using TNE.Models;

namespace TNE.Dtos
{
    public class ElectricityMeterDto : IEquatable<ElectricityMeterDto>
    {
        public Guid Id { get; set; }
        public string Number { get; set; }
        public string Type { get; set; }
        public DateTime VerificationDate { get; set; }
        public Guid ControlPointId { get; set; }
        public string ControlPointName { get; set; }
        public Status Status { get; set; }

        public ElectricityMeterDto() { }

        public override bool Equals(object obj)
        {
            return Equals(obj as ElectricityMeterDto);
        }

        public bool Equals(ElectricityMeterDto other)
        {
            return other != null &&
                   Id.Equals(other.Id) &&
                   Number == other.Number;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Number);
        }

        public override string ToString()
        {
            return $"ElectricityMeterDto" +
                $"[ Id:{Id}, " +
                $"Number:{Number}, " +
                $"Type:{Type}, " +
                $"VerificationDate:{VerificationDate}, " +
                $"ControlPointId:{ControlPointId} " +
                $"ControlPointName:{ControlPointName} " +
                $"Status:{Status} ]";
        }
    }

    
}