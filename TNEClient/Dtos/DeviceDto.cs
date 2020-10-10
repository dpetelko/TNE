﻿using System;
using System.ComponentModel.DataAnnotations;

namespace TNEClient.Dtos
{
    public class DeviceDto : IEquatable<DeviceDto>
    {
        public Guid Id { get; set; }
        [Required]
        [Display(Name = "Номер")]
        public string Number { get; set; }
        [Required(ErrorMessage = "Введите значение")]
        [Display(Name = "Тип")]
        public string Type { get; set; }
        
        
        [DataType(DataType.Date)]
        [Display(Name = "Дата последней поверки")]
        public DateTime LastVerificationDate { get; set; }
        [Display(Name = "Межповерочный период")]
        public int InterTestingPeriodInDays { get; set; } = 365;
        public Guid ControlPointId { get; set; }
        [Display(Name = "Точка контроля электроэнергии")]
        public string ControlPointName { get; set; }
        [EnumDataType(typeof(Status), ErrorMessage = "Invalid Status value")]
        [Display(Name = "Статус прибора")]
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
