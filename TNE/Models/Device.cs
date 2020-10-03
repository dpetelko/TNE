using System;
using System.ComponentModel;

namespace TNE.Models
{
    public class Device
    {
        public Guid Id { get; set; }
        public string Number { get; set; }
        public string Type { get; set; }
        public DateTime VerificationDate { get; set; }
        public Guid ControlPointId { get; set; }
        public virtual ControlPoint ControlPoint { get; set; }
        [DefaultValue(Status.InStorage)]
        public Status Status { get; set; }
        public Device()
        {
        }
    }
}
