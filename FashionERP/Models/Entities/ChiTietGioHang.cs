using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FashionERP.Models.Entities
{
    public class ChiTietGioHang
    {
        [Required]
        [StringLength(10)]
        public string Ma_GioHang { get; set; } = null!;

        [Required, StringLength(20)]
        public string Ma_SanPham { get; set; } = null!;

        public int So_Luong { get; set; }

        [ForeignKey("Ma_GioHang")]
        public GioHang GioHang { get; set; } = null!;

        [ForeignKey("Ma_SanPham")]
        public SanPham SanPham { get; set; } = null!;
    }
}