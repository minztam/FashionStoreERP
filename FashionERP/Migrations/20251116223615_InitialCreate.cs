using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FashionERP.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DanhMucs",
                columns: table => new
                {
                    Ma_DanhMuc = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Ten_DanhMuc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Ma_DanhMucCha = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Trang_Thai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhMucs", x => x.Ma_DanhMuc);
                    table.ForeignKey(
                        name: "FK_DanhMucs_DanhMucs_Ma_DanhMucCha",
                        column: x => x.Ma_DanhMucCha,
                        principalTable: "DanhMucs",
                        principalColumn: "Ma_DanhMuc");
                });

            migrationBuilder.CreateTable(
                name: "PhuongThucThanhToans",
                columns: table => new
                {
                    Ma_PhuongThuc = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Ten_PhuongThuc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhuongThucThanhToans", x => x.Ma_PhuongThuc);
                });

            migrationBuilder.CreateTable(
                name: "VaiTros",
                columns: table => new
                {
                    Ma_VaiTro = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Ten_VaiTro = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaiTros", x => x.Ma_VaiTro);
                });

            migrationBuilder.CreateTable(
                name: "Vouchers",
                columns: table => new
                {
                    Ma_Voucher = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Giam_PhanTram = table.Column<int>(type: "int", nullable: true),
                    Giam_Tien = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    GiaTri_ToiThieu = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    So_LanDung = table.Column<int>(type: "int", nullable: true),
                    Ngay_BatDau = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Ngay_KetThuc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Trang_Thai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vouchers", x => x.Ma_Voucher);
                });

            migrationBuilder.CreateTable(
                name: "SanPhams",
                columns: table => new
                {
                    Ma_SanPham = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Ma_DanhMuc = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Ten_SanPham = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Mo_Ta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gia = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Gia_Giam = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    So_Luong = table.Column<int>(type: "int", nullable: false),
                    Mau_Sac = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Kich_Thuoc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Trang_Thai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPhams", x => x.Ma_SanPham);
                    table.ForeignKey(
                        name: "FK_SanPhams_DanhMucs_Ma_DanhMuc",
                        column: x => x.Ma_DanhMuc,
                        principalTable: "DanhMucs",
                        principalColumn: "Ma_DanhMuc",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaiKhoans",
                columns: table => new
                {
                    Ma_TaiKhoan = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Ten_DangNhap = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mat_Khau = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Ma_VaiTro = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Trang_Thai = table.Column<bool>(type: "bit", nullable: false),
                    Ngay_Tao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Da_XacThuc = table.Column<bool>(type: "bit", nullable: false),
                    Ma_XacThuc = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Han_XacThuc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaiKhoans", x => x.Ma_TaiKhoan);
                    table.ForeignKey(
                        name: "FK_TaiKhoans_VaiTros_Ma_VaiTro",
                        column: x => x.Ma_VaiTro,
                        principalTable: "VaiTros",
                        principalColumn: "Ma_VaiTro",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HinhAnhSanPhams",
                columns: table => new
                {
                    Ma_HinhAnh = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ma_SanPham = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DuongDan = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HinhAnhSanPhams", x => x.Ma_HinhAnh);
                    table.ForeignKey(
                        name: "FK_HinhAnhSanPhams_SanPhams_Ma_SanPham",
                        column: x => x.Ma_SanPham,
                        principalTable: "SanPhams",
                        principalColumn: "Ma_SanPham",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KhachHangs",
                columns: table => new
                {
                    Ma_KhachHang = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Ma_TaiKhoan = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SoDienThoai = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Hinh_Anh = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHangs", x => x.Ma_KhachHang);
                    table.ForeignKey(
                        name: "FK_KhachHangs_TaiKhoans_Ma_TaiKhoan",
                        column: x => x.Ma_TaiKhoan,
                        principalTable: "TaiKhoans",
                        principalColumn: "Ma_TaiKhoan",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NhanViens",
                columns: table => new
                {
                    Ma_NhanVien = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Ma_TaiKhoan = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SoDienThoai = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Hinh_Anh = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanViens", x => x.Ma_NhanVien);
                    table.ForeignKey(
                        name: "FK_NhanViens_TaiKhoans_Ma_TaiKhoan",
                        column: x => x.Ma_TaiKhoan,
                        principalTable: "TaiKhoans",
                        principalColumn: "Ma_TaiKhoan",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DonHangs",
                columns: table => new
                {
                    Ma_DonHang = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Ma_KhachHang = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Ngay_Dat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tong_Tien = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Trang_Thai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Ma_PhuongThuc = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Ma_Voucher = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonHangs", x => x.Ma_DonHang);
                    table.ForeignKey(
                        name: "FK_DonHangs_KhachHangs_Ma_KhachHang",
                        column: x => x.Ma_KhachHang,
                        principalTable: "KhachHangs",
                        principalColumn: "Ma_KhachHang",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DonHangs_PhuongThucThanhToans_Ma_PhuongThuc",
                        column: x => x.Ma_PhuongThuc,
                        principalTable: "PhuongThucThanhToans",
                        principalColumn: "Ma_PhuongThuc",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DonHangs_Vouchers_Ma_Voucher",
                        column: x => x.Ma_Voucher,
                        principalTable: "Vouchers",
                        principalColumn: "Ma_Voucher");
                });

            migrationBuilder.CreateTable(
                name: "GioHangs",
                columns: table => new
                {
                    Ma_GioHang = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Ma_KhachHang = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GioHangs", x => x.Ma_GioHang);
                    table.ForeignKey(
                        name: "FK_GioHangs_KhachHangs_Ma_KhachHang",
                        column: x => x.Ma_KhachHang,
                        principalTable: "KhachHangs",
                        principalColumn: "Ma_KhachHang",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietDonHangs",
                columns: table => new
                {
                    Ma_DonHang = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Ma_SanPham = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    So_Luong = table.Column<int>(type: "int", nullable: false),
                    DonGia = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietDonHangs", x => new { x.Ma_DonHang, x.Ma_SanPham });
                    table.ForeignKey(
                        name: "FK_ChiTietDonHangs_DonHangs_Ma_DonHang",
                        column: x => x.Ma_DonHang,
                        principalTable: "DonHangs",
                        principalColumn: "Ma_DonHang",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietDonHangs_SanPhams_Ma_SanPham",
                        column: x => x.Ma_SanPham,
                        principalTable: "SanPhams",
                        principalColumn: "Ma_SanPham",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietGioHangs",
                columns: table => new
                {
                    Ma_GioHang = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Ma_SanPham = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    So_Luong = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietGioHangs", x => new { x.Ma_GioHang, x.Ma_SanPham });
                    table.ForeignKey(
                        name: "FK_ChiTietGioHangs_GioHangs_Ma_GioHang",
                        column: x => x.Ma_GioHang,
                        principalTable: "GioHangs",
                        principalColumn: "Ma_GioHang",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietGioHangs_SanPhams_Ma_SanPham",
                        column: x => x.Ma_SanPham,
                        principalTable: "SanPhams",
                        principalColumn: "Ma_SanPham",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DanhMucs",
                columns: new[] { "Ma_DanhMuc", "Ma_DanhMucCha", "Ten_DanhMuc", "Trang_Thai" },
                values: new object[,]
                {
                    { "NAM", null, "Thời trang nam", true },
                    { "NU", null, "Thời trang nữ", true },
                    { "PK", null, "Phụ kiện", true },
                    { "UNI", null, "Unisex", true }
                });

            migrationBuilder.InsertData(
                table: "PhuongThucThanhToans",
                columns: new[] { "Ma_PhuongThuc", "Ten_PhuongThuc" },
                values: new object[,]
                {
                    { "TT-CKNH", "Chuyển khoản ngân hàng" },
                    { "TT-KNH", "Thanh toán khi nhận hàng" },
                    { "TT-VDT", "Ví điện tử" }
                });

            migrationBuilder.InsertData(
                table: "DanhMucs",
                columns: new[] { "Ma_DanhMuc", "Ma_DanhMucCha", "Ten_DanhMuc", "Trang_Thai" },
                values: new object[,]
                {
                    { "NAM_AT", "NAM", "Áo thun nam", true },
                    { "NAM_QS", "NAM", "Quần short nam", true },
                    { "NAM_SM", "NAM", "Áo sơ mi nam", true },
                    { "NU_AT", "NU", "Áo thun nữ", true },
                    { "NU_DAM", "NU", "Đầm nữ", true },
                    { "NU_VAY", "NU", "Váy nữ", true },
                    { "PK_NON", "PK", "Nón", true },
                    { "PK_TUI", "PK", "Túi xách", true },
                    { "UNI_AT", "UNI", "Áo thun Unisex", true },
                    { "UNI_HOOD", "UNI", "Áo Hoodie Unisex", true }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietDonHangs_Ma_SanPham",
                table: "ChiTietDonHangs",
                column: "Ma_SanPham");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietGioHangs_Ma_SanPham",
                table: "ChiTietGioHangs",
                column: "Ma_SanPham");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucs_Ma_DanhMucCha",
                table: "DanhMucs",
                column: "Ma_DanhMucCha");

            migrationBuilder.CreateIndex(
                name: "IX_DonHangs_Ma_KhachHang",
                table: "DonHangs",
                column: "Ma_KhachHang");

            migrationBuilder.CreateIndex(
                name: "IX_DonHangs_Ma_PhuongThuc",
                table: "DonHangs",
                column: "Ma_PhuongThuc");

            migrationBuilder.CreateIndex(
                name: "IX_DonHangs_Ma_Voucher",
                table: "DonHangs",
                column: "Ma_Voucher");

            migrationBuilder.CreateIndex(
                name: "IX_GioHangs_Ma_KhachHang",
                table: "GioHangs",
                column: "Ma_KhachHang");

            migrationBuilder.CreateIndex(
                name: "IX_HinhAnhSanPhams_Ma_SanPham",
                table: "HinhAnhSanPhams",
                column: "Ma_SanPham");

            migrationBuilder.CreateIndex(
                name: "IX_KhachHangs_Ma_TaiKhoan",
                table: "KhachHangs",
                column: "Ma_TaiKhoan",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NhanViens_Ma_TaiKhoan",
                table: "NhanViens",
                column: "Ma_TaiKhoan",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SanPhams_Ma_DanhMuc",
                table: "SanPhams",
                column: "Ma_DanhMuc");

            migrationBuilder.CreateIndex(
                name: "IX_TaiKhoans_Ma_VaiTro",
                table: "TaiKhoans",
                column: "Ma_VaiTro");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietDonHangs");

            migrationBuilder.DropTable(
                name: "ChiTietGioHangs");

            migrationBuilder.DropTable(
                name: "HinhAnhSanPhams");

            migrationBuilder.DropTable(
                name: "NhanViens");

            migrationBuilder.DropTable(
                name: "DonHangs");

            migrationBuilder.DropTable(
                name: "GioHangs");

            migrationBuilder.DropTable(
                name: "SanPhams");

            migrationBuilder.DropTable(
                name: "PhuongThucThanhToans");

            migrationBuilder.DropTable(
                name: "Vouchers");

            migrationBuilder.DropTable(
                name: "KhachHangs");

            migrationBuilder.DropTable(
                name: "DanhMucs");

            migrationBuilder.DropTable(
                name: "TaiKhoans");

            migrationBuilder.DropTable(
                name: "VaiTros");
        }
    }
}
