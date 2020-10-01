using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TNE.Models
{
    public class SubDivision : Division
    {
        public Guid? LeadDivisionId { get; set; }
        public LeadDivision LeadDivision { get; set; }
        public List<Provider> Providers { get; set; }
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