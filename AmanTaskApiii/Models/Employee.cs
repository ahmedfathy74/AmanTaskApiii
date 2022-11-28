using System.ComponentModel.DataAnnotations;

namespace AmanTaskApiii.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [MaxLength(200)]
        public string Name { get; set; }
        public string Address { get; set; }
        public int age { get; set; }
        public int Salary { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
