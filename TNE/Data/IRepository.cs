using System;
using System.Threading.Tasks;
using TNE.Data.Exceptions;

namespace TNE.Data
{
    public interface IRepository<T>
    {
        /// <summary>
        /// Returns a specific Object by ID
        /// </summary>
        /// <exception cref="EntityNotFoundException">If no Object are found</exception>
        Task<T> GetByIdAsync(Guid id);

        /// <summary>
        /// Returns a specific Object by ID
        /// </summary>
        /// <exception cref="EntityNotFoundException">If no Object are found</exception>
        T GetById(Guid id);

        /// <summary>
        /// Creates a Object. 
        /// Returns a newly created Object
        /// </summary>
        /// <exception cref="InvalidEntityException">If Object are invalid, e.g. ID is not Guid.Empty</exception>
        Task<T> CreateAsync(T entity);

        /// <summary>
        /// Updates a Object. Returns a updated Object
        /// </summary>
        /// <exception cref="InvalidEntityException">If Object are invalid, e.g. ID is Guid.Empty</exception>
        /// <exception cref="EntityNotFoundException">If Object are not found with this ID</exception>
        Task<T> UpdateAsync(T entity);

        /// <summary>
        /// Check exists Object in Database by ID
        /// </summary>
        /// <exception cref="EntityNotFoundException">If no Objects are found</exception>
        void CheckExistsById(Guid id);

        /// <summary>
        /// Check exists Object in Database by Field
        /// </summary>
        /// <exception cref="EntityNotFoundException">If no Objects are found</exception>
        bool ExistsByField(string fieldName, object fieldValue);

        /// <summary>
        /// Check exists Object in Database by Field and not this ID
        /// </summary>
        /// <exception cref="EntityNotFoundException">If no Objects are found</exception>
        bool ExistsByFieldAndNotId(Guid id, string fieldName, object fieldValue);
    }
}
