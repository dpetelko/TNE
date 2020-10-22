using System;
using System.ComponentModel.DataAnnotations;

namespace TNEClient.Dtos
{
    public class CurrentTransformerDto : DeviceDto
    {
        [Display(Name = "Коэффициент трансформации")]
        [Required(ErrorMessage = "Введите значение")]
        [Range(1, int.MaxValue, ErrorMessage = "Неверное значение поля")]
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
