using System.ComponentModel.DataAnnotations;

namespace AmanTaskApiii.Models
{
    public class Department
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
