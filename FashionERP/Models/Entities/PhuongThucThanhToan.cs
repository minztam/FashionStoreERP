using System.ComponentModel.DataAnnotations;

namespace FashionERP.Models.Entities
{
    public class PhuongThucThanhToan
    {
        [Key]
        [StringLength(10)]
        public string Ma_PhuongThuc { get; set; } = null!;

        [Required, StringLength(100)]
        public string Ten_PhuongThuc { get; set; } = null!;

        public ICollection<DonHang> DonHangs { get; set; } = [];
    }
}
