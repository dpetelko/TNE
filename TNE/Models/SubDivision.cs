using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TNE.Models
{
    public class SubDivision : Division, IEquatable<SubDivision>
    {
        public Guid? LeadDivisionId { get; set; }
        [ForeignKey("LeadDivisionId")]
        public LeadDivision LeadDivision { get; set; }
        //public List<Provider> Providers { get; set; }

        public SubDivision() { }

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
                $"LeadDivision:{LeadDivision} " +
                $"Deleted:{Deleted} ]";
        }

    }
}