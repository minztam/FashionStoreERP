using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FashionERP.Models.Entities
{
    public class SanPham
    {
        [Key, StringLength(20)]
        public string Ma_SanPham { get; set; } = null!;

        [Required, StringLength(20)]
        public string Ma_DanhMuc { get; set; } = null!;

        [Required, StringLength(200)]
        public string Ten_SanPham { get; set; } = null!;

        public string? Mo_Ta { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Gia { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? Gia_Giam { get; set; }

        public int So_Luong { get; set; }

        [StringLength(50)]
        public string? Mau_Sac { get; set; }

        [StringLength(50)]
        public string? Kich_Thuoc { get; set; }

        public bool Trang_Thai { get; set; } = true;

        [ForeignKey("Ma_DanhMuc")]
        public DanhMuc DanhMuc { get; set; } = null!;

        public ICollection<HinhAnhSanPham> HinhAnhSanPhams { get; set; } = [];
        public ICollection<ChiTietGioHang> ChiTietGioHangs { get; set; } = [];
        public ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; } = [];
    }
}