using AmanTaskApiii.Models;
using AmanTaskApiii.Repositiories.Base;
using Microsoft.EntityFrameworkCore;

namespace AmanTaskApiii.Repositiories
{
    public class EmployeeRepository : TaskRepo<Employee>, IEmployeeRepository
    {
        private readonly ApplicationDbContext _dBContext;
        public EmployeeRepository(ApplicationDbContext context) : base(context)
        {
            _dBContext = context;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeeByDepartment(string name)
        {
            var result = await _dBContext.Employees.Where(e => e.Department.Name == name).Include(e => e.Department)

                 .ToListAsync();

            return result;

        }
    }
}
