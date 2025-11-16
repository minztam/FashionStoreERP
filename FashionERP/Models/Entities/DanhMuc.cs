using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FashionERP.Models.Entities
{
    public class DanhMuc
    {
        [Key, StringLength(20)]
        public string Ma_DanhMuc { get; set; } = null!;

        [Required, StringLength(100)]
        public string Ten_DanhMuc { get; set; } = null!;

        [StringLength(20)]
        public string? Ma_DanhMucCha { get; set; }

        public bool Trang_Thai { get; set; } = true;

        [ForeignKey("Ma_DanhMucCha")]
        public DanhMuc? DanhMucCha { get; set; }

        public ICollection<DanhMuc> DanhMucCon { get; set; } = [];
        public ICollection<SanPham> SanPhams { get; set; } = [];
    }
}
