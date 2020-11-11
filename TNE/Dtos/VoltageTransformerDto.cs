using System;
using TNE.Models;

namespace TNE.Dtos
{
    public class VoltageTransformerDto : DeviceDto
    {
        public int TransformationRate { get; set; }
        public VoltageTransformerDto() { }
        public VoltageTransformerDto(VoltageTransformer entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            Id = entity.Id;
            Number = entity.Number;
            Type = entity.Type;
            LastVerificationDate = entity.LastVerificationDate;
            InterTestingPeriodInDays = entity.InterTestingPeriodInDays;
            TransformationRate = entity.TransformationRate;
            ControlPointId = entity.ControlPointId;
            if (!(entity.ControlPoint is null))
            {
                ControlPointName = entity.ControlPoint.Name;
            }

            Status = entity.Status;
        }

        public override string ToString()
        {
            return $"VoltageTransformerDto" +
                $"[ Id:{Id}, " +
                $"Number:{Number}, " +
                $"Type:{Type}, " +
                $"LastVerificationDate:{LastVerificationDate}, " +
                $"InterTestingPeriodInDays:{InterTestingPeriodInDays}, " +
                $"TransformationRate:{TransformationRate}, " +
                $"ControlPointId:{ControlPointId} " +
                $"ControlPointName:{ControlPointName} " +
                $"Status:{Status} ]";
        }
    }
}
