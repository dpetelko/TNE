using System;
using System.ComponentModel.DataAnnotations;

namespace TNEClient.Dtos
{
    public class VoltageTransformerDto : DeviceDto
    {
        [Display(Name = "Коэффициент трансформации")]
        [Required(ErrorMessage = "Введите значение")]
        [Range(1, int.MaxValue, ErrorMessage = "Неверное значение поля")]
        public int TransformationRate { get; set; }
        public VoltageTransformerDto() { }


        public override string ToString()
        {
            return $"VoltageTransformerDto" +
                $"[ Id:{Id}, " +
                $"Number:{Number}, " +
                $"Type:{Type}, " +
                $"LastVerificationDate:{LastVerificationDate}, " +
                $"InterTestingPeriodInDays:{InterTestingPeriodInDays}, " +
                $"TransformationRate:{TransformationRate}, " +
                $"ControlPointId:{ControlPointId} " +
                $"ControlPointName:{ControlPointName} " +
                $"Status:{Status} ]";
        }
    }
}
