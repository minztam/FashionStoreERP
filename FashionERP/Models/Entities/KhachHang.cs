using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FashionERP.Models.Entities
{
    public class KhachHang
    {
        [Key]
        [StringLength(10)]
        public string Ma_KhachHang { get; set; } = null!;

        [Required]
        [StringLength(10)]
        public string Ma_TaiKhoan { get; set; } = null!;

        [StringLength(100)]
        public string? HoTen { get; set; }

        [StringLength(10)]
        public string? SoDienThoai { get; set; }

        [StringLength(255)]
        public string? DiaChi { get; set; }

        [StringLength(255)]
        public string? Hinh_Anh { get; set; }

        [ForeignKey("Ma_TaiKhoan")]
        public TaiKhoan TaiKhoan { get; set; } = null!;

        public ICollection<GioHang> GioHangs { get; set; } = [];
        public ICollection<DonHang> DonHangs { get; set; } = [];
    }
}
