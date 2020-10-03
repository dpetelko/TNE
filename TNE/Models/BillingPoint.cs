using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TNE.Models
{
    public class BillingPoint
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
