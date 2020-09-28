using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TNE.Dto.LeadDivisions;

namespace TNE.Models
{
    public class LeadDivision : Division
    {
        public List<SubDivision> SubDivisions { get; set; }

        public LeadDivision()
        {
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
