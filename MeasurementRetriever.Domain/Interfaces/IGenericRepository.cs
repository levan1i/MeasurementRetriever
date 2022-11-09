
using System.Threading.Tasks;

namespace MeasurementRetriever.Domain.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> Get(long id);
        Task<T> Get(string id);
        Task<T> Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
