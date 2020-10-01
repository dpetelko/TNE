using System;
using TNE.Models;

namespace TNE.Dtos
{
    public class TransformerDto : IEquatable<TransformerDto>
    {
        public Guid Id { get; set; }
        public string Number { get; set; }
        public string Type { get; set; }
        public DateTime VerificationDate { get; set; }
        public int TransformationRate { get; set; }
        public Guid ControlPointId { get; set; }
        public string ControlPointName { get; set; }
        public Status Status { get; set; }

        public TransformerDto() { }

        public TransformerDto(Transformer entity) 
        {
            Id = entity.Id;
            Number = entity.Number;
            Type = entity.Type;
            VerificationDate = entity.VerificationDate;
            TransformationRate = entity.TransformationRate;
            ControlPointId = entity.ControlPoint.Id;
            ControlPointName = entity.ControlPoint.Name;
            Status = entity.Status;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as TransformerDto);
        }

        public bool Equals(TransformerDto other)
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
            return $"TransformerDto" +
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