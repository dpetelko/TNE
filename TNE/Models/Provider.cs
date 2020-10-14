using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TNE.Models
{
    public class Provider : Division, IEquatable<Provider>
    {
        public Guid? SubDivisionId { get; set; }
        [ForeignKey("SubDivisionId")]
        public SubDivision SubDivision { get; set; }
        //public List<ControlPoint> ControlPoints { get; set; }
        //public List<DeliveryPoint> DeliveryPoints { get; set; }

        public Provider() { }

        public override bool Equals(object obj)
        {
            return Equals(obj as Provider);
        }

        public bool Equals(Provider other)
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
            return $"Provider" +
                $"[ Id:{Id}, " +
                $"Name:{Name}, " +
                $"Address:{Address}, " +
                $"SubDivision:{SubDivision} " +
                $"Deleted:{Deleted} ]";
        }

    }
}