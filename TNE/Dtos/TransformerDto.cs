﻿using System;
using System.ComponentModel.DataAnnotations;
using TNE.Models;

namespace TNE.Dtos
{
    public class TransformerDto : IEquatable<TransformerDto>
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Please, enter Number")]
        public string Number { get; set; }
        [Required(ErrorMessage = "Please, enter name")]
        public string Type { get; set; }
        [Required(ErrorMessage = "Please, enter name")]
        public DateTime VerificationDate { get; set; }
        [Required(ErrorMessage = "Please, enter name")]
        public int TransformationRate { get; set; }
        public Guid ControlPointId { get; set; }
        public string ControlPointName { get; set; }
        [EnumDataType(typeof(Status), ErrorMessage = "Invalid Status value")]
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