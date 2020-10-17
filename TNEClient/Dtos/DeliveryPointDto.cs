using System;
using System.ComponentModel.DataAnnotations;

namespace TNEClient.Dtos
{
    public class DeliveryPointDto : IEquatable<DeliveryPointDto>
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Введите значение")]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "The {0} length must be between {2} and {1} characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Введите значение")]
        [Range(1, Int32.MaxValue, ErrorMessage = "Неверное значение поля")]
        public int MaxPower { get; set; }
        [NotEmptyGuid("Выберите значение")]
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
