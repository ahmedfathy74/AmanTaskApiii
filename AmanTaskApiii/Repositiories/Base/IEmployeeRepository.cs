using AmanTaskApiii.Models;

namespace AmanTaskApiii.Repositiories.Base
{
    public interface IEmployeeRepository : ITaskRepo<Employee>
    {
        Task<IEnumerable<Employee>> GetAllEmployeeByDepartment(string name);

    }
}
