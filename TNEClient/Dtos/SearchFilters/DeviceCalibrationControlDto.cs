using System;
using System.ComponentModel.DataAnnotations;

namespace TNEClient.Dtos.SearchFilters
{
    public class DeviceCalibrationControlDto
    {
        [Required]
        public Guid? ProviderId { get; set; }
        [Required]
        public DateTime? CheckDate { get; set; }
        

        public DeviceCalibrationControlDto() { }

        public bool IsEmpty()
        {
            return (IsEmptyOrNull(this.ProviderId)) &&
                (this.CheckDate is null) ;
        }

        public override string ToString()
        {
            return $"ControlPointFilter: [" +
                $"ProviderId:{ProviderId}, " +
                $"CheckDate:{CheckDate} ]";
        }

        private static bool IsEmptyOrNull(Guid? id) => id == null || id == Guid.Empty;
    }
}
