using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TNE.Data.Implementations
{
    public class ElectricityMeterRepositoryImpl
    {
        private readonly DatabaseContext _context;

        public ElectricityMeterRepositoryImpl(DatabaseContext context) { _context = context; }
    }
}
