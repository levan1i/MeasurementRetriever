using MeasurementRetriever.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeasurementRetriever.Repository
{
    public class Genericrepository<T> : IGenericRepository<T> where T : class
    {

        protected readonly MeasurementRetrieverDbContext _context;

        public Genericrepository(MeasurementRetrieverDbContext context)
        {
            _context = context;
        }

        public async Task<T> Get(long id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        

        public async Task<T> Get(string id)
        {
            return await _context.Set<T>().FindAsync(id);
        }


        public async Task<T> Add(T entity)
        {
            var res = await _context.Set<T>().AddAsync(entity);

            return res.Entity;
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
