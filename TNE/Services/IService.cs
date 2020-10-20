using System;
using System.Threading.Tasks;
using TNE.Data.Exceptions;

namespace TNE.Services
{
    public interface IService<T>
    {
        /// <summary>
        /// Returns a specific Object by ID
        /// </summary>
        /// <exception cref="EntityNotFoundException">If no <typeparamref name="T"/>s are found</exception>
        Task<T> GetByIdAsync(Guid id);
        
        /// <summary>
        /// Returns a specific <typeparamref name="T"/> by ID
        /// </summary>
        /// <exception cref="EntityNotFoundException">If no <typeparamref name="T"/>s are found</exception>
        T GetById(Guid id);
        
        /// <summary>
        /// Check exists <typeparamref name="T"/> by ID
        /// </summary>
        /// <exception cref="EntityNotFoundException">If no <typeparamref name="T"/>s are found</exception>
        void CheckExistsById(Guid id);
        
        /// <summary>
        /// Check unique field 
        /// </summary>
        bool IsFieldUnique(Guid id, string fieldName, object fieldValue);
    }
}
