using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FashionERP.Models.Entities
{
    public class NhanVien
    {
        [Key]
        [StringLength(10)]
        public string Ma_NhanVien { get; set; } = string.Empty;

        [Required]
        [StringLength(10)] 
        public string Ma_TaiKhoan { get; set; } = null!;

        [StringLength(100)]
        public string? HoTen { get; set; }

        [StringLength(20)]
        public string? SoDienThoai { get; set; }

        [StringLength(255)]
        public string? DiaChi { get; set; }

        [StringLength(255)]
        public string? Hinh_Anh { get; set; }

        [ForeignKey("Ma_TaiKhoan")]
        public TaiKhoan TaiKhoan { get; set; } = null!;
    }
}
