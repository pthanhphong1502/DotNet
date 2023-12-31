using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JZsGreen.Migrations
{
    /// <inheritdoc />
    public partial class InitDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: "JZENO",
                column: "dateCreated",
                value: new DateTime(2023, 11, 18, 10, 15, 17, 612, DateTimeKind.Local).AddTicks(5898));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: "JZENO1",
                column: "dateCreated",
                value: new DateTime(2023, 11, 18, 10, 15, 17, 612, DateTimeKind.Local).AddTicks(5909));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: "JZENO10",
                column: "dateCreated",
                value: new DateTime(2023, 11, 18, 10, 15, 17, 612, DateTimeKind.Local).AddTicks(5972));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: "JZENO11",
                column: "dateCreated",
                value: new DateTime(2023, 11, 18, 10, 15, 17, 612, DateTimeKind.Local).AddTicks(5977));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: "JZENO12",
                column: "dateCreated",
                value: new DateTime(2023, 11, 18, 10, 15, 17, 612, DateTimeKind.Local).AddTicks(5981));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: "JZENO13",
                column: "dateCreated",
                value: new DateTime(2023, 11, 18, 10, 15, 17, 612, DateTimeKind.Local).AddTicks(5985));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: "JZENO14",
                column: "dateCreated",
                value: new DateTime(2023, 11, 18, 10, 15, 17, 612, DateTimeKind.Local).AddTicks(5989));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: "JZENO2",
                column: "dateCreated",
                value: new DateTime(2023, 11, 18, 10, 15, 17, 612, DateTimeKind.Local).AddTicks(5915));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: "JZENO3",
                column: "dateCreated",
                value: new DateTime(2023, 11, 18, 10, 15, 17, 612, DateTimeKind.Local).AddTicks(5919));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: "JZENO4",
                columns: new[] { "dateCreated", "description" },
                values: new object[] { new DateTime(2023, 11, 18, 10, 15, 17, 612, DateTimeKind.Local).AddTicks(5924), "Chưa Cập Nhật" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: "JZENO5",
                column: "dateCreated",
                value: new DateTime(2023, 11, 18, 10, 15, 17, 612, DateTimeKind.Local).AddTicks(5928));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: "JZENO6",
                column: "dateCreated",
                value: new DateTime(2023, 11, 18, 10, 15, 17, 612, DateTimeKind.Local).AddTicks(5933));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: "JZENO7",
                column: "dateCreated",
                value: new DateTime(2023, 11, 18, 10, 15, 17, 612, DateTimeKind.Local).AddTicks(5951));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: "JZENO8",
                column: "dateCreated",
                value: new DateTime(2023, 11, 18, 10, 15, 17, 612, DateTimeKind.Local).AddTicks(5956));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: "JZENO9",
                column: "dateCreated",
                value: new DateTime(2023, 11, 18, 10, 15, 17, 612, DateTimeKind.Local).AddTicks(5968));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "a5932398b5-d34640-9847ffbc3354521251",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp", "dateCreated" },
                values: new object[] { "a2b0981d-b62c-44fb-83d5-dd7815f0f420", "CUSTOMER@GMAIL.COM", "AQAAAAIAAYagAAAAECWHltZOez573wpfT4Xdu+xAlLEALCvw6Oz1X4fr48KEeG11OipmwpFtjtpLOewZjA==", "23cd7021-11ef-43a9-953a-16456327f2b6", new DateTime(2023, 11, 18, 10, 15, 17, 612, DateTimeKind.Local).AddTicks(5164) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "a79e98b4-d8a6-4640-98eb-5b417ffb2661",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "dateCreated" },
                values: new object[] { "84e5be6d-4848-485a-9152-311228f47f8a", "AQAAAAIAAYagAAAAEEd4DdXcoqBkyWoGz1UcYzbgoL3EKqFlyb5ypBBq6zwPfP8QSiBu8s9FCMYZJSrBXA==", "35342d57-c7df-42af-9fe5-f3dd31bf1302", new DateTime(2023, 11, 18, 10, 15, 17, 489, DateTimeKind.Local).AddTicks(4142) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: "JZENO",
                column: "dateCreated",
                value: new DateTime(2023, 10, 19, 16, 7, 55, 393, DateTimeKind.Local).AddTicks(773));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: "JZENO1",
                column: "dateCreated",
                value: new DateTime(2023, 10, 19, 16, 7, 55, 393, DateTimeKind.Local).AddTicks(781));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: "JZENO10",
                column: "dateCreated",
                value: new DateTime(2023, 10, 19, 16, 7, 55, 397, DateTimeKind.Local).AddTicks(2847));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: "JZENO11",
                column: "dateCreated",
                value: new DateTime(2023, 10, 19, 16, 7, 55, 397, DateTimeKind.Local).AddTicks(2851));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: "JZENO12",
                column: "dateCreated",
                value: new DateTime(2023, 10, 19, 16, 7, 55, 397, DateTimeKind.Local).AddTicks(2870));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: "JZENO13",
                column: "dateCreated",
                value: new DateTime(2023, 10, 19, 16, 7, 55, 397, DateTimeKind.Local).AddTicks(2879));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: "JZENO14",
                column: "dateCreated",
                value: new DateTime(2023, 10, 19, 16, 7, 55, 397, DateTimeKind.Local).AddTicks(2883));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: "JZENO2",
                column: "dateCreated",
                value: new DateTime(2023, 10, 19, 16, 7, 55, 393, DateTimeKind.Local).AddTicks(786));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: "JZENO3",
                column: "dateCreated",
                value: new DateTime(2023, 10, 19, 16, 7, 55, 397, DateTimeKind.Local).AddTicks(2779));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: "JZENO4",
                columns: new[] { "dateCreated", "description" },
                values: new object[] { new DateTime(2023, 10, 19, 16, 7, 55, 397, DateTimeKind.Local).AddTicks(2819), "<div class=\"pb-[12px] text-[#222b45] h-[260px] overflow-hidden\">\r\n<div class=\"text-14 leading-5\"><span style=\"text-decoration: underline;\"><strong>Khổ Qua</strong></span> hay mướp đắng l&agrave; thực phẩm quen thuộc trong thực đơn h&agrave;ng tuần của c&aacute;c b&agrave; nội trợ. Trong khổ qua chứa rất nhiều vitamin v&agrave; kho&aacute;ng chất tốt cho cơ thể, gi&uacute;p n&acirc;ng cao chức năng miễn dịch, thanh nhiệt giải độc. Khổ qua c&oacute; thể chế biến th&agrave;nh canh hoặc c&aacute;c m&oacute;n x&agrave;o đều rất ngon.</div>\r\n<div class=\"text-14 leading-5\">\r\n<ul>\r\n<li>\r\n<h3><strong>Ưu Điểm</strong></h3>\r\n<ul>\r\n<li>Khổ qua tươi ngon, căng mọng, c&oacute; m&agrave;u xanh. Khổ qua c&oacute;&nbsp;<strong>vị đắng, t&iacute;nh h&agrave;n</strong>, kh&ocirc;ng bị hư, dập hay gi&agrave; qu&aacute;.</li>\r\n<li>Khổ qua được đảm bảo nguồn gốc xuất xứ r&otilde; r&agrave;ng,&nbsp;<strong>500g c&oacute; từ 3-5 tr&aacute;i.</strong></li>\r\n<li>Đặt giao h&agrave;ng nhanh</li>\r\n</ul>\r\n</li>\r\n</ul>\r\n<ul>\r\n<li>\r\n<h3><strong>Gi&aacute; trị dinh dưỡng của khổ qua</strong></h3>\r\n<ul>\r\n<li>Khổ qua c&oacute; chứa nhiều vitamin A, vitamin C, c&aacute;c kho&aacute;ng chất như kali, canxi, phốt pho, kẽm, đồng, sắt,...</li>\r\n<li>Trong 100g khổ qua c&oacute; khoảng&nbsp;<strong>34.4 kcal.</strong></li>\r\n<li>Gi&uacute;p ph&ograve;ng xơ vữa động mạch</li>\r\n<li>N&acirc;ng cao sức đề kh&aacute;ng</li>\r\n<li>Bảo vệ m&agrave;ng tế b&agrave;o</li>\r\n<li>Bảo vệ tim mạch</li>\r\n</ul>\r\n</li>\r\n</ul>\r\n</div>\r\n</div>" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: "JZENO5",
                column: "dateCreated",
                value: new DateTime(2023, 10, 19, 16, 7, 55, 397, DateTimeKind.Local).AddTicks(2824));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: "JZENO6",
                column: "dateCreated",
                value: new DateTime(2023, 10, 19, 16, 7, 55, 397, DateTimeKind.Local).AddTicks(2829));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: "JZENO7",
                column: "dateCreated",
                value: new DateTime(2023, 10, 19, 16, 7, 55, 397, DateTimeKind.Local).AddTicks(2833));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: "JZENO8",
                column: "dateCreated",
                value: new DateTime(2023, 10, 19, 16, 7, 55, 397, DateTimeKind.Local).AddTicks(2837));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: "JZENO9",
                column: "dateCreated",
                value: new DateTime(2023, 10, 19, 16, 7, 55, 397, DateTimeKind.Local).AddTicks(2843));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "a5932398b5-d34640-9847ffbc3354521251",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp", "dateCreated" },
                values: new object[] { "68b89bb4-8f35-48a4-9a31-9c5eaac5530b", "A@CUSTOMER.COM", "AQAAAAIAAYagAAAAEIHVhfaY2E+yDFFMDHglta7si0ZlGAUtoi+s8OWKc1TrTBi2QPXeOkxIVa9VWacWiA==", "6a6fef96-b59d-4c87-b8c1-0984fda765d9", new DateTime(2023, 10, 19, 16, 7, 55, 393, DateTimeKind.Local).AddTicks(150) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "a79e98b4-d8a6-4640-98eb-5b417ffb2661",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "dateCreated" },
                values: new object[] { "8ceec679-0c7b-4128-9088-beda93e7d623", "AQAAAAIAAYagAAAAENJW8q1aCpSpx3JAi13xmJJSoE4RF4aWNIuFGQlV/mH6eqogS4h1oSxkYMa+U+RM8g==", "6d7c20b1-2039-4777-997b-dfacaf18d1e9", new DateTime(2023, 10, 19, 16, 7, 55, 309, DateTimeKind.Local).AddTicks(3167) });
        }
    }
}
