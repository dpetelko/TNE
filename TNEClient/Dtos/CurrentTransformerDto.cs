using System;
using System.ComponentModel.DataAnnotations;

namespace TNEClient.Dtos
{
    public class CurrentTransformerDto : DeviceDto
    {
        [Required]
        public int TransformationRate { get; set; }
        public CurrentTransformerDto() { }
        
        public override string ToString()
        {
            return $"CurrentTransformerDto" +
                $"[ Id:{Id}, " +
                $"Number:{Number}, " +
                $"Type:{Type}, " +
                $"LastVerificationDate:{LastVerificationDate}, " +
                $"InterTestingPeriod:{InterTestingPeriod}, " +
                $"TransformationRate:{TransformationRate}, " +
                $"ControlPointName:{ControlPointName} " +
                $"Status:{Status} ]";
        }
    }
}
