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
        public ControlPoint ControlPoint { get; set; } = new ControlPoint();
        public Guid? DeliveryPointId { get; set; }
        public DeliveryPoint DeliveryPoint { get; set; } = new DeliveryPoint();
        [DefaultValue(false)]
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
