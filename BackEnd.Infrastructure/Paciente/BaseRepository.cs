using BackEnd.Core.Models;
using BackEnd.Core.Repository;
using BackEnd.Infrastructure.DataBase;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Infrastructure.Paciente
{
    public class BaseRepository<T> : IModelBaseRepository<T> where T : ModelBase
    {
        private readonly BackEndContext _db;

        public BaseRepository(BackEndContext db)
        {
            _db = db;
        }

        public Task<List<T>> GetAllAsync()
        {
            return _db.Set<T>().ToListAsync();
        }

        public async Task CreateAsync(T entity)
        {
            await _db.Set<T>().AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _db.Set<T>().Remove(entity);
            await _db.SaveChangesAsync();
        }

        public Task<T?> GetAsync(long id)
        {
            return _db.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public IQueryable<T> List()
        {
            return _db.Set<T>();
        }
    }
}
