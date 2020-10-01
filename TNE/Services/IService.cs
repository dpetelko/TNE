using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TNE.Services
{
    public interface IService<T>
    {
        Task<T> GetByIdAsync(Guid id);
        T GetById(Guid id);
        void CheckExistsById(Guid id);
        bool IsFieldUnique(Guid id, string fieldName, object fieldValue);
    }
}
