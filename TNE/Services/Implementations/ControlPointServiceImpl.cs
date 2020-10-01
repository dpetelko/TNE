using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TNE.Models;

namespace TNE.Services.Implementations
{
    public class ControlPointServiceImpl : IControlPointService
    {
        public void CheckExistsById(Guid id)
        {
            throw new NotImplementedException();
        }

        public ControlPoint GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ControlPoint> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool IsFieldUnique(Guid id, string fieldName, object fieldValue)
        {
            throw new NotImplementedException();
        }
    }
}
