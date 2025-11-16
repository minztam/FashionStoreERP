using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FashionERP.Models.Entities
{
    public class DonHang
    {
        [Key, StringLength(20)]
        public string Ma_DonHang { get; set; } = null!;

        [Required]
        [StringLength(10)]
        public string Ma_KhachHang { get; set; } = null!;

        public DateTime Ngay_Dat { get; set; } = DateTime.Now;

        [Column(TypeName = "decimal(18,2)")]
        public decimal Tong_Tien { get; set; }

        [StringLength(50)]
        public string Trang_Thai { get; set; } = "Chờ xác nhận";

        [Required]
        [StringLength(10)]
        public string Ma_PhuongThuc { get; set; } = string.Empty;

        [StringLength(50)]
        public string? Ma_Voucher { get; set; }

        [ForeignKey("Ma_KhachHang")]
        public KhachHang KhachHang { get; set; } = null!;

        [ForeignKey("Ma_PhuongThuc")]
        public PhuongThucThanhToan PhuongThucThanhToan { get; set; } = null!;

        [ForeignKey("Ma_Voucher")]
        public Voucher? Voucher { get; set; }

        public ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; } = [];
    }
}