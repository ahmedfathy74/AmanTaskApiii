using System.ComponentModel.DataAnnotations;

namespace AmanTaskApiii.DTOs
{
    public class EmployeesDto
    {
        public int Id { get; set; }
        [MaxLength(200)]
        public string Name { get; set; }
        public string Address { get; set; }
        public int age { get; set; }
        public int Salary { get; set; }
        public int DepartmentId { get; set; }
    }
}
