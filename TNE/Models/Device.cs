﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TNE.Models
{
    public class Device
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Number { get; set; }
        public string Type { get; set; }
        public DateTime LastVerificationDate { get; set; }
        public int InterTestingPeriodInDays { get; set; } = 365;
        public Guid? ControlPointId { get; set; }
        public virtual ControlPoint ControlPoint { get; set; }
        [DefaultValue(Status.InStorage)]
        public Status Status { get; set; }
        public Device() { }
    }
}
