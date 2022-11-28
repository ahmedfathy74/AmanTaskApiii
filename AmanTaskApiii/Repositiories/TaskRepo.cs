using AmanTaskApiii.Models;
using AmanTaskApiii.Repositiories.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace AmanTaskApiii.Repositiories
{
    public class TaskRepo<T> : ITaskRepo<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        public TaskRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddNewOne(T Entity)
        {
             await _context.Set<T>().AddAsync(Entity);
             await _context.SaveChangesAsync();
        }

        public async Task DeleteOne(int ID)
        {
            var entry = await _context.Set<T>().FindAsync(ID);
            _context.Set<T>().Remove(entry);
            await _context.SaveChangesAsync();
        }

        public async Task<T> Find(Expression<Func<T,bool>> id, string[] includes = null)
        {
            IQueryable<T> query = _context.Set<T>();
            if (includes != null)
            {
                foreach (var include in includes)
                    query = query.Include(include);
            }
            return await query.SingleOrDefaultAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllEntries(string[] includes = null)
        {
            IQueryable<T> query = _context.Set<T>();
            if (includes != null)
            {
                foreach (var include in includes)
                    query = query.Include(include);
            }
            return await query.ToListAsync();
            //return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByID(int id)
        {
          
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> UpdateOne(T Entity)
        {
            _context.Set<T>().Update(Entity);
            await _context.SaveChangesAsync();
            return Entity;
        }
    }
}
