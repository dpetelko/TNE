﻿using System;
using System.ComponentModel.DataAnnotations;
using TNE.Models;

namespace TNE.Dtos
{
    public class DeviceDto : IEquatable<DeviceDto>
    {
        public Guid Id { get; set; }
        //[Required]
        public string Number { get; set; }
        //[Required]
        public string Type { get; set; }
        //[Required]
        public DateTime LastVerificationDate { get; set; }
        public int InterTestingPeriodInDays { get; set; } = 365;
        public Guid? ControlPointId { get; set; }
        public string ControlPointName { get; set; }
        //[EnumDataType(typeof(Status), ErrorMessage = "Invalid Status value")]
        public Status Status { get; set; } = Status.InStorage;

        public DeviceDto() { }

        public override bool Equals(object obj)
        {
            return Equals(obj as DeviceDto);
        }

        public bool Equals(DeviceDto other)
        {
            return other != null &&
                   Id.Equals(other.Id) &&
                   Number == other.Number;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Number);
        }

    }
}
