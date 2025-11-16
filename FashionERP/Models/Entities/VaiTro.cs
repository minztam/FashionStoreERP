using System.ComponentModel.DataAnnotations;

namespace FashionERP.Models.Entities
{
    public class VaiTro
    {
        [Key, StringLength(50)]
        public string Ma_VaiTro { get; set; } = null!;

        [Required, StringLength(50)]
        public string Ten_VaiTro { get; set; } = null!;

        public ICollection<TaiKhoan> TaiKhoans { get; set; } = [];
    }
}
