using System;
using System.ComponentModel.DataAnnotations;
using TNE.Models;
using TNE.Services.Validators;

namespace TNE.Dtos
{
    public class ControlPointDto : IEquatable<ControlPointDto>
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "The {0} length must be between {2} and {1} characters.")]
        //[UniqueField]
        public string Name { get; set; }
        [Required]
        public bool Deleted { get; set; }
        [Required]
        public Guid ProviderId { get; set; }
        public string ProviderName { get; set; }
        [Required]
        public Guid? ElectricityMeterId { get; set; }
        public string ElectricityMeterNumber { get; set; }
        public string ElectricityMeterType { get; set; }
        [Required]
        public DateTime ElectricityMeterLastVerificationDate { get; set; }
        [Required]
        public Guid? CurrentTransformerId { get; set; }
        public string CurrentTransformerNumber { get; set; }
        public string CurrentTransformerType { get; set; }
        public DateTime CurrentTransformerLastVerificationDate { get; set; }
        public int CurrentTransformerTransformationRate { get; set; }
        [Required]
        public Guid? VoltageTransformerId { get; set; }
        public string VoltageTransformerNumber { get; set; }
        public string VoltageTransformerType { get; set; }
        public DateTime VoltageTransformerLastVerificationDate { get; set; }
        public int VoltageTransformerTransformationRate { get; set; }

        public ControlPointDto() { }

        public ControlPointDto(ControlPoint entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Deleted = entity.Deleted;

            ProviderId = entity.Provider.Id;
            ProviderName = entity.Provider.Name;

            CurrentTransformerId = entity.CurrentTransformer.Id;
            CurrentTransformerNumber = entity.CurrentTransformer.Number;
            CurrentTransformerType = entity.CurrentTransformer.Type;
            CurrentTransformerLastVerificationDate = entity.CurrentTransformer.LastVerificationDate;
            CurrentTransformerTransformationRate = entity.CurrentTransformer.TransformationRate;

            VoltageTransformerId = entity.VoltageTransformer.Id;
            VoltageTransformerNumber = entity.VoltageTransformer.Number;
            VoltageTransformerType = entity.VoltageTransformer.Type;
            VoltageTransformerLastVerificationDate = entity.VoltageTransformer.LastVerificationDate;
            VoltageTransformerTransformationRate = entity.VoltageTransformer.TransformationRate;

            ElectricityMeterId = entity.ElectricityMeter.Id;
            ElectricityMeterNumber = entity.ElectricityMeter.Number;
            ElectricityMeterType = entity.ElectricityMeter.Type;
            ElectricityMeterLastVerificationDate = entity.ElectricityMeter.LastVerificationDate;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as ControlPointDto);
        }

        public bool Equals(ControlPointDto other)
        {
            return other != null &&
                   Id.Equals(other.Id) &&
                   Name == other.Name &&
                   ProviderId.Equals(other.ProviderId) &&
                   ElectricityMeterId.Equals(other.ElectricityMeterId) &&
                   CurrentTransformerId.Equals(other.CurrentTransformerId) &&
                   VoltageTransformerId.Equals(other.VoltageTransformerId);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, ProviderId, ElectricityMeterId, CurrentTransformerId, VoltageTransformerId);
        }

        public override string ToString()
        {
            return $"ControlPointDto " +
                $"[ Id:{Id}, " +
                $"Name:{Name}, " +
                $"Deleted:{Deleted}, " +
                $"ProviderId:{ProviderId}, " +
                $"ProviderName:{ProviderName}, " +
                $"CurrentTransformerId:{CurrentTransformerId} " +
                $"CurrentTransformerNumber:{CurrentTransformerNumber}, " +
                $"CurrentTransformerType:{CurrentTransformerType}, " +
                $"CurrentTransformerLastVerificationDate:{CurrentTransformerLastVerificationDate}, " +
                $"CurrentTransformerTransformationRate:{CurrentTransformerTransformationRate}, " +
                $"VoltageTransformerId:{VoltageTransformerId} " +
                $"VoltageTransformerNumber:{VoltageTransformerNumber}, " +
                $"VoltageTransformerType:{VoltageTransformerType}, " +
                $"VoltageTransformerLastVerificationDate:{VoltageTransformerLastVerificationDate}, " +
                $"VoltageTransformerTransformationRate:{VoltageTransformerTransformationRate}, " +
                $"ElectricityMeterId:{ElectricityMeterId} " +
                $"ElectricityMeterNumber:{ElectricityMeterNumber}, " +
                $"ElectricityMeterType:{ElectricityMeterType}, " +
                $"ElectricityMeterLastVerificationDate:{ElectricityMeterLastVerificationDate} ]";
        }
    }
}
