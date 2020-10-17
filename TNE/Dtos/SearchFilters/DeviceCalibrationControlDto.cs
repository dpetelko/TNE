using System;
using System.ComponentModel.DataAnnotations;
using TNE.Models;
using TNE.Services.Validators;

namespace TNE.Dtos.SearchFilters
{
    public class DeviceCalibrationControlDto : IEquatable<DeviceCalibrationControlDto>
    {
        public Guid? ProviderId { get; set; }
        public DateTime? ElectricityMeterCheckDate { get; set; }
        public DateTime? CurrentTransformerCheckDate { get; set; }
        public DateTime? VoltageTransformerCheckDate { get; set; }

        public DeviceCalibrationControlDto() { }

        public override bool Equals(object obj)
        {
            return Equals(obj as DeviceCalibrationControlDto);
        }

        public bool Equals(DeviceCalibrationControlDto other)
        {
            return other != null &&
                   ProviderId.Equals(other.ProviderId) &&
                   ElectricityMeterCheckDate == other.ElectricityMeterCheckDate &&
                   CurrentTransformerCheckDate == other.CurrentTransformerCheckDate &&
                   VoltageTransformerCheckDate == other.VoltageTransformerCheckDate;
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(ProviderId);
            hash.Add(ElectricityMeterCheckDate);
            hash.Add(CurrentTransformerCheckDate);
            hash.Add(VoltageTransformerCheckDate);
            return hash.ToHashCode();
        }

        public override string ToString()
        {
            return $"ControlPointFilter: [" +
                $"ProviderId:{ProviderId}, " +
                $"CurrentTransformerCheckDate:{CurrentTransformerCheckDate}, " +
                $"VoltageTransformerCheckDate:{VoltageTransformerCheckDate}, " +
                $"ElectricityMeterCheckDate:{ElectricityMeterCheckDate} ]";
        }
    }
}
