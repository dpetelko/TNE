using System;
using System.ComponentModel.DataAnnotations;

namespace TNEClient.Dtos
{
    public class CurrentTransformerDto : DeviceDto
    {
        [Required]
        [Display(Name = "Коэффициент трансформации")]
        public int TransformationRate { get; set; }
        public CurrentTransformerDto() { }
        
        public override string ToString()
        {
            return $"CurrentTransformerDto" +
                $"[ Id:{Id}, " +
                $"Number:{Number}, " +
                $"Type:{Type}, " +
                $"LastVerificationDate:{LastVerificationDate}, " +
                $"InterTestingPeriodInDays:{InterTestingPeriodInDays}, " +
                $"TransformationRate:{TransformationRate}, " +
                $"ControlPointName:{ControlPointName} " +
                $"Status:{Status} ]";
        }
    }
}
