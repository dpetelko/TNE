using System;
namespace TNE.Dtos
{
    public class BillingPointDto : IEquatable<BillingPointDto>
    {
        public Guid Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Guid ControlPointId { get; set; }
        public string ControlPointName { get; set; }
        public Guid DeliveryPointId { get; set; }
        public string DeliveryPointName { get; set; }
        public bool Deleted { get; set; }

        public BillingPointDto()
        {
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
                $"DeliveryPointName:{DeliveryPointName} " +
                $"Deleted:{Deleted} ]";
        }
    }
}
