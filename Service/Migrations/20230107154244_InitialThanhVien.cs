using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Service.Migrations
{
    public partial class InitialThanhVien : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "khuyenmai",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    LoaiHangID = table.Column<int>(type: "int", nullable: false),
                    NgayBatDau = table.Column<DateTime>(type: "date", nullable: false),
                    NgayKetThuc = table.Column<DateTime>(type: "date", nullable: false),
                    PhanTramGiam = table.Column<double>(type: "float", nullable: false),
                    QuaTangKem = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    VoucherTangKem = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_khuyenmai", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Loaihang",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    TenLoaiHang = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loaihang", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ThanhViens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoTen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GioiTinh = table.Column<bool>(type: "bit", nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DienThoai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MatKhau = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KichHoat = table.Column<bool>(type: "bit", nullable: false),
                    SocialLogin = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThanhViens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Thuonghieu",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Nuoc = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    TenThuongHieu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Thuonghieu", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    TenLot = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    SoDienThoai = table.Column<string>(type: "char(12)", unicode: false, fixedLength: true, maxLength: 12, nullable: false),
                    Email = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    Password = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    NgayTao = table.Column<DateTime>(type: "date", nullable: false),
                    ThongTin = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Diachi = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ThanhPho = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Donhang",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    TinhTrangDonHang = table.Column<short>(type: "smallint", nullable: false),
                    GiamGia = table.Column<double>(type: "float", nullable: false),
                    PhiShip = table.Column<double>(type: "float", nullable: false),
                    TongTien = table.Column<double>(type: "float", nullable: false),
                    MaGiamGia = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SoDienThoai = table.Column<string>(type: "char(12)", unicode: false, fixedLength: true, maxLength: 12, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    NgayTao = table.Column<DateTime>(type: "date", nullable: false),
                    NgayCapNhat = table.Column<DateTime>(type: "date", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donhang", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Donhang_users",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sanpham",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    ThuongHieuId = table.Column<int>(type: "int", nullable: false),
                    LoaiHangID = table.Column<int>(type: "int", nullable: false),
                    KhuyenMaiID = table.Column<int>(type: "int", nullable: true),
                    MaSanPham = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    TenSanPham = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    GiaSanPham = table.Column<int>(type: "int", nullable: false),
                    HinhSanPham = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    NgayTao = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "(getdate())"),
                    NgayCapNhat = table.Column<DateTime>(type: "date", nullable: false),
                    GiamGia = table.Column<double>(type: "float", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    ThongTin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThai = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    Gia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sanpham", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Sanpham_khuyenmai",
                        column: x => x.KhuyenMaiID,
                        principalTable: "khuyenmai",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sanpham_thuonghieu",
                        column: x => x.ThuongHieuId,
                        principalTable: "Thuonghieu",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sanpham_User",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Chitietdonhang",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    DonHangID = table.Column<int>(type: "int", nullable: false),
                    SanPhamID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    SoDienThoai = table.Column<string>(type: "char(12)", unicode: false, fixedLength: true, maxLength: 12, nullable: false),
                    TinhTrangDonHang = table.Column<short>(type: "smallint", nullable: false),
                    Diachi = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    PhiShip = table.Column<double>(type: "float", nullable: false),
                    KhuyenMaiID = table.Column<int>(type: "int", nullable: false),
                    TenNguoiNhan = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    TongTien = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chitietdonhang", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Chitietdonhang_donhang",
                        column: x => x.DonHangID,
                        principalTable: "Donhang",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Chitietdonhang_thuonghieu",
                        column: x => x.SanPhamID,
                        principalTable: "Sanpham",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Chucnang",
                columns: table => new
                {
                    SanPhamID = table.Column<int>(type: "int", nullable: false),
                    LoaiHangID = table.Column<int>(type: "int", nullable: true),
                    ThietKe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BoXuLy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManHinh = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Vga = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    BoNhoLuuTru = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    BaoMat = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GiaoTiepKetNoi = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Camera = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Amthanh = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    BaoHanhID = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Pin = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    HeDieuHanh = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Chucnang_Loaihang",
                        column: x => x.LoaiHangID,
                        principalTable: "Loaihang",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Chucnang_Sanpham",
                        column: x => x.SanPhamID,
                        principalTable: "Sanpham",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Hinh",
                columns: table => new
                {
                    HinhID = table.Column<int>(type: "int", nullable: false),
                    Thumbnails = table.Column<string>(type: "nchar(500)", fixedLength: true, maxLength: 500, nullable: false),
                    Carousel = table.Column<string>(type: "nchar(500)", fixedLength: true, maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hinh", x => x.HinhID);
                    table.ForeignKey(
                        name: "FK_Hinh_SP",
                        column: x => x.HinhID,
                        principalTable: "Sanpham",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chitietdonhang_DonHangID",
                table: "Chitietdonhang",
                column: "DonHangID");

            migrationBuilder.CreateIndex(
                name: "IX_Chitietdonhang_SanPhamID",
                table: "Chitietdonhang",
                column: "SanPhamID");

            migrationBuilder.CreateIndex(
                name: "IX_Chucnang_LoaiHangID",
                table: "Chucnang",
                column: "LoaiHangID");

            migrationBuilder.CreateIndex(
                name: "IX_Chucnang_SanPhamID",
                table: "Chucnang",
                column: "SanPhamID");

            migrationBuilder.CreateIndex(
                name: "IX_Donhang_UserID",
                table: "Donhang",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Sanpham_KhuyenMaiID",
                table: "Sanpham",
                column: "KhuyenMaiID");

            migrationBuilder.CreateIndex(
                name: "IX_Sanpham_ThuongHieuId",
                table: "Sanpham",
                column: "ThuongHieuId");

            migrationBuilder.CreateIndex(
                name: "IX_Sanpham_UserID",
                table: "Sanpham",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chitietdonhang");

            migrationBuilder.DropTable(
                name: "Chucnang");

            migrationBuilder.DropTable(
                name: "Hinh");

            migrationBuilder.DropTable(
                name: "ThanhViens");

            migrationBuilder.DropTable(
                name: "Donhang");

            migrationBuilder.DropTable(
                name: "Loaihang");

            migrationBuilder.DropTable(
                name: "Sanpham");

            migrationBuilder.DropTable(
                name: "khuyenmai");

            migrationBuilder.DropTable(
                name: "Thuonghieu");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
