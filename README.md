# 2627-NetCoreAPI
# TÌM HIỂU CẤU TRÚC DỰ ÁN ASP.NET CORE MVC VÀ ĐỊNH TUYẾN (ROUTING)

## 1. Giới thiệu

ASP.NET Core MVC là một framework của Microsoft dùng để xây dựng các ứng dụng web theo mô hình **MVC (Model – View – Controller)**. Mô hình này giúp tách riêng phần xử lý dữ liệu, xử lý logic và phần giao diện, từ đó giúp chương trình dễ hiểu, dễ bảo trì và dễ mở rộng hơn.

Trong tài liệu này, em sẽ trình bày:

* Cấu trúc thư mục của một dự án ASP.NET Core MVC
* Khái niệm và cách hoạt động của định tuyến (Routing) trong ASP.NET Core MVC

---

## 2. Cấu trúc thư mục của dự án ASP.NET Core MVC

Một dự án ASP.NET Core MVC sau khi tạo mới thường có cấu trúc thư mục cơ bản như sau:

```
YourProjectName
│
├── Controllers
│   ├── HomeController.cs
│   └── StudentController.cs
│
├── Models
│   └── Student.cs
│
├── Views
│   ├── Home
│   │   └── Index.cshtml
│   ├── Student
│   │   └── Index.cshtml
│   └── Shared
│       ├── _Layout.cshtml
│       └── Error.cshtml
│
├── wwwroot
│   ├── css
│   ├── js
│   └── lib
│
├── Program.cs
├── appsettings.json
└── README.md
```

### 2.1. Thư mục Controllers

* Thư mục **Controllers** chứa các lớp Controller của ứng dụng.
* Controller có nhiệm vụ:

  * Nhận request từ người dùng
  * Xử lý nghiệp vụ
  * Trả kết quả về cho View

Ví dụ: `StudentController.cs` dùng để xử lý các chức năng liên quan đến sinh viên.

---

### 2.2. Thư mục Models

* Thư mục **Models** chứa các class dùng để mô tả dữ liệu.
* Model giúp trao đổi dữ liệu giữa Controller và View.

Ví dụ class Student:

```csharp
public class Student
{
    public string StudentCode { get; set; }
    public string FullName { get; set; }
}
```

---

### 2.3. Thư mục Views

* Thư mục **Views** chứa các file giao diện có đuôi `.cshtml`.
* Mỗi Controller thường sẽ có một thư mục View tương ứng.

Ví dụ:

* `StudentController` → `Views/Student/Index.cshtml`

#### Thư mục Shared

* Chứa các View dùng chung cho toàn bộ ứng dụng như:

  * `_Layout.cshtml`: giao diện chung
  * `Error.cshtml`: trang hiển thị lỗi

---

### 2.4. Thư mục wwwroot

* Chứa các tài nguyên tĩnh như:

  * CSS
  * JavaScript
  * Hình ảnh
* Các file trong wwwroot có thể được truy cập trực tiếp từ trình duyệt.

---

### 2.5. File Program.cs

* Là file khởi động chính của ứng dụng.
* Dùng để cấu hình các middleware và routing cho ứng dụng.

---

## 3. Định tuyến (Routing) trong ASP.NET Core MVC

### 3.1. Khái niệm định tuyến

Định tuyến (Routing) là cơ chế dùng để ánh xạ **đường dẫn URL** của người dùng đến **Controller** và **Action** tương ứng trong ứng dụng.

Nhờ có routing, khi người dùng truy cập một URL bất kỳ, hệ thống sẽ biết phải xử lý request đó ở đâu.

---

# TÌM HIỂU CẤU TRÚC DỰ ÁN ASP.NET CORE MVC VÀ ĐỊNH TUYẾN (ROUTING)

## 1. Giới thiệu

ASP.NET Core MVC là một framework của Microsoft dùng để xây dựng các ứng dụng web theo mô hình **MVC (Model – View – Controller)**. Mô hình này giúp tách riêng phần xử lý dữ liệu, xử lý logic và phần giao diện, từ đó giúp chương trình dễ hiểu, dễ bảo trì và dễ mở rộng hơn.

Trong tài liệu này, em sẽ trình bày:

* Cấu trúc thư mục của một dự án ASP.NET Core MVC
* Khái niệm và cách hoạt động của định tuyến (Routing) trong ASP.NET Core MVC

---

## 2. Cấu trúc thư mục của dự án ASP.NET Core MVC

Một dự án ASP.NET Core MVC sau khi tạo mới thường có cấu trúc thư mục cơ bản như sau:

```
YourProjectName
│
├── Controllers
│   ├── HomeController.cs
│   └── StudentController.cs
│
├── Models
│   └── Student.cs
│
├── Views
│   ├── Home
│   │   └── Index.cshtml
│   ├── Student
│   │   └── Index.cshtml
│   └── Shared
│       ├── _Layout.cshtml
│       └── Error.cshtml
│
├── wwwroot
│   ├── css
│   ├── js
│   └── lib
│
├── Program.cs
├── appsettings.json
└── README.md
```

### 2.1. Thư mục Controllers

* Thư mục **Controllers** chứa các lớp Controller của ứng dụng.
* Controller có nhiệm vụ:

  * Nhận request từ người dùng
  * Xử lý nghiệp vụ
  * Trả kết quả về cho View

Ví dụ: `StudentController.cs` dùng để xử lý các chức năng liên quan đến sinh viên.

---

### 2.2. Thư mục Models

* Thư mục **Models** chứa các class dùng để mô tả dữ liệu.
* Model giúp trao đổi dữ liệu giữa Controller và View.

Ví dụ class Student:

```csharp
public class Student
{
    public string StudentCode { get; set; }
    public string FullName { get; set; }
}
```

---

### 2.3. Thư mục Views

* Thư mục **Views** chứa các file giao diện có đuôi `.cshtml`.
* Mỗi Controller thường sẽ có một thư mục View tương ứng.

Ví dụ:

* `StudentController` → `Views/Student/Index.cshtml`

#### Thư mục Shared

* Chứa các View dùng chung cho toàn bộ ứng dụng như:

  * `_Layout.cshtml`: giao diện chung
  * `Error.cshtml`: trang hiển thị lỗi

---

### 2.4. Thư mục wwwroot

* Chứa các tài nguyên tĩnh như:

  * CSS
  * JavaScript
  * Hình ảnh
* Các file trong wwwroot có thể được truy cập trực tiếp từ trình duyệt.

---

### 2.5. File Program.cs

* Là file khởi động chính của ứng dụng.
* Dùng để cấu hình các middleware và routing cho ứng dụng.

---

## 3. Định tuyến (Routing) trong ASP.NET Core MVC

### 3.1. Khái niệm định tuyến

Định tuyến (Routing) là cơ chế dùng để ánh xạ **đường dẫn URL** của người dùng đến **Controller** và **Action** tương ứng trong ứng dụng.

Nhờ có routing, khi người dùng truy cập một URL bất kỳ, hệ thống sẽ biết phải xử lý request đó ở đâu.

---

### 3.2. Route mặc định

Trong file `Program.cs`, route mặc định thường được cấu hình như sau:

```csharp
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
```

Ý nghĩa:

* `controller=Home`: Controller mặc định là Home
* `action=Index`: Action mặc định là Index
* `{id?}`: tham số tùy chọn

---

### 3.3. Ví dụ về route

| URL                 | Controller | Action |
| ------------------- | ---------- | ------ |
| `/`                 | Home       | Index  |
| `/Student`          | Student    | Index  |
| `/Student/Index`    | Student    | Index  |
| `/Student/Detail/1` | Student    | Detail |

---

### 3.4. Route có tham số

Ví dụ URL:

```
/Student/Detail/5
```

Controller:

```csharp
public IActionResult Detail(int id)
{
    return Content("ID sinh viên: " + id);
}
```

---

### 3.5. Attribute Routing

Ngoài cách định tuyến mặc định, ASP.NET Core MVC còn hỗ trợ định tuyến bằng Attribute:

```csharp
[Route("sinh-vien")]
public class StudentController : Controller
{
    [Route("danh-sach")]
    public IActionResult Index()
    {
        return View();
    }
}
```

Khi đó, người dùng có thể truy cập bằng URL:

```
/sinh-vien/danh-sach
```

---

## 4. Kết luận

Qua quá trình tìm hiểu, em nhận thấy ASP.NET Core MVC có cấu trúc thư mục rõ ràng, dễ tiếp cận đối với người mới học. Bên cạnh đó, cơ chế định tuyến giúp việc xử lý các request từ người dùng trở nên linh hoạt và hiệu quả hơn.

Việc nắm vững cấu trúc thư mục và routing là nền tảng quan trọng để tiếp tục học và phát triển các ứng dụng web bằng ASP.NET Core MVC.

