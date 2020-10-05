using System;
using System.ComponentModel.DataAnnotations;
using TNE.Models;

namespace TNEClient.Dtos
{
    public class BillingPointDto : IEquatable<BillingPointDto>
    {
        public Guid Id { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public DateTime EndTime { get; set; }
        [Required]
        public Guid ControlPointId { get; set; }
        public string ControlPointName { get; set; }
        [Required]
        public Guid DeliveryPointId { get; set; }
        public string DeliveryPointName { get; set; }

        public BillingPointDto() { }

        public BillingPointDto(BillingPoint entity) 
        {
            Id = entity.Id;
            StartTime = entity.StartTime;
            EndTime = entity.EndTime;
            ControlPointId = entity.ControlPoint.Id;
            ControlPointName = entity.ControlPoint.Name;
            DeliveryPointId = entity.DeliveryPoint.Id;
            DeliveryPointName = entity.DeliveryPoint.Name;
        }

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
