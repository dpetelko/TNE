using System;
using System.ComponentModel.DataAnnotations.Schema;
using TNE.Dto;

namespace TNE.Models
{
    public class SubDivision : Division, IEquatable<SubDivision>
    {
        public Guid? LeadDivisionId { get; set; }
        [ForeignKey("LeadDivisionId")]
        public LeadDivision LeadDivision { get; set; }

        public SubDivision() { }

        public SubDivision(SubDivisionDto dto)
        {
            Id = dto.Id;
            Name = dto.Name;
            AddressId = dto.AddressId;
            Address.PostCode = dto.PostCode;
            Address.Country = dto.Country;
            Address.Region = dto.Region;
            Address.City = dto.City;
            Address.Street = dto.Street;
            Address.Building = dto.Building;
            Deleted = dto.Deleted;
            LeadDivisionId = dto.LeadDivisionId;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as SubDivision);
        }

        public bool Equals(SubDivision other)
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
            return $"SubDivision" +
                $"[ Id:{Id}, " +
                $"Name:{Name}, " +
                $"Address:{Address}, " +
                $"LeadDivisionId:{LeadDivisionId}, " +
                $"LeadDivision:{LeadDivision} " +
                $"Deleted:{Deleted} ]";
        }

    }
}