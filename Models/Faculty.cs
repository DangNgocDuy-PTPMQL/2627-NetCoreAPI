

using System.ComponentModel.DataAnnotations;

namespace DemoMVC.Models
{
    public class Faculty
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên khoa.")]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        public ICollection<Student> Students { get; set; }
            = new List<Student>();
    }
}

