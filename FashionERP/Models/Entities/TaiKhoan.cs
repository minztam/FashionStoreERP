using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FashionERP.Models.Entities
{
    public class TaiKhoan
    {
        [Key]
        [StringLength(10)]
        public string Ma_TaiKhoan { get; set; } = string.Empty;

        [Required, StringLength(50)]
        public string Ten_DangNhap { get; set; } = null!;

        [StringLength(100)]
        public string? Email { get; set; }

        [Required, StringLength(255)]
        public string Mat_Khau { get; set; } = null!;

        [Required, StringLength(50)]
        public string Ma_VaiTro { get; set; } = null!;

        public bool Trang_Thai { get; set; } = true;
        public DateTime Ngay_Tao { get; set; } = DateTime.Now;
        public bool Da_XacThuc { get; set; } = false;

        [StringLength(255)]
        public string? Ma_XacThuc { get; set; }
        public DateTime? Han_XacThuc { get; set; }

        [ForeignKey("Ma_VaiTro")]
        public VaiTro? VaiTro { get; set; }

        public NhanVien? NhanVien { get; set; }
        public KhachHang? KhachHang { get; set; }
    }
}
