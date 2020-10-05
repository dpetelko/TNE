using System;
using System.ComponentModel.DataAnnotations;
using TNE.Models;
using TNE.Services.Validators;

namespace TNE.Dtos.SearchFilters
{
    public class InterTestingFilter : IEquatable<InterTestingFilter>
    {
        public Guid? ProviderId { get; set; }
        public DateTime? ElectricityMeterVerificationDate { get; set; }
        public DateTime? CurrentTransformerVerificationDate { get; set; }
        public DateTime? VoltageTransformerVerificationDate { get; set; }

        public InterTestingFilter() { }

        public override bool Equals(object obj)
        {
            return Equals(obj as InterTestingFilter);
        }

        public bool Equals(InterTestingFilter other)
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
