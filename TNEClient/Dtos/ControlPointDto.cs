using System;
using System.ComponentModel.DataAnnotations;

namespace TNEClient.Dtos
{
    public class ControlPointDto : IEquatable<ControlPointDto>
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Введите значение")]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "The {0} length must be between {2} and {1} characters.")]
        [Display(Name = "Наименование точки контроля")]
        public string Name { get; set; }
        
        public bool Deleted { get; set; }
        public Guid ProviderId { get; set; }
        [Display(Name = "Объект потребления")]
        public string ProviderName { get; set; }
        [NotEmptyGuid("Выберите значение")]
        public Guid ElectricityMeterId { get; set; }
        public string ElectricityMeterNumber { get; set; }
        public string ElectricityMeterType { get; set; }
        public DateTime ElectricityMeterLastVerificationDate { get; set; }
        [NotEmptyGuid("Выберите значение")]
        public Guid CurrentTransformerId { get; set; }
        public string CurrentTransformerNumber { get; set; }
        public string CurrentTransformerType { get; set; }
        public DateTime CurrentTransformerLastVerificationDate { get; set; }
        public int CurrentTransformerTransformationRate { get; set; }
        [NotEmptyGuid("Выберите значение")]
        public Guid VoltageTransformerId { get; set; }
        public string VoltageTransformerNumber { get; set; }
        public string VoltageTransformerType { get; set; }
        public DateTime VoltageTransformerLastVerificationDate { get; set; }
        public int VoltageTransformerTransformationRate { get; set; }

        public ControlPointDto() { }

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
