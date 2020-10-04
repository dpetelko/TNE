using System;
using System.ComponentModel.DataAnnotations;
using TNE.Models;
using TNE.Services.Validators;

namespace TNE.Dtos
{
    public class ControlPointDto
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "The {0} length must be between {2} and {1} characters.")]
        [UniqueField]
        public string Name { get; set; }
        [Required]
        public bool Deleted { get; set; }
        [Required]
        public Guid ProviderId { get; set; }
        public string ProviderName { get; set; }
        [Required]
        public Guid ElectricityMeterId { get; set; }
        public string ElectricityMeterNumber { get; set; }
        public string ElectricityMeterType { get; set; }
        [Required]
        public DateTime ElectricityMeterVerificationDate { get; set; }
        [Required]
        public Guid CurrentTransformerId { get; set; }
        public string CurrentTransformerNumber { get; set; }
        public string CurrentTransformerType { get; set; }
        public DateTime CurrentTransformerVerificationDate { get; set; }
        public int CurrentTransformerTransformationRate { get; set; }
        [Required]
        public Guid VoltageTransformerId { get; set; }
        public string VoltageTransformerNumber { get; set; }
        public string VoltageTransformerType { get; set; }
        public DateTime VoltageTransformerVerificationDate { get; set; }
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
            CurrentTransformerVerificationDate = entity.CurrentTransformer.VerificationDate;
            CurrentTransformerTransformationRate = entity.CurrentTransformer.TransformationRate;

            VoltageTransformerId = entity.VoltageTransformer.Id;
            VoltageTransformerNumber = entity.VoltageTransformer.Number;
            VoltageTransformerType = entity.VoltageTransformer.Type;
            VoltageTransformerVerificationDate = entity.VoltageTransformer.VerificationDate;
            VoltageTransformerTransformationRate = entity.VoltageTransformer.TransformationRate;

            ElectricityMeterId = entity.ElectricityMeter.Id;
            ElectricityMeterNumber = entity.ElectricityMeter.Number;
            ElectricityMeterType = entity.ElectricityMeter.Type;
            ElectricityMeterVerificationDate = entity.ElectricityMeter.VerificationDate;
        }
    }
}
