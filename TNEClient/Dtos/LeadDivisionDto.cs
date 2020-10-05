using System;

namespace TNEClient.Dtos
{
    public class LeadDivisionDto : DivisionDto, IEquatable<LeadDivisionDto>
    {
        public LeadDivisionDto() { }

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
