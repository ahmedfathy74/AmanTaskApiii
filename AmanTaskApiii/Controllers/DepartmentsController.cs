using AmanTaskApiii.DTOs;
using AmanTaskApiii.Models;
using AmanTaskApiii.Repositiories.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AmanTaskApiii.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly ITaskRepo<Department> _repoDepartment;
        public DepartmentsController(ITaskRepo<Department> repoDepartment)
        {
            _repoDepartment = repoDepartment;
        }
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Department>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Department>>> GetAllDepartments()
        {
            var Departments = await _repoDepartment.GetAllEntries();
            return Ok(Departments);
        }
        [HttpPost]
        [ProducesResponseType(typeof(Department),StatusCodes.Status201Created)]
        public async Task<ActionResult> CreateDepartment(DepartmentDto DepDto)
        {
            var department = new Department { Name = DepDto.Name };
            await _repoDepartment.AddNewOne(department);
            return Ok(department);
        }
        [HttpPut]
        [ProducesResponseType(typeof(Department),StatusCodes.Status201Created)]
        public async Task<ActionResult> UpdateDepartment(DepartmentDto DepDto)
        {
            var department = await _repoDepartment.GetByID(DepDto.ID);
            if(department ==null)
            {
                return NotFound($"No Department Was Found with ID: {DepDto.ID}");
            }
            department.Name = DepDto.Name;
            return Ok(await _repoDepartment.UpdateOne(department));
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDepartment(int id)
        {
            var department = await _repoDepartment.GetByID(id);
            if (department == null)
            {
                return NotFound($"No Employee Was Found with ID: {id}");
            }
            await _repoDepartment.DeleteOne(id);
            return Ok();
        }
    }
}
