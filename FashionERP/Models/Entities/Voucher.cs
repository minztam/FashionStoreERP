using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FashionERP.Models.Entities
{
    public class Voucher
    {
        [Key, StringLength(50)]
        public string Ma_Voucher { get; set; } = null!;

        public int? Giam_PhanTram { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? Giam_Tien { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? GiaTri_ToiThieu { get; set; }

        public int? So_LanDung { get; set; }
        public DateTime? Ngay_BatDau { get; set; }
        public DateTime? Ngay_KetThuc { get; set; }
        public bool Trang_Thai { get; set; } = true;

        public ICollection<DonHang> DonHangs { get; set; } = [];
    }
}
