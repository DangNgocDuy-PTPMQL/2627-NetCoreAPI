using System.ComponentModel.DataAnnotations;

namespace DemoMVC.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên sản phẩm không được để trống")]
        [StringLength(100, ErrorMessage = "Tên sản phẩm không được vượt quá 100 ký tự")]
        public string Name { get; set; } = "";

        [Required(ErrorMessage = "Giá sản phẩm không được để trống")]
        [Range(1000, 100000000, ErrorMessage = "Giá phải từ 1.000 đến 100.000.000 VNĐ")]
        public decimal? Price { get; set; }

        [Required(ErrorMessage = "Số lượng không được để trống")]
        [Range(1, 10000, ErrorMessage = "Số lượng phải từ 1 đến 10.000")]
        public int? Quantity { get; set; }

        [Required(ErrorMessage = "Danh mục không được để trống")]
        [StringLength(100, ErrorMessage = "Danh mục không được vượt quá 100 ký tự")]
        public string Category { get; set; } = "";
    }
}

