using AmanTaskApiii.DTOs;
using AmanTaskApiii.Models;
using AmanTaskApiii.Repositiories.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AmanTaskApiii.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ITaskRepo<Employee> _repoEmployee;
        public EmployeesController(ITaskRepo<Employee> repoEmployee)
        {
            _repoEmployee = repoEmployee;
        }
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Employee>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Employee>>> GetAllEmployees()
        {
            var Employees = await _repoEmployee.GetAllEntries(new[] { "Department" });
            return Ok(Employees);
        }
        [HttpPost]
        [ProducesResponseType(typeof(Employee), StatusCodes.Status201Created)]
        public async Task<ActionResult> CreateEmployee(EmployeesDto DepDto)
        {
            var GetDepartment = await _repoEmployee.Find(b => b.DepartmentId == DepDto.DepartmentId, new[] { "Department" });
            var Employee = new Employee 
            { 
                Name = DepDto.Name ,
                Address = DepDto.Address,
                age = DepDto.age,
                Salary = DepDto.Salary,
                DepartmentId = DepDto.DepartmentId,
                Department = GetDepartment.Department
            };
            await _repoEmployee.AddNewOne(Employee);
            return Ok(Employee);
        }
        [HttpPut]
        [ProducesResponseType(typeof(Employee), StatusCodes.Status201Created)]
        public async Task<ActionResult> UpdateEmployee(EmployeesDto DepDto)
        {
            var Employee = await _repoEmployee.GetByID(DepDto.Id);
            if (Employee == null)
            {
                return NotFound($"No Employee Was Found with ID: {DepDto.Id}");
            }
            Employee.Name = DepDto.Name;
            Employee.Address = DepDto.Address;
            Employee.age = DepDto.age;
            Employee.Salary = DepDto.Salary;
            Employee.DepartmentId = DepDto.DepartmentId;

            return Ok(await _repoEmployee.UpdateOne(Employee));
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            var Employee = await _repoEmployee.GetByID(id);
            if (Employee == null)
            {
                return NotFound($"No Employee Was Found with ID: {id}");
            }
            await _repoEmployee.DeleteOne(id);
            return Ok();
        }
    }
}
