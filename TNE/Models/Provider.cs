using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TNE.Models
{
    public class Provider : Division
    {
        public Guid? SubDivisionId { get; set; }
        public SubDivision SubDivision { get; set; }
        public List<ControlPoint> ControlPoints { get; set; }
        public List<DeliveryPoint> DeliveryPoints { get; set; }

        public Provider() { }

        public override string ToString()
        {
            return $"Provider" +
                $"[ Id:{Id}, " +
                $"Name:{Name}, " +
                $"Address:{Address}, " +
                $"SubDivisionName:{SubDivision.Name} " +
                $"Deleted:{Deleted} ]";
        }
    }
}