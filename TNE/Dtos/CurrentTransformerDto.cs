using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using TNE.Models;

namespace TNE.Dtos
{
    public class CurrentTransformerDto : DeviceDto
    {
        [Required]
        public int TransformationRate { get; set; }
        public CurrentTransformerDto() { }
        public CurrentTransformerDto(CurrentTransformer entity)
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
            return $"CurrentTransformerDto" +
                $"[ Id:{Id}, " +
                $"Number:{Number}, " +
                $"Type:{Type}, " +
                $"LastVerificationDate:{LastVerificationDate}, " +
                $"InterTestingPeriodInDays:{InterTestingPeriodInDays}, " +
                $"TransformationRate:{TransformationRate}, " +
                $"ControlPointName:{ControlPointName} " +
                $"Status:{Status} ]";
        }
    }
}
