using System;
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
        public ControlPoint ControlPoint { get; set; }
        public Guid? DeliveryPointId { get; set; }
        public DeliveryPoint DeliveryPoint { get; set; }
        public bool Deleted { get; set; }
        public override string ToString()
        {
            //return JsonConvert.SerializeObject(this);
            return $"BillingPoint" +
                $"[ Id:{Id}, " +
                $"StartTime:{StartTime}, " +
                $"EndTime:{EndTime}, " +
                $"ControlPointName:{ControlPoint.Name}, " +
                $"DeliveryPointName:{DeliveryPoint.Name} " +
                $"Deleted:{Deleted} ]";
        }
    }
}
