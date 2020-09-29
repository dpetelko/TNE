using System;
namespace TNE.Dtos
{
    public class DeliveryPointDto : IEquatable<DeliveryPointDto>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int MaxPower { get; set; }
        public Guid ProviderId { get; set; }
        public string ProviderName { get; set; }
        public bool Deleted { get; set; }

        public DeliveryPointDto() { }

        public override bool Equals(object obj)
        {
            return Equals(obj as DeliveryPointDto);
        }

        public bool Equals(DeliveryPointDto other)
        {
            return other != null &&
                   Id.Equals(other.Id) &&
                   Name == other.Name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name);
        }

        public override string ToString()
        {
            return $"DeliveryPointDto" +
                $"[ Id:{Id}, " +
                $"Name:{Name}, " +
                $"MaxPower:{MaxPower}, " +
                $"ProviderId:{ProviderId} " +
                $"ProviderName:{ProviderName} " +
                $"Deleted:{Deleted} ]";
        }

    }
}
