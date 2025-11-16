using FashionERP.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace FashionERP.Data
{
    public class FashionStoreERPContext : DbContext
    {
        public FashionStoreERPContext(DbContextOptions<FashionStoreERPContext> options) : base(options) { }

        public DbSet<VaiTro> VaiTros => Set<VaiTro>();
        public DbSet<TaiKhoan> TaiKhoans => Set<TaiKhoan>();
        public DbSet<NhanVien> NhanViens => Set<NhanVien>();
        public DbSet<KhachHang> KhachHangs => Set<KhachHang>();
        public DbSet<DanhMuc> DanhMucs => Set<DanhMuc>();
        public DbSet<SanPham> SanPhams => Set<SanPham>();
        public DbSet<HinhAnhSanPham> HinhAnhSanPhams => Set<HinhAnhSanPham>();
        public DbSet<GioHang> GioHangs => Set<GioHang>();
        public DbSet<ChiTietGioHang> ChiTietGioHangs => Set<ChiTietGioHang>();
        public DbSet<PhuongThucThanhToan> PhuongThucThanhToans => Set<PhuongThucThanhToan>();
        public DbSet<Voucher> Vouchers => Set<Voucher>();
        public DbSet<DonHang> DonHangs => Set<DonHang>();
        public DbSet<ChiTietDonHang> ChiTietDonHangs => Set<ChiTietDonHang>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // === KHÓA PHỤ ===
            modelBuilder.Entity<ChiTietGioHang>()
                .HasKey(c => new { c.Ma_GioHang, c.Ma_SanPham });

            modelBuilder.Entity<ChiTietDonHang>()
                .HasKey(c => new { c.Ma_DonHang, c.Ma_SanPham });

            // === STRING KEYS ===
            modelBuilder.Entity<NhanVien>(entity =>
            {
                entity.HasKey(e => e.Ma_NhanVien);
                entity.Property(e => e.Ma_NhanVien).HasMaxLength(10);
            });
            modelBuilder.Entity<KhachHang>(entity =>
            {
                entity.HasKey(e => e.Ma_KhachHang);
                entity.Property(e => e.Ma_KhachHang).HasMaxLength(10);
            });
            modelBuilder.Entity<DonHang>(entity =>
            {
                entity.HasKey(e => e.Ma_DonHang);
                entity.Property(e => e.Ma_DonHang).HasMaxLength(20);
            });
            modelBuilder.Entity<SanPham>(entity =>
            {
                entity.HasKey(e => e.Ma_SanPham);
                entity.Property(e => e.Ma_SanPham).HasMaxLength(20);
            });
            modelBuilder.Entity<PhuongThucThanhToan>(entity =>
            {
                entity.HasKey(e => e.Ma_PhuongThuc);
                entity.Property(e => e.Ma_PhuongThuc).HasMaxLength(10);
            });
            modelBuilder.Entity<GioHang>(entity =>
            {
                entity.HasKey(g => g.Ma_GioHang);
                entity.Property(g => g.Ma_GioHang).HasMaxLength(10);
            });

            // === QUAN HỆ 1-N ===
            modelBuilder.Entity<GioHang>()
                .HasOne(g => g.KhachHang)
                .WithMany(kh => kh.GioHangs)
                .HasForeignKey(g => g.Ma_KhachHang)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ChiTietGioHang>()
                .HasOne(c => c.GioHang)
                .WithMany(g => g.ChiTietGioHangs)
                .HasForeignKey(c => c.Ma_GioHang)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<DonHang>()
                .HasOne(d => d.KhachHang)
                .WithMany(kh => kh.DonHangs)
                .HasForeignKey(d => d.Ma_KhachHang)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TaiKhoan>()
                .HasOne(t => t.VaiTro)
                .WithMany(v => v.TaiKhoans)
                .HasForeignKey(t => t.Ma_VaiTro)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SanPham>()
                .HasOne(s => s.DanhMuc)
                .WithMany(d => d.SanPhams)
                .HasForeignKey(s => s.Ma_DanhMuc);

            modelBuilder.Entity<DonHang>()
                .HasOne(d => d.PhuongThucThanhToan)
                .WithMany(p => p.DonHangs)
                .HasForeignKey(d => d.Ma_PhuongThuc)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DonHang>()
                .HasOne(d => d.KhachHang)
                .WithMany(kh => kh.DonHangs)
                .HasForeignKey(d => d.Ma_KhachHang)
                .OnDelete(DeleteBehavior.Restrict);

            // === DECIMAL (18,2) ===
            modelBuilder.Entity<SanPham>()
                .Property(s => s.Gia)
                .HasPrecision(18, 2);
            modelBuilder.Entity<SanPham>()
                .Property(s => s.Gia_Giam)
                .HasPrecision(18, 2);
            modelBuilder.Entity<DonHang>()
                .Property(d => d.Tong_Tien)
                .HasPrecision(18, 2);
            modelBuilder.Entity<ChiTietDonHang>()
                .Property(c => c.DonGia)
                .HasPrecision(18, 2);
            modelBuilder.Entity<Voucher>()
                .Property(v => v.Giam_Tien)
                .HasPrecision(18, 2);
            modelBuilder.Entity<Voucher>()
                .Property(v => v.GiaTri_ToiThieu)
                .HasPrecision(18, 2);

            modelBuilder.Entity<DanhMuc>().HasData(
                // Cấp 1
                new DanhMuc { Ma_DanhMuc = "NAM", Ten_DanhMuc = "Thời trang nam", Trang_Thai = true },
                new DanhMuc { Ma_DanhMuc = "NU", Ten_DanhMuc = "Thời trang nữ", Trang_Thai = true },
                new DanhMuc { Ma_DanhMuc = "UNI", Ten_DanhMuc = "Unisex", Trang_Thai = true },
                new DanhMuc { Ma_DanhMuc = "PK", Ten_DanhMuc = "Phụ kiện", Trang_Thai = true },
                // Cấp 2
                new DanhMuc { Ma_DanhMuc = "NAM_AT", Ten_DanhMuc = "Áo thun nam", Ma_DanhMucCha = "NAM", Trang_Thai = true },
                new DanhMuc { Ma_DanhMuc = "NAM_SM", Ten_DanhMuc = "Áo sơ mi nam", Ma_DanhMucCha = "NAM", Trang_Thai = true },
                new DanhMuc { Ma_DanhMuc = "NAM_QS", Ten_DanhMuc = "Quần short nam", Ma_DanhMucCha = "NAM", Trang_Thai = true },
                new DanhMuc { Ma_DanhMuc = "NU_VAY", Ten_DanhMuc = "Váy nữ", Ma_DanhMucCha = "NU", Trang_Thai = true },
                new DanhMuc { Ma_DanhMuc = "NU_DAM", Ten_DanhMuc = "Đầm nữ", Ma_DanhMucCha = "NU", Trang_Thai = true },
                new DanhMuc { Ma_DanhMuc = "NU_AT", Ten_DanhMuc = "Áo thun nữ", Ma_DanhMucCha = "NU", Trang_Thai = true },
                new DanhMuc { Ma_DanhMuc = "UNI_AT", Ten_DanhMuc = "Áo thun Unisex", Ma_DanhMucCha = "UNI", Trang_Thai = true },
                new DanhMuc { Ma_DanhMuc = "UNI_HOOD", Ten_DanhMuc = "Áo Hoodie Unisex", Ma_DanhMucCha = "UNI", Trang_Thai = true },
                new DanhMuc { Ma_DanhMuc = "PK_NON", Ten_DanhMuc = "Nón", Ma_DanhMucCha = "PK", Trang_Thai = true },
                new DanhMuc { Ma_DanhMuc = "PK_TUI", Ten_DanhMuc = "Túi xách", Ma_DanhMucCha = "PK", Trang_Thai = true }
            );

            modelBuilder.Entity<PhuongThucThanhToan>().HasData(
                new PhuongThucThanhToan { Ma_PhuongThuc = "TT-KNH", Ten_PhuongThuc = "Thanh toán khi nhận hàng" },
                new PhuongThucThanhToan { Ma_PhuongThuc = "TT-CKNH", Ten_PhuongThuc = "Chuyển khoản ngân hàng" },
                new PhuongThucThanhToan { Ma_PhuongThuc = "TT-VDT", Ten_PhuongThuc = "Ví điện tử" }
            );
        }
    }
}
