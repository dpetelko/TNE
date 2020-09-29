using System;
namespace TNE.Dtos
{
    public class ControlPointDto
    {
        public ControlPointDto() { }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid ProviderId { get; set; }
        public string ProviderName { get; set; }
        public ElectricityMeterDto ElectricityMeter { get; set; }
        public TransformerDto CurrentTransformer { get; set; }
        public TransformerDto VoltageTranformer { get; set; }

    }
}
