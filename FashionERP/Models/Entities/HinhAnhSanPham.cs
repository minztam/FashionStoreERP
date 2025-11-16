using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FashionERP.Models.Entities
{
    public class HinhAnhSanPham
    {
        [Key]
        public int Ma_HinhAnh { get; set; }

        [Required, StringLength(20)]
        public string Ma_SanPham { get; set; } = null!;

        [Required, StringLength(255)]
        public string DuongDan { get; set; } = null!;

        [ForeignKey("Ma_SanPham")]
        public SanPham SanPham { get; set; } = null!;
    }
}