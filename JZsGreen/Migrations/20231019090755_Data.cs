using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JZsGreen.Migrations
{
    /// <inheritdoc />
    public partial class Data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(42)", maxLength: 42, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    fullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    dateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    point = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoryChildren",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    categoryId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryChildren", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoryChildren_Category_categoryId",
                        column: x => x.categoryId,
                        principalTable: "Category",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bill",
                columns: table => new
                {
                    billID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    fullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    address = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    payment = table.Column<int>(type: "int", nullable: true),
                    point = table.Column<int>(type: "int", nullable: true),
                    percentDiscount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    totalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bill", x => x.billID);
                    table.ForeignKey(
                        name: "FK_Bill_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    price = table.Column<double>(type: "float", nullable: false),
                    discount = table.Column<double>(type: "float", nullable: true),
                    unit = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    totalPrice = table.Column<double>(type: "float", nullable: true),
                    summary = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: true),
                    dateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    categoryId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_CategoryChildren_categoryId",
                        column: x => x.categoryId,
                        principalTable: "CategoryChildren",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DetailOrder",
                columns: table => new
                {
                    odID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    billID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    quantity = table.Column<int>(type: "int", nullable: true),
                    productId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailOrder", x => x.odID);
                    table.ForeignKey(
                        name: "FK_DetailOrder_Bill_billID",
                        column: x => x.billID,
                        principalTable: "Bill",
                        principalColumn: "billID");
                    table.ForeignKey(
                        name: "FK_DetailOrder_Product_productId",
                        column: x => x.productId,
                        principalTable: "Product",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductImage",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    fileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    productId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImage", x => x.id);
                    table.ForeignKey(
                        name: "FK_ProductImage_Product_productId",
                        column: x => x.productId,
                        principalTable: "Product",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "name" },
                values: new object[,]
                {
                    { "giavi-botnem", "Dầu Ăn Gia Vị" },
                    { "rau-cu-nam-traicay-cac-loai", "Rau, Củ, Nấm, Trái Cây" }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "07bf1560-b5ff-4702-a9f1-a64026e570cf", null, "Admin", "Admin" },
                    { "2ccdcef3-db18-46c7-b5ff-910be6ae4906", null, "Customer", "Customer" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "dateCreated", "fullName", "point" },
                values: new object[,]
                {
                    { "a5932398b5-d34640-9847ffbc3354521251", 0, "68b89bb4-8f35-48a4-9a31-9c5eaac5530b", "customer@gmail.com", true, false, null, "CUSTOMER@GMAIL.COM", "A@CUSTOMER.COM", "AQAAAAIAAYagAAAAEIHVhfaY2E+yDFFMDHglta7si0ZlGAUtoi+s8OWKc1TrTBi2QPXeOkxIVa9VWacWiA==", "0582072742", false, "6a6fef96-b59d-4c87-b8c1-0984fda765d9", false, "customer@gmail.com", new DateTime(2023, 10, 19, 16, 7, 55, 393, DateTimeKind.Local).AddTicks(150), "Nguyễn Văn A", 0 },
                    { "a79e98b4-d8a6-4640-98eb-5b417ffb2661", 0, "8ceec679-0c7b-4128-9088-beda93e7d623", "admin@gmail.com", true, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAENJW8q1aCpSpx3JAi13xmJJSoE4RF4aWNIuFGQlV/mH6eqogS4h1oSxkYMa+U+RM8g==", "0582072743", false, "6d7c20b1-2039-4777-997b-dfacaf18d1e9", false, "admin@gmail.com", new DateTime(2023, 10, 19, 16, 7, 55, 309, DateTimeKind.Local).AddTicks(3167), "Trần Viễn Đại", 0 }
                });

            migrationBuilder.InsertData(
                table: "CategoryChildren",
                columns: new[] { "Id", "categoryId", "name" },
                values: new object[,]
                {
                    { "Củ, Quả", "rau-cu-nam-traicay-cac-loai", "Củ, Quả" },
                    { "Dầu Ăn", "giavi-botnem", "Dầu Ăn" },
                    { "Gia Vị", "giavi-botnem", "Gia Vị" },
                    { "Nấm", "rau-cu-nam-traicay-cac-loai", "Nấm" },
                    { "Rau Lá", "rau-cu-nam-traicay-cac-loai", "Rau lá" },
                    { "Trái Cây", "rau-cu-nam-traicay-cac-loai", "Trái Cây" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "2ccdcef3-db18-46c7-b5ff-910be6ae4906", "a5932398b5-d34640-9847ffbc3354521251" },
                    { "07bf1560-b5ff-4702-a9f1-a64026e570cf", "a79e98b4-d8a6-4640-98eb-5b417ffb2661" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "categoryId", "dateCreated", "description", "discount", "isActive", "name", "price", "quantity", "summary", "totalPrice", "unit" },
                values: new object[,]
                {
                    { "JZENO", "Rau Lá", new DateTime(2023, 10, 19, 16, 7, 55, 393, DateTimeKind.Local).AddTicks(773), "<p><strong>Cải bẹ d&uacute;n</strong> được nu&ocirc;i trồng v&agrave; đ&oacute;ng g&oacute;i theo những ti&ecirc;u chuẩn nghi&ecirc;m ngặt, bảo đảm c&aacute;c ti&ecirc;u chuẩn xanh - sạch, chất lượng v&agrave; an to&agrave;n với người d&ugrave;ng. Rau tươi, gi&ograve;n v&agrave; ngọt thường được sử dụng l&agrave;m rau ăn k&egrave;m với c&aacute;c m&oacute;n cuốn hoặc trộn như b&uacute;n trộn, b&aacute;nh x&egrave;o,...</p>\r\n<p><strong>Cải bẹ d&uacute;n</strong> l&agrave; lo&agrave;i thực vật họ cải, c&ograve;n được gọi l&agrave; cải d&uacute;n, cải nh&uacute;n, cải bẹ nh&uacute;ng. Loại rau n&agrave;y chứa nhiều th&agrave;nh phần dinh dưỡng c&oacute; lợi cho sức khỏe như vitamin C, mềm ngọt m&aacute;t v&agrave; nhiều nguy&ecirc;n tố vi lượng, c&oacute; t&aacute;c dụng l&agrave;m m&aacute;t gan, thanh lọc, giải nhiệt cơ thể, giảm c&acirc;n, ngừa giảm tr&iacute; nhớ, trẻ h&oacute;a l&agrave;n da,...</p>\r\n<p><strong>Cải bẹ d&uacute;n</strong> thơm ngon, dễ ăn, th&iacute;ch hợp với khẩu vị của cả nh&agrave;.</p>", 0.0, true, "Cải Bẹ Dún", 9000.0, 100, "450-500g", 9000.0, "kg" },
                    { "JZENO1", "Rau Lá", new DateTime(2023, 10, 19, 16, 7, 55, 393, DateTimeKind.Local).AddTicks(781), "<p>Xà lách xanh được nuôi trồng và đóng gói theo những tiêu chuẩn nghiêm ngặt, bảo đảm các tiêu chuẩn xanh - sạch, chất lượng và an toàn với người dùng. Chứa nhiều chất xơ, hàm lượng dinh dưỡng cao, vị ngọt, giòn nên thường dùng làm rau ăn kèm cho các món cuốn như bánh xèo.</p>", 0.0, true, "Xà Lách", 14000.0, 100, "300g", 14000.0, "kg" },
                    { "JZENO10", "Nấm", new DateTime(2023, 10, 19, 16, 7, 55, 397, DateTimeKind.Local).AddTicks(2847), "Nấm kim châm Thái Lan tươi ngon, được đóng gói cẩn thận, chất lượng và an toàn với người dùng. Sợi nấm dai, giòn và ngọt, khi nấu chín rất thơm nên thường được lăn bột chiên giòn, nấu súp hoặc để nướng ăn kèm.", 0.0, false, "Nấm Kim Châm Thái Lan", 11000.0, 0, "2kg trở lên", 42000.0, "kg" },
                    { "JZENO11", "Dầu Ăn", new DateTime(2023, 10, 19, 16, 7, 55, 397, DateTimeKind.Local).AddTicks(2851), "<p><strong>Dầu ăn cao cấp Happy Koki</strong> chai 1 l&iacute;t l&agrave; sản phẩm dầu ăn c&oacute; nguồn gốc 100% từ thực vật th&iacute;ch hợp chế biến thực phẩm từ chi&ecirc;n, x&agrave;o, ướp c&aacute;c m&oacute;n mặn cho đến m&oacute;n chay.</p>\r\n<p><strong>Dầu ăn Happi Koki</strong> kh&ocirc;ng chứa cholesterol, kh&ocirc;ng axit b&eacute;o cấu h&igrave;nh Trans, gi&agrave;u vitamin A, E v&agrave; Omega 3, 6, 9, an to&agrave;n cho sức khỏe.</p>", 15.0, true, "Dầu Ăn Cao Cấp Happi KoKi", 45000.0, 17, "chai 1 lít", 37350.0, "chai" },
                    { "JZENO12", "Dầu Ăn", new DateTime(2023, 10, 19, 16, 7, 55, 397, DateTimeKind.Local).AddTicks(2870), "Dầu ăn cao cấp Happy Koki chai 5 lít là sản phẩm dầu ăn có nguồn gốc 100% từ thực vật thích hợp chế biến thực phẩm từ chiên, xào, ướp các món mặn cho đến món chay. Dầu ăn Happi Koki không chứa cholesterol, không axit béo cấu hình Trans, giàu vitamin A, E và Omega 3, 6, 9, an toàn cho sức khỏe.", 15.0, true, "Dầu Ăn Cao Cấp Happi KoKi", 205000.0, 8, "chai 5 lít", 184500.0, "chai" },
                    { "JZENO13", "Gia Vị", new DateTime(2023, 10, 19, 16, 7, 55, 397, DateTimeKind.Local).AddTicks(2879), "Sản phẩm được làm từ nước dùng của xương và thịt heo cùng với một lượng cân đối các loại gia vị khác. Hạt nêm vị heo Aji-ngon 400g là đến từ loại hạt nêm mang lại hương vị thơm ngon tự nhiên cho món ăn của gia đình bạn. Hạt nêm Aji-ngon gói nhỏ phù hợp nhu cầu sử dụng gia đình và dễ mang đi.", 5.0, true, "Hạt Nêm Aji-ngon Vị Heo", 33000.0, 20, "400g/gói", 31350.0, "gói" },
                    { "JZENO14", "Gia Vị", new DateTime(2023, 10, 19, 16, 7, 55, 397, DateTimeKind.Local).AddTicks(2883), "<p>Sản phẩm được l&agrave;m từ nước d&ugrave;ng của nấm c&ugrave;ng với một lượng c&acirc;n đối c&aacute;c loại gia vị kh&aacute;c.</p>\r\n<p>Hạt n&ecirc;m vị heo Aji-ngon 400g l&agrave; đến từ loại hạt n&ecirc;m mang lại hương vị thơm ngon tự nhi&ecirc;n cho m&oacute;n ăn của gia đ&igrave;nh bạn. Hạt n&ecirc;m Aji-ngon g&oacute;i nhỏ ph&ugrave; hợp nhu cầu sử dụng gia đ&igrave;nh v&agrave; dễ mang đi.</p>", 5.0, true, "Hạt Nêm Aji-ngon Vị Nấm", 33000.0, 20, "400g/gói", 31350.0, "gói" },
                    { "JZENO2", "Rau Lá", new DateTime(2023, 10, 19, 16, 7, 55, 393, DateTimeKind.Local).AddTicks(786), "<p><strong>Cải th&igrave;a </strong>được nu&ocirc;i trồng v&agrave; đ&oacute;ng g&oacute;i theo những ti&ecirc;u chuẩn nghi&ecirc;m ngặt, bảo đảm c&aacute;c ti&ecirc;u chuẩn xanh - sach, chất lượng v&agrave; an to&agrave;n với người d&ugrave;ng. Vị cải gi&ograve;n, ngọt, m&aacute;t v&agrave; chứa nhiều chất xơ, h&agrave;m lượng dinh dưỡng cao n&ecirc;n thường được d&ugrave;ng để chế biến c&aacute;c m&oacute;n rau x&agrave;o hoặc luộc.</p>\r\n<p><strong>C&aacute;ch sơ chế cải th&igrave;a</strong> Cải mua về, t&aacute;ch rời từng l&aacute;. Rửa với nước sạch nhiều lần cho hết c&aacute;t. Ng&acirc;m nước muối lo&atilde;ng khoảng 30 ph&uacute;t. Sau đ&oacute; cắt kh&uacute;c 2 - 3cm vừa ăn. Chế biến ph&ugrave; hợp theo m&oacute;n ăn. M&oacute;n ăn dinh dưỡng, thanh m&aacute;t với cải th&igrave;a Cải th&igrave;a x&agrave;o dầu h&agrave;o. Gi&ograve;n ngon với cải th&igrave;a x&agrave;o nấm đ&ocirc;ng c&ocirc;. G&agrave; hấp cải th&igrave;a nấm đ&ocirc;ng c&ocirc;. Canh t&ocirc;m cải th&igrave;a thanh m&aacute;t cơ thể.</p>\r\n<p><strong>-&gt; Lưu &yacute;: </strong>Sản phẩm nhận được c&oacute; thể kh&aacute;c với h&igrave;nh ảnh về m&agrave;u sắc v&agrave; số lượng nhưng vẫn đảm bảo về mặt khối lượng v&agrave; chất lượng.</p>", 0.0, true, "Cải Thìa", 15000.0, 100, "450-500g", 9000.0, "kg" },
                    { "JZENO3", "Rau Lá", new DateTime(2023, 10, 19, 16, 7, 55, 397, DateTimeKind.Local).AddTicks(2779), "<p><strong>Cải bẹ xanh</strong>&nbsp;được nu&ocirc;i trồng v&agrave; đ&oacute;ng g&oacute;i theo những ti&ecirc;u chuẩn nghi&ecirc;m ngặt, bảo đảm c&aacute;c ti&ecirc;u chuẩn xanh - sach, chất lượng v&agrave; an to&agrave;n với người d&ugrave;ng. Với bẹ l&aacute; to, vị hơi đắng nhẹ, m&aacute;t v&agrave; thơm n&ecirc;n thường được d&ugrave;ng để nấu canh hoặc rau cuốn ăn k&egrave;m với b&aacute;nh x&egrave;o, gỏi cuốn.</p>\r\n<p><strong>Ngo&agrave;i t&aacute;c dụng chế biến m&oacute;n ăn:</strong>&nbsp;cải xanh c&ograve;n c&oacute; c&aacute;c t&aacute;c dụng chữa bệnh tuyệt vời, ăn nhiều cải xanh bổ sung vitamin K rất cần thiết cho cơ thể, gi&uacute;p tăng cường hệ miễn dịch, bảo vệ sức khỏe tim mạch v&agrave; c&oacute; thể ngăn ngừa c&aacute;c biểu hiện ung thư, ăn cải xanh nhiều c&ograve;n gi&uacute;p mắt s&aacute;ng khỏe, gi&uacute;p da ngăn ngừa l&atilde;o h&oacute;a, chắc khỏe hỗ trợ chị em phụ nữ trong việc chăm s&oacute;c sắc đẹp. Sơ chế cải bẹ xanh Cải sau khi mua về cần được lặt theo từng l&aacute;, rửa sạch lần đầu bằng nước muối để loại bỏ bụi bẩn cũng như lớp h&oacute;a chất hay chất bảo quản c&oacute; thể c&ograve;n lại tr&ecirc;n bề mặt l&aacute;. Sau đ&oacute; cần lược lại bằng nước thường th&ecirc;m một lần nữa mới đem cắt nhỏ rau t&ugrave;y theo m&oacute;n ăn sắp chế biến.</p>\r\n<p><strong>C&aacute;c m&oacute;n ngon chế biến từ cải bẹ xanh:</strong> Canh h&agrave;u cải bẹ xanh Canh cải bẹ xanh nấu ngh&ecirc;u Canh cải bẹ xanh nấu gừng Ch&aacute;o lươn cải bẹ xanh Ch&aacute;o c&aacute; r&ocirc; cải xanh Cải bẹ xanh c&ugrave;ng c&aacute;c loại rau kh&aacute;c như: rau cần, rau muống, bắp cải thảo, t&iacute;a t&ocirc;, hoa chuối, mồng tơi, x&agrave; l&aacute;ch, cải xoong, cải ngọt,... chụng nấu lẩu Th&aacute;i cũng rất hợp v&agrave; ngon.</p>\r\n<p><strong>-&gt; Lưu &yacute;</strong>: Sản phẩm nhận được c&oacute; thể kh&aacute;c với h&igrave;nh ảnh về m&agrave;u sắc v&agrave; số lượng nhưng vẫn đảm bảo về mặt khối lượng v&agrave; chất lượng.</p>", 0.0, true, "Bẹ Xanh", 10000.0, 100, "450-500g", 10000.0, "kg" },
                    { "JZENO4", "Củ, Quả", new DateTime(2023, 10, 19, 16, 7, 55, 397, DateTimeKind.Local).AddTicks(2819), "Chưa Cập Nhật", 0.0, true, "Khổ Qua", 22500.0, 100, "3-5 trái (500g)", 22500.0, "kg" },
                    { "JZENO5", "Củ, Quả", new DateTime(2023, 10, 19, 16, 7, 55, 397, DateTimeKind.Local).AddTicks(2824), "Bí đỏ hồ lô hay bí đỏ hạt đậu, đây là giống bí có ruột rất đặc, ít hả ăn dẻo và ngọt. Bí hồ lô chứa nhiều chất dinh dưỡng và mang lại nhiều lợi ích cho sức khoẻ. Bí hồ lô có thể chế biến thành nhiều món ăn ngon như: sữa bí, canh bí, súp bí,... món nào cũng đều thơm ngon.", 0.0, true, "Bí Hồ Lô", 13300.0, 100, "700-900g", 13300.0, "kg" },
                    { "JZENO6", "Củ, Quả", new DateTime(2023, 10, 19, 16, 7, 55, 397, DateTimeKind.Local).AddTicks(2829), "<p><strong>Khoai mỡ</strong> l&agrave; loại củ kh&aacute; được ưa chuộng trong những bữa ăn gia đ&igrave;nh.</p>\r\n<p><strong>Khoai mỡ</strong> c&oacute; h&agrave;m lượng kho&aacute;ng chất v&agrave; vitamin gi&uacute;p cải thiện hệ ti&ecirc;u ho&aacute;, gi&uacute;p nhuận tr&agrave;ng, chữa t&aacute;o b&oacute;n rất tốt. Khoai mỡ c&oacute; thể sử dụng để chế biến th&agrave;nh c&aacute;c m&oacute;n như: canh, b&aacute;nh khoai mỡ, khoai mỡ chi&ecirc;n gi&ograve;n,...</p>\r\n<p><strong>C&aacute;ch bảo quản khoai mỡ tươi ngon:</strong> Khoai mỡ c&oacute; thể được bảo quản trong điều kiện thường, để nơi kh&ocirc; r&aacute;o, tho&aacute;ng m&aacute;t. Hoặc quấn giấy, m&agrave;ng bọc v&agrave; bảo quản trong ngăn m&aacute;t tủ lạnh.</p>\r\n<p><strong>-&gt; Lưu &yacute;:</strong> Sản phẩm nhận được c&oacute; thể kh&aacute;c với h&igrave;nh ảnh về m&agrave;u sắc v&agrave; số lượng nhưng vẫn đảm bảo về mặt khối lượng v&agrave; chất lượng.</p>", 50.0, true, "Khoai Mỡ", 33000.0, 100, "900g-1.1kg (1-2 củ)", 16500.0, "kg" },
                    { "JZENO7", "Trái Cây", new DateTime(2023, 10, 19, 16, 7, 55, 397, DateTimeKind.Local).AddTicks(2833), "Chuối già là giống chuối chứa nhiều chất dinh dưỡng như kali, chất xơ, vitamin,... đem lại nhiều lợi ích cho sức khỏe như hỗ trợ giảm cân, hỗ trợ sức khoẻ tim mạch, cải thiện sức khoẻ của thận,... Trái cây tại Bách hóa XANH được đảm bảo chất lượng, cam kết đúng khối lượng.", 20.0, true, "Chuối Nam Mỹ", 26000.0, 100, "1 nải", 20800.0, "kg" },
                    { "JZENO8", "Trái Cây", new DateTime(2023, 10, 19, 16, 7, 55, 397, DateTimeKind.Local).AddTicks(2837), "<p>Táo nhập khẩu 100% từ New Zealand.&nbsp;Đạt tiêu chuẩn xuất khẩu toàn cầu.&nbsp;Bảo quản tươi ngon đến tận tay khách hàng.&nbsp;Trái vừa ăn, chắc tay, vỏ táo màu hồng xanh đẹp mắt.&nbsp;<strong>Táo ngon nhất khi có lớp vỏ màu đỏ đậm, táo còn cứng, không bị dập.</strong></p>", 10.0, true, "Táo Pink Lady", 69000.0, 100, "5-7 trái (1kg)", 62100.0, "kg" },
                    { "JZENO9", "Trái Cây", new DateTime(2023, 10, 19, 16, 7, 55, 397, DateTimeKind.Local).AddTicks(2843), "Dưa hấu không hạt là trái cây nhiều nước và các vitamin, khoáng chất cần thiết, đặc biệt là ít calo và chất béo. Dưa hấu được xem là một sản phẩm thay thế cho nước uống thông thường. Giúp giải khát thanh nhiệt mà còn bổ sung nhiều chất dinh dưỡng cho cơ thể, giúp bạn tràn đầy năng lượng.\n", 0.0, true, "Dưa Hấu Không Hạt", 42000.0, 100, "2kg trở lên", 42000.0, "kg" }
                });

            migrationBuilder.InsertData(
                table: "ProductImage",
                columns: new[] { "id", "fileName", "productId" },
                values: new object[,]
                {
                    { "images01", "bedun.jpg", "JZENO" },
                    { "images02", "bedun01.jpg", "JZENO" },
                    { "images03", "xalach.png", "JZENO1" },
                    { "images04", "xalach01.jpg", "JZENO1" },
                    { "images05", "caithia.jpg", "JZENO2" },
                    { "images06", "caithia01.png", "JZENO2" },
                    { "images07", "bexanh.jpg", "JZENO3" },
                    { "images08", "bexanh01.png", "JZENO3" },
                    { "images09", "khoqua.jpg", "JZENO4" },
                    { "images10", "khoqua01.jpg", "JZENO4" },
                    { "images11", "biholo.jpg", "JZENO5" },
                    { "images12", "khoaimo.jpg", "JZENO6" },
                    { "images13", "chuoi.png", "JZENO7" },
                    { "images14", "chuoi01.jpg", "JZENO7" },
                    { "images15", "taopinklady.jpg", "JZENO8" },
                    { "images16", "duahau.jpg", "JZENO9" },
                    { "images17", "duahau01.jpg", "JZENO9" },
                    { "images18", "namkimcham.jpg", "JZENO10" },
                    { "images19", "dauan.jpg", "JZENO11" },
                    { "images20", "dauan01.jpg", "JZENO12" },
                    { "images21", "botnem.jpg", "JZENO13" },
                    { "images22", "botnem01.jpg", "JZENO14" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bill_UserId",
                table: "Bill",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryChildren_categoryId",
                table: "CategoryChildren",
                column: "categoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryChildren_name",
                table: "CategoryChildren",
                column: "name",
                unique: true,
                filter: "[name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DetailOrder_billID",
                table: "DetailOrder",
                column: "billID");

            migrationBuilder.CreateIndex(
                name: "IX_DetailOrder_productId",
                table: "DetailOrder",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_categoryId",
                table: "Product",
                column: "categoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImage_productId",
                table: "ProductImage",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Role",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "User",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_User_PhoneNumber",
                table: "User",
                column: "PhoneNumber",
                unique: true,
                filter: "[PhoneNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "User",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetailOrder");

            migrationBuilder.DropTable(
                name: "ProductImage");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "Bill");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "CategoryChildren");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
