using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FashionERP.Models.Entities
{
    public class GioHang
    {
        [Key]
        [StringLength(10)]
        public string Ma_GioHang { get; set; } = null!;

        [Required]
        [StringLength(10)]
        public string Ma_KhachHang { get; set; } = null!;

        [ForeignKey("Ma_KhachHang")]
        public KhachHang KhachHang { get; set; } = null!;

        public ICollection<ChiTietGioHang> ChiTietGioHangs { get; set; } = [];
    }
}