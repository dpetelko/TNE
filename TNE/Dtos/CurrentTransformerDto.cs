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
        public int TransformationRate { get; set; }
        public CurrentTransformerDto() { }
        public CurrentTransformerDto(CurrentTransformer entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            Id = entity.Id;
            Number = entity.Number;
            Type = entity.Type;
            VerificationDate = entity.VerificationDate;
            TransformationRate = entity.TransformationRate;
            ControlPointName = entity.ControlPoint.Name;
            Status = entity.Status;
        }

        public override string ToString()
        {
            return $"CurrentTransformerDto" +
                $"[ Id:{Id}, " +
                $"Number:{Number}, " +
                $"Type:{Type}, " +
                $"VerificationDate:{VerificationDate}, " +
                $"TransformationRate:{TransformationRate}, " +
                $"ControlPointName:{ControlPointName} " +
                $"Status:{Status} ]";
        }
    }
}
