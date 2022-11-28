using System.Linq.Expressions;

namespace AmanTaskApiii.Repositiories.Base
{
    public interface ITaskRepo <T> where T:class
    {
        Task<T> GetByID(int id);
        Task<IEnumerable<T>> GetAllEntries(string[] includes = null);
        Task AddNewOne(T Entity);
        Task DeleteOne(int ID);
        Task<T> UpdateOne(T Entity);
        Task<T> Find(Expression<Func<T, bool>> id, string[] includes = null);
    }
}
