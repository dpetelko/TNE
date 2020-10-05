using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using TNE.Models;
using TNE.Services.Validators;

namespace TNEClient.Dtos
{
    public class DeliveryPointDto : IEquatable<DeliveryPointDto>
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "The {0} length must be between {2} and {1} characters")]
        [UniqueField]
        public string Name { get; set; }
        [Required]
        public int MaxPower { get; set; }
        [Required]
        public Guid ProviderId { get; set; }
        public string ProviderName { get; set; }
        [Required]
        public bool Deleted { get; set; }

        public DeliveryPointDto() { }

        public DeliveryPointDto(DeliveryPoint entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            Id = entity.Id;
            Name = entity.Name;
            MaxPower = entity.MaxPower;
            Deleted = entity.Deleted;
            ProviderId = entity.Provider.Id;
            ProviderName = entity.Provider.Name;
        }

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
