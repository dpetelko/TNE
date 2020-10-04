using System;
using System.ComponentModel.DataAnnotations;
using TNE.Models;
using TNE.Services.Validators;

namespace TNE.Dtos.SearchFilters
{
    public class ProviderFilter : IEquatable<ProviderFilter>
    {
        public Guid? ProviderId { get; set; }
        public string ElectricityMeterType { get; set; }
        public DateTime? ElectricityMeterVerificationDate { get; set; }
        public string CurrentTransformerType { get; set; }
        public DateTime? CurrentTransformerVerificationDate { get; set; }
        public int? CurrentTransformerTransformationRate { get; set; }
        public string VoltageTransformerType { get; set; }
        public DateTime? VoltageTransformerVerificationDate { get; set; }
        public int? VoltageTransformerTransformationRate { get; set; }

        public ProviderFilter() { }

        public override bool Equals(object obj)
        {
            return Equals(obj as ProviderFilter);
        }

        public bool Equals(ProviderFilter other)
        {
            return other != null &&
                   ProviderId.Equals(other.ProviderId) &&
                   ElectricityMeterType == other.ElectricityMeterType &&
                   ElectricityMeterVerificationDate == other.ElectricityMeterVerificationDate &&
                   CurrentTransformerType == other.CurrentTransformerType &&
                   CurrentTransformerVerificationDate == other.CurrentTransformerVerificationDate &&
                   CurrentTransformerTransformationRate == other.CurrentTransformerTransformationRate &&
                   VoltageTransformerType == other.VoltageTransformerType &&
                   VoltageTransformerVerificationDate == other.VoltageTransformerVerificationDate &&
                   VoltageTransformerTransformationRate == other.VoltageTransformerTransformationRate;
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(ProviderId);
            hash.Add(ElectricityMeterType);
            hash.Add(ElectricityMeterVerificationDate);
            hash.Add(CurrentTransformerType);
            hash.Add(CurrentTransformerVerificationDate);
            hash.Add(CurrentTransformerTransformationRate);
            hash.Add(VoltageTransformerType);
            hash.Add(VoltageTransformerVerificationDate);
            hash.Add(VoltageTransformerTransformationRate);
            return hash.ToHashCode();
        }

        public override string ToString()
        {
            return $"ControlPointFilter: [" +
                $"ProviderId:{ProviderId}, " +
                $"CurrentTransformerType:{CurrentTransformerType}, " +
                $"CurrentTransformerVerificationDate:{CurrentTransformerVerificationDate}, " +
                $"CurrentTransformerTransformationRate:{CurrentTransformerTransformationRate}, " +
                $"VoltageTransformerType:{VoltageTransformerType}, " +
                $"VoltageTransformerVerificationDate:{VoltageTransformerVerificationDate}, " +
                $"VoltageTransformerTransformationRate:{VoltageTransformerTransformationRate}, " +
                $"ElectricityMeterType:{ElectricityMeterType}, " +
                $"ElectricityMeterVerificationDate:{ElectricityMeterVerificationDate} ]";
        }
    }
}
