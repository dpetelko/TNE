using System;
using System.ComponentModel.DataAnnotations;
using TNE.Services.Validators;

namespace TNE.Dtos
{
    public class ControlPointDto
    {
        public ControlPointDto() { }

        public Guid Id { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "The {0} length must be between {2} and {1} characters.")]
        [UniqueField]
        public string Name { get; set; }
        public Guid ProviderId { get; set; }
        public string ProviderName { get; set; }
        public ElectricityMeterDto ElectricityMeter { get; set; }
        public TransformerDto CurrentTransformer { get; set; }
        public TransformerDto VoltageTranformer { get; set; }

    }
}
