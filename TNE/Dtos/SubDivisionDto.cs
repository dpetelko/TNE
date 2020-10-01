using System;
using TNE.Models;

namespace TNE.Dto
{
    public class SubDivisionDto : DivisionDto, IEquatable<SubDivisionDto>
    {
        public Guid LeadDivisionId { get; set; }
        public string LeadDivisionName { get; set; }

        public SubDivisionDto() { }

        public SubDivisionDto(SubDivision entity)
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
            LeadDivisionId = entity.LeadDivision.Id;
            LeadDivisionName = entity.LeadDivision.Name;
        }

        public override string ToString()
        {
            return $"SubDivisionDto" +
                $"[ Id:{Id}, " +
                $"Name:{Name}, " +
                $"PostCode:{PostCode}, " +
                $"Country:{Country}, " +
                $"Region:{Region}, " +
                $"City:{City}, " +
                $"Street:{Street}, " +
                $"Building:{Building}, " +
                $"LeadDivisionName:{LeadDivisionName} " +
                $"Deleted:{Deleted} ]";
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as SubDivisionDto);
        }

        public bool Equals(SubDivisionDto other)
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
