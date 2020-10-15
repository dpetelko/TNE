using System;

namespace TNEClient.Dtos.SearchFilters
{
    public class BillingPointFilter : IEquatable<BillingPointFilter>
    {
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public Guid? ControlPointId { get; set; }
        public Guid? DeliveryPointId { get; set; }

        public BillingPointFilter() { }

        public bool IsEmpty()
        {
            return (this.StartTime is null) &&
                (this.EndTime is null) &&
                (this.ControlPointId is null) &&
                (this.DeliveryPointId is null);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as BillingPointFilter);
        }

        public bool Equals(BillingPointFilter other)
        {
            return other != null &&
                   StartTime == other.StartTime &&
                   EndTime == other.EndTime &&
                   ControlPointId.Equals(other.ControlPointId) &&
                   DeliveryPointId.Equals(other.DeliveryPointId);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(StartTime, EndTime, ControlPointId, DeliveryPointId);
        }

        public override string ToString()
        {
            return $"BillingPointFilter" +
                $"[ StartTime:{StartTime}, " +
                $"EndTime:{EndTime}, " +
                $"ControlPointId:{ControlPointId}, " +
                $"DeliveryPointId:{DeliveryPointId} ]";
        }
    }
}
