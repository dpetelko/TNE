using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TNE.Data.Exceptions;
using TNE.Models;
using static System.String;

namespace TNE.Data.Implementations
{
    public class SubDivisionRepositoryImpl //: ISubDivisionRepository
    {
        private readonly DatabaseContext _context;

        public SubDivisionRepositoryImpl(DatabaseContext context)
        {
            _context = context;
        }
        
    }
}
