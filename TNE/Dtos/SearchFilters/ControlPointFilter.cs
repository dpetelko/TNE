using System;
using System.ComponentModel.DataAnnotations;
using TNE.Models;
using TNE.Services.Validators;

namespace TNE.Dtos.SearchFilters
{
    public class ControlPointFilter : IEquatable<ControlPointFilter>
    {
        public Guid ControlPointId { get; set; }

        public string ElectricityMeterNumber { get; set; }
        public string ElectricityMeterType { get; set; }
        public DateTime ElectricityMeterVerificationDate { get; set; }
        public string CurrentTransformerNumber { get; set; }
        public string CurrentTransformerType { get; set; }
        public DateTime CurrentTransformerVerificationDate { get; set; }
        public int CurrentTransformerTransformationRate { get; set; }
        public string VoltageTransformerNumber { get; set; }
        public string VoltageTransformerType { get; set; }
        public DateTime VoltageTransformerVerificationDate { get; set; }
        public int VoltageTransformerTransformationRate { get; set; }

        public ControlPointFilter() { }

        public override bool Equals(object obj)
        {
            return Equals(obj as ControlPointFilter);
        }

        public bool Equals(ControlPointFilter other)
        {
            return other != null &&
                   ControlPointId.Equals(other.ControlPointId) &&
                   ElectricityMeterNumber == other.ElectricityMeterNumber &&
                   ElectricityMeterType == other.ElectricityMeterType &&
                   ElectricityMeterVerificationDate == other.ElectricityMeterVerificationDate &&
                   CurrentTransformerNumber == other.CurrentTransformerNumber &&
                   CurrentTransformerType == other.CurrentTransformerType &&
                   CurrentTransformerVerificationDate == other.CurrentTransformerVerificationDate &&
                   CurrentTransformerTransformationRate == other.CurrentTransformerTransformationRate &&
                   VoltageTransformerNumber == other.VoltageTransformerNumber &&
                   VoltageTransformerType == other.VoltageTransformerType &&
                   VoltageTransformerVerificationDate == other.VoltageTransformerVerificationDate &&
                   VoltageTransformerTransformationRate == other.VoltageTransformerTransformationRate;
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(ControlPointId);
            hash.Add(ElectricityMeterNumber);
            hash.Add(ElectricityMeterType);
            hash.Add(ElectricityMeterVerificationDate);
            hash.Add(CurrentTransformerNumber);
            hash.Add(CurrentTransformerType);
            hash.Add(CurrentTransformerVerificationDate);
            hash.Add(CurrentTransformerTransformationRate);
            hash.Add(VoltageTransformerNumber);
            hash.Add(VoltageTransformerType);
            hash.Add(VoltageTransformerVerificationDate);
            hash.Add(VoltageTransformerTransformationRate);
            return hash.ToHashCode();
        }

        public override string ToString()
        {
            return $"ControlPointFilter: [" +
                $"CurrentTransformerNumber:{CurrentTransformerNumber}, " +
                $"CurrentTransformerType:{CurrentTransformerType}, " +
                $"CurrentTransformerVerificationDate:{CurrentTransformerVerificationDate}, " +
                $"CurrentTransformerTransformationRate:{CurrentTransformerTransformationRate}, " +
                $"VoltageTransformerNumber:{VoltageTransformerNumber}, " +
                $"VoltageTransformerType:{VoltageTransformerType}, " +
                $"VoltageTransformerVerificationDate:{VoltageTransformerVerificationDate}, " +
                $"VoltageTransformerTransformationRate:{VoltageTransformerTransformationRate}, " +
                $"ElectricityMeterNumber:{ElectricityMeterNumber}, " +
                $"ElectricityMeterType:{ElectricityMeterType}, " +
                $"ElectricityMeterVerificationDate:{ElectricityMeterVerificationDate} ]";
        }
    }
}
