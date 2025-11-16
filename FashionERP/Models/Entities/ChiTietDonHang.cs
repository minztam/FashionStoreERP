using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FashionERP.Models.Entities
{
    public class ChiTietDonHang
    {
        [Required, StringLength(20)]
        public string Ma_DonHang { get; set; } = null!;

        [Required, StringLength(20)]
        public string Ma_SanPham { get; set; } = null!;

        public int So_Luong { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal DonGia { get; set; }

        [ForeignKey("Ma_DonHang")]
        public DonHang DonHang { get; set; } = null!;

        [ForeignKey("Ma_SanPham")]
        public SanPham SanPham { get; set; } = null!;
    }
}