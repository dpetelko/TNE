using System;
using System.ComponentModel.DataAnnotations;
using TNE.Models;
using TNE.Services.Validators;

namespace TNE.Dtos.SearchFilters
{
    public class DeviceCalibrationControlDto
    {
        public Guid? ProviderId { get; set; }
        public DateTime? CheckDate { get; set; }


        public DeviceCalibrationControlDto() { }

        public bool IsEmpty()
        {
            return (IsEmptyOrNull(this.ProviderId)) &&
                (this.CheckDate is null);
        }

        public override string ToString()
        {
            return $"ControlPointFilter: [" +
                $"ProviderId:{ProviderId}, " +
                $"CheckDate:{CheckDate} ]";
        }

        private static bool IsEmptyOrNull(Guid? id) => id == null && id == Guid.Empty;
    }
}
