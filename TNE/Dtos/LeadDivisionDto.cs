using System;
using TNE.Models;

namespace TNE.Dto
{
    public class LeadDivisionDto : DivisionDto, IEquatable<LeadDivisionDto>
    {
        public LeadDivisionDto() { }

        public LeadDivisionDto(LeadDivision entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            Id = entity.Id;
            Name = entity.Name;
            Deleted = entity.Deleted;
            AddressId = entity.Address.Id;
            PostCode = entity.Address.PostCode;
            Country = entity.Address.Country;
            Region = entity.Address.Region;
            City = entity.Address.City;
            Street = entity.Address.Street;
            Building = entity.Address.Building;
            Deleted = entity.Deleted;
        }

        public override string ToString()
        {
            return $"LeadDivisionDto" +
                $"[ Id:{Id}, " +
                $"Name:{Name}, " +
                $"PostCode:{PostCode}, " +
                $"Country:{Country}, " +
                $"Region:{Region}, " +
                $"City:{City}, " +
                $"Street:{Street}, " +
                $"Building:{Building} " +
                $"Deleted:{Deleted} ]";
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as LeadDivisionDto);
        }

        public bool Equals(LeadDivisionDto other)
        {
            return other != null &&
                   base.Equals(other) &&
                   Id.Equals(other.Id) &&
                   Name == other.Name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), Id, Name);
        }
    }
}
