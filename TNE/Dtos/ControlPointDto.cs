﻿using System;
using System.ComponentModel.DataAnnotations;
using TNE.Models;
using TNE.Services.Validators;

namespace TNE.Dtos
{
    public class ControlPointDto
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "The {0} length must be between {2} and {1} characters.")]
        [UniqueField]
        public string Name { get; set; }
        [Required]
        public bool Deleted { get; set; }
        [Required]
        public Guid ProviderId { get; set; }
        public string ProviderName { get; set; }
        public ElectricityMeterDto ElectricityMeter { get; set; }
        public TransformerDto CurrentTransformer { get; set; }
        public TransformerDto VoltageTransformer { get; set; }

        public ControlPointDto() { }

        public ControlPointDto(ControlPoint entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Deleted = entity.Deleted;
            ProviderId = entity.Provider.Id;
            ProviderName = entity.Provider.Name;
            CurrentTransformer = new CurrentTransformerDto(entity.CurrentTransformer);
            VoltageTransformer = new VoltageTransformerDto(entity.VoltageTransformer);
            ElectricityMeter = new ElectricityMeterDto(entity.ElectricityMeter);
        }
    }
}
