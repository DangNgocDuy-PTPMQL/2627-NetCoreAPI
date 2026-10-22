





using DemoMVC.Data;
using DemoMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DemoMVC.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;

        private const string StudentCodePrefix = "282105";
        private const int StudentCodeDigits = 4;
        private const int FirstStudentNumber = 1;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Danh sách sinh viên
        public async Task<IActionResult> Index()
        {
            var students = await _context.Students
                .AsNoTracking()
                .Include(s => s.Faculty)
                .OrderBy(s => s.Id)
                .ToListAsync();

            return View(students);
        }

        // Hiển thị trang thêm sinh viên
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            await LoadFacultiesAsync();
            return View(new Student());
        }

        // Thêm sinh viên
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Student student)
        {
            ModelState.Remove(nameof(Student.StudentCode));

            bool facultyExists = student.FacultyId.HasValue &&
                await _context.Faculties.AnyAsync(
                    f => f.Id == student.FacultyId.Value);

            if (!facultyExists)
            {
                ModelState.AddModelError(
                    nameof(Student.FacultyId),
                    "Vui lòng chọn khoa hợp lệ.");
            }

            if (!ModelState.IsValid)
            {
                await LoadFacultiesAsync();
                return View(student);
            }

            try
            {
                student.StudentCode = await GenerateStudentCodeAsync();

                _context.Students.Add(student);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Thêm sinh viên thành công!";
                return RedirectToAction(nameof(Index));
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError(
                    string.Empty,
                    "Không thể lưu sinh viên. Vui lòng kiểm tra dữ liệu và cơ sở dữ liệu.");
            }

            await LoadFacultiesAsync();
            return View(student);
        }

        // Hiển thị trang sửa sinh viên
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var student = await _context.Students
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.Id == id);

            if (student == null)
            {
                return NotFound();
            }

            await LoadFacultiesAsync();
            return View(student);
        }

        // Lưu thông tin sinh viên đã sửa
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Student student)
        {
            if (id != student.Id)
            {
                return BadRequest();
            }

            // Không cho thay đổi mã sinh viên qua biểu mẫu.
            ModelState.Remove(nameof(Student.StudentCode));

            bool facultyExists = student.FacultyId.HasValue &&
                await _context.Faculties.AnyAsync(
                    f => f.Id == student.FacultyId.Value);

            if (!facultyExists)
            {
                ModelState.AddModelError(
                    nameof(Student.FacultyId),
                    "Vui lòng chọn khoa hợp lệ.");
            }

            var existingStudent = await _context.Students
                .FirstOrDefaultAsync(s => s.Id == id);

            if (existingStudent == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                student.StudentCode = existingStudent.StudentCode;
                await LoadFacultiesAsync();
                return View(student);
            }

            existingStudent.FullName = student.FullName;
            existingStudent.Address = student.Address;
            existingStudent.University = student.University;
            existingStudent.FacultyId = student.FacultyId;

            try
            {
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Cập nhật sinh viên thành công!";
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError(
                    string.Empty,
                    "Không thể cập nhật sinh viên. Vui lòng kiểm tra lại dữ liệu.");

                student.StudentCode = existingStudent.StudentCode;
                await LoadFacultiesAsync();
                return View(student);
            }
        }

        // Xóa sinh viên
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var student = await _context.Students
                .FirstOrDefaultAsync(s => s.Id == id);

            if (student == null)
            {
                TempData["ErrorMessage"] = "Không tìm thấy sinh viên cần xóa.";
                return RedirectToAction(nameof(Index));
            }

            try
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Đã xóa sinh viên thành công!";
            }
            catch (DbUpdateException)
            {
                TempData["ErrorMessage"] =
                    "Không thể xóa sinh viên. Dữ liệu có thể đang được sử dụng ở nơi khác.";
            }

            return RedirectToAction(nameof(Index));
        }

        // Nạp danh sách khoa
        private async Task LoadFacultiesAsync()
        {
            var faculties = await _context.Faculties
                .AsNoTracking()
                .OrderBy(f => f.Name)
                .ToListAsync();

            ViewBag.Faculties = new SelectList(
                faculties,
                nameof(Faculty.Id),
                nameof(Faculty.Name));
        }

        // Tạo mã sinh viên tự động
        private async Task<string> GenerateStudentCodeAsync()
        {
            var codes = await _context.Students
                .AsNoTracking()
                .Where(s => s.StudentCode != null &&
                            s.StudentCode.StartsWith(StudentCodePrefix))
                .Select(s => s.StudentCode!)
                .ToListAsync();

            int maxNumber = FirstStudentNumber - 1;

            foreach (string code in codes)
            {
                string suffix = code.Substring(StudentCodePrefix.Length);

                if (suffix.Length == StudentCodeDigits &&
                    int.TryParse(suffix, out int number) &&
                    number > maxNumber)
                {
                    maxNumber = number;
                }
            }

            int maxAllowed =
                (int)Math.Pow(10, StudentCodeDigits) - 1;

            if (maxNumber >= maxAllowed)
            {
                throw new InvalidOperationException(
                    "Đã hết số thứ tự mã sinh viên cho tiền tố 282105.");
            }

            return StudentCodePrefix +
                (maxNumber + 1).ToString($"D{StudentCodeDigits}");
        }
    }
}

