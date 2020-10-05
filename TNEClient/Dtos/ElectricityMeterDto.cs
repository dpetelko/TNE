using System;
using System.ComponentModel.DataAnnotations;
using TNE.Models;

namespace TNEClient.Dtos
{
    public class ElectricityMeterDto : DeviceDto, IEquatable<ElectricityMeterDto>
    {
        public ElectricityMeterDto() { }

        public ElectricityMeterDto(ElectricityMeter entity) 
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            Id = entity.Id;
            Number = entity.Number;
            Type = entity.Type;
            LastVerificationDate = entity.LastVerificationDate;
            InterTestingPeriod = entity.InterTestingPeriod;
            ControlPointId = entity.ControlPoint.Id;
            ControlPointName = entity.ControlPoint.Name;
            Status = entity.Status;
        }

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
                $"LastVerificationDate:{LastVerificationDate}, " +
                $"InterTestingPeriod:{InterTestingPeriod}, " +
                $"ControlPointId:{ControlPointId} " +
                $"ControlPointName:{ControlPointName} " +
                $"Status:{Status} ]";
        }
    }
}
