using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ASP.Models;

namespace ASP.Controllers;

public class StudentController : Controller
{
    // Static list để lưu danh sách sinh viên đã đăng ký
    private static List<Student> danhSachSV = new List<Student>();

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult ShowKQ(Student student)
    {
        // Thêm sinh viên vào danh sách
        danhSachSV.Add(student);

        // Đếm số lượng sinh viên đã đăng ký chuyên ngành giống nhau
        int soLuong = danhSachSV.Count(s => s.ChuyenNganh == student.ChuyenNganh);

        // Truyền dữ liệu và số lượng sang View
        ViewBag.Student = student;
        ViewBag.SoLuong = soLuong;

        return View(student);
    }
}
