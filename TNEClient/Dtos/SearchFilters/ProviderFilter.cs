using System;

namespace TNEClient.Dtos.SearchFilters
{
    public class ProviderFilter : IEquatable<ProviderFilter>
    {
        public Guid? ProviderId { get; set; }
        public DateTime? ElectricityMeterVerificationDate { get; set; }
        public DateTime? CurrentTransformerVerificationDate { get; set; }
        public DateTime? VoltageTransformerVerificationDate { get; set; }

        public ProviderFilter() { }

        public override bool Equals(object obj)
        {
            return Equals(obj as ProviderFilter);
        }

        public bool Equals(ProviderFilter other)
        {
            return other != null &&
                   ProviderId.Equals(other.ProviderId) &&
                   ElectricityMeterVerificationDate == other.ElectricityMeterVerificationDate &&
                   CurrentTransformerVerificationDate == other.CurrentTransformerVerificationDate &&
                   VoltageTransformerVerificationDate == other.VoltageTransformerVerificationDate;
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(ProviderId);
            hash.Add(ElectricityMeterVerificationDate);
            hash.Add(CurrentTransformerVerificationDate);
            hash.Add(VoltageTransformerVerificationDate);
            return hash.ToHashCode();
        }

        public override string ToString()
        {
            return $"ControlPointFilter: [" +
                $"ProviderId:{ProviderId}, " +
                $"CurrentTransformerVerificationDate:{CurrentTransformerVerificationDate}, " +
                $"VoltageTransformerVerificationDate:{VoltageTransformerVerificationDate}, " +
                $"ElectricityMeterVerificationDate:{ElectricityMeterVerificationDate} ]";
        }
    }
}
