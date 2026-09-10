using Microsoft.AspNetCore.Mvc;
using FirstWebMVC.Models;

namespace FirstWebMVC.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            // ViewBag
            ViewBag.PageTitle = "Danh mục thiết bị điện";
            ViewBag.WelcomeMessage = "Chào mừng bạn đến với cửa hàng thiết bị điện";

            // ViewData
            ViewData["StoreName"] = "Điện Việt Store";
            ViewData["Contact"] = "Hotline: 0917 333 000";

            // Model
            Product product = new Product
            {
                Name = "Ổ cắm điện Panasonic",
                Price = 150000,
                Category = "Thiết bị điện"
            };

            return View(product);
        }

        [HttpPost]
        public IActionResult Add(string name)
        {
            TempData["SuccessMessage"] = "Thêm sản phẩm thành công!";
            TempData["AddedProduct"] = name;

            return RedirectToAction("Index");
        }
    }
}