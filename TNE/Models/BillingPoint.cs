using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TNE.Models
{
    public class BillingPoint : IEquatable<BillingPoint>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Guid? ControlPointId { get; set; }
        public virtual ControlPoint ControlPoint { get; set; }
        public Guid? DeliveryPointId { get; set; }
        public virtual DeliveryPoint DeliveryPoint { get; set; }

        public BillingPoint() { }


        public override bool Equals(object obj)
        {
            return Equals(obj as BillingPoint);
        }

        public bool Equals(BillingPoint other)
        {
            return other != null &&
                   Id.Equals(other.Id) &&
                   StartTime == other.StartTime &&
                   EndTime == other.EndTime &&
                   EqualityComparer<Guid?>.Default.Equals(ControlPointId, other.ControlPointId) &&
                   EqualityComparer<Guid?>.Default.Equals(DeliveryPointId, other.DeliveryPointId);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, StartTime, EndTime, ControlPointId, DeliveryPointId);
        }

        public override string ToString()
        {
            //return JsonConvert.SerializeObject(this);
            return $"BillingPoint" +
                $"[ Id:{Id}, " +
                $"StartTime:{StartTime}, " +
                $"EndTime:{EndTime}, " +
                $"ControlPoint:{ControlPoint}, " +
                $"DeliveryPoint:{DeliveryPoint} ]";
        }

    }
}
