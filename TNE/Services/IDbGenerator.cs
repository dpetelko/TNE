using System.Threading.Tasks;

namespace TNE.Services
{
    public interface IDbGenerator
    {
        /// <summary>
        /// Generate example data for DB 
        /// </summary>
        Task Start();
    }
}