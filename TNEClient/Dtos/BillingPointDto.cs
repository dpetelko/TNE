using System;
using System.ComponentModel.DataAnnotations;

namespace TNEClient.Dtos
{
    public class BillingPointDto : IEquatable<BillingPointDto>
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Введите значение")]
        [Display(Name = "Дата старта учета")]
        //[DataType(DataType.Date, ErrorMessage = "Неверное значение поля")]
        public DateTime? StartTime { get; set; }
        //[DataType(DataType.Date, ErrorMessage = "Неверное значение поля")]
        [Display(Name = "Дата окончания учета")]
        [Required(ErrorMessage = "Введите значение")]
        public DateTime? EndTime { get; set; }
        [NotEmptyGuid("Выберите значение")]
        public Guid ControlPointId { get; set; }
        [Display(Name = "Имя точки измерения")]
        public string ControlPointName { get; set; }
        [NotEmptyGuid("Выберите значение")]
        public Guid DeliveryPointId { get; set; }
        [Display(Name = "Имя точки поставки")]
        public string DeliveryPointName { get; set; }

        public BillingPointDto() { }

        public override bool Equals(object obj)
        {
            return Equals(obj as BillingPointDto);
        }

        public bool Equals(BillingPointDto other)
        {
            return other != null &&
                   Id.Equals(other.Id) &&
                   StartTime == other.StartTime &&
                   EndTime == other.EndTime &&
                   ControlPointId.Equals(other.ControlPointId) &&
                   DeliveryPointId.Equals(other.DeliveryPointId);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, StartTime, EndTime, ControlPointId, DeliveryPointId);
        }

        public override string ToString()
        {
            return $"BillingPointDto" +
                $"[ Id:{Id}, " +
                $"StartTime:{StartTime}, " +
                $"EndTime:{EndTime}, " +
                $"ControlPointId:{ControlPointId}, " +
                $"ControlPointName:{ControlPointName}, " +
                $"DeliveryPointId:{DeliveryPointId} " +
                $"DeliveryPointName:{DeliveryPointName} ]";
        }
    }
}
