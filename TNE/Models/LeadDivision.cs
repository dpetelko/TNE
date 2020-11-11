using System;
using TNE.Dto.LeadDivisions;

namespace TNE.Models
{
    public class LeadDivision : Division, IEquatable<LeadDivision>
    {
        //public List<SubDivision> SubDivisions { get; set; }

        public LeadDivision() { }

        public LeadDivision(LeadDivisionDto dto)
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
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as LeadDivision);
        }

        public bool Equals(LeadDivision other)
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
            return $"LeadDivision" +
                $"[ Id:{Id}, " +
                $"Name:{Name}, " +
                $"Address:{Address} " +
                $"Deleted:{Deleted}  ]";
        }
    }
}
