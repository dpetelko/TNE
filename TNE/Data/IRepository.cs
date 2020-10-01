using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TNE.Data
{
    public interface IRepository <T>
    {
        Task<T> GetByIdAsync(Guid id);
        T GetById(Guid id);
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        
        void CheckExistsById(Guid id);
        bool ExistsByField(string fieldName, object fieldValue);
        bool ExistsByFieldAndNotId(Guid id, string fieldName, object fieldValue);
    }
}
