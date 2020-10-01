using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using TNE.Models;

namespace TNE.Dtos
{
    public class VoltageTransformerDto : IEquatable<VoltageTransformerDto>
    {
        public Guid Id { get; set; }
        [Required]
        public string Number { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public DateTime VerificationDate { get; set; }
        [Required]
        public int TransformationRate { get; set; }
        public Guid ControlPointId { get; set; }
        public string ControlPointName { get; set; }
        [EnumDataType(typeof(Status), ErrorMessage = "Invalid Status value")]
        public Status Status { get; set; }

        public VoltageTransformerDto() { }

        public VoltageTransformerDto(VoltageTransformer entity)
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

        public override bool Equals(object obj)
        {
            return Equals(obj as VoltageTransformerDto);
        }

        public bool Equals(VoltageTransformerDto other)
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
            return $"VoltageTransformerDto" +
                $"[ Id:{Id}, " +
                $"Number:{Number}, " +
                $"Type:{Type}, " +
                $"VerificationDate:{VerificationDate}, " +
                $"TransformationRate:{TransformationRate}, " +
                $"ControlPointId:{ControlPointId} " +
                $"ControlPointName:{ControlPointName} " +
                $"Status:{Status} ]";
        }
    }
}
