


using System.ComponentModel.DataAnnotations;

namespace DemoMVC.Models
{
    public class Student
    {
        public int Id { get; set; }

        // Mã sinh viên do hệ thống tự tạo.
        // Cho phép null khi nhận dữ liệu từ biểu mẫu.
        [StringLength(10)]
        public string? StudentCode { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập họ và tên.")]
        [StringLength(100, ErrorMessage = "Họ và tên không được vượt quá 100 ký tự.")]
        public string FullName { get; set; } = string.Empty;

        [StringLength(200)]
        public string? Address { get; set; }

        [StringLength(100)]
        public string? University { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn khoa.")]
        public int? FacultyId { get; set; }

        public Faculty? Faculty { get; set; }
    }
}
