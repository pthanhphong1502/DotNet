using JZsGreen.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JZsGreen.Data
{
    public class JZenoDbContext : IdentityDbContext<User>
    {
        const string ADMIN_USER_GUID = "a79e98b4-d8a6-4640-98eb-5b417ffb2661";
        const string CUSTOMER_USER_GUID = "a5932398b5-d34640-9847ffbc3354521251";
        const string ADMIN_ROLE_GUID = "07bf1560-b5ff-4702-a9f1-a64026e570cf";
        const string CUSTOMER_ROLE_GUID = "2ccdcef3-db18-46c7-b5ff-910be6ae4906";
        private User user;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable(name: "Role");
                entity.HasData(
                    new IdentityRole
                    {
                        Id = ADMIN_ROLE_GUID,
                        Name = "Admin",
                        NormalizedName = "Admin"
                    },
                    new IdentityRole
                    {
                        Id = CUSTOMER_ROLE_GUID,
                        Name = "Customer",
                        NormalizedName = "Customer"
                    });
            });
            builder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable("UserRoles");
                entity.HasData(
                    new IdentityUserRole<string>
                    {
                        RoleId = ADMIN_ROLE_GUID,
                        UserId = ADMIN_USER_GUID,
                    },
                    new IdentityUserRole<string>
                    {
                        RoleId = CUSTOMER_ROLE_GUID,
                        UserId = CUSTOMER_USER_GUID,
                    });
            });
            builder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable("UserClaims");
            });
            builder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable("UserLogins");
            });
            builder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable("RoleClaims");
            });
            builder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable("UserTokens");
            });
            var hasher = new PasswordHasher<User>();
            builder.Entity<User>(entity =>
            {
                entity.ToTable("User");
                entity.HasData(
            new User
            {
                Id = ADMIN_USER_GUID,
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                PasswordHash = hasher.HashPassword(user, "123456"),
                NormalizedEmail = "ADMIN@GMAIL.COM",
                NormalizedUserName = "ADMIN@GMAIL.COM",
                EmailConfirmed = true,
                fullName = "Phạm Thanh Phong",
                PhoneNumber = "0819003999",
                dateCreated = DateTime.Now,
                point = 0
            },
            new User
            {
                Id = CUSTOMER_USER_GUID,
                UserName = "customer@gmail.com",
                Email = "customer@gmail.com",
                PasswordHash = hasher.HashPassword(user, "123456"),
                NormalizedEmail = "CUSTOMER@GMAIL.COM",
                NormalizedUserName = "CUSTOMER@GMAIL.COM",
                EmailConfirmed = true,
                fullName = "Vũ Quốc Huy",
                PhoneNumber = "0819003999",
                dateCreated = DateTime.Now,
                point = 0
            }
            );
            });

            builder.Entity<Category>(entity =>
            {
                entity.HasData(
                    new Category
                    {
                        Id = "rau-cu-nam-traicay-cac-loai",
                        name = "Rau, Củ, Nấm, Trái Cây",
                    },
                     new Category
                     {
                         Id = "giavi-botnem",
                         name = "Dầu Ăn Gia Vị",
                     }
                    );
            });

            builder.Entity<CategoryChild>(entity =>
            {
                entity.HasData(
                    new CategoryChild
                    {
                        Id = "Rau Lá",
                        name = "Rau lá",
                        categoryId = "rau-cu-nam-traicay-cac-loai"
                    },
                    new CategoryChild
                    {
                        Id = "Củ, Quả",
                        name = "Củ, Quả",
                        categoryId = "rau-cu-nam-traicay-cac-loai"
                    },
                    new CategoryChild
                    {
                        Id = "Trái Cây",
                        name = "Trái Cây",
                        categoryId = "rau-cu-nam-traicay-cac-loai"
                    },
                    new CategoryChild
                    {
                        Id = "Nấm",
                        name = "Nấm",
                        categoryId = "rau-cu-nam-traicay-cac-loai"
                    },
                    new CategoryChild
                    {
                        Id = "Gia Vị",
                        name = "Gia Vị",
                        categoryId = "giavi-botnem"
                    },
                    new CategoryChild
                    {
                        Id = "Dầu Ăn",
                        name = "Dầu Ăn",
                        categoryId = "giavi-botnem"
                    }
                    );
            });
            builder.Entity<Product>(entity =>
            {
                entity.HasData(
                    new Product
                    {
                        Id = "JZENO",
                        name = "Cải Bẹ Dún",
                        categoryId = "Rau Lá",
                        description = "<p><strong>Cải bẹ d&uacute;n</strong> được nu&ocirc;i trồng v&agrave; đ&oacute;ng g&oacute;i theo những ti&ecirc;u chuẩn nghi&ecirc;m ngặt, bảo đảm c&aacute;c ti&ecirc;u chuẩn xanh - sạch, chất lượng v&agrave; an to&agrave;n với người d&ugrave;ng. Rau tươi, gi&ograve;n v&agrave; ngọt thường được sử dụng l&agrave;m rau ăn k&egrave;m với c&aacute;c m&oacute;n cuốn hoặc trộn như b&uacute;n trộn, b&aacute;nh x&egrave;o,...</p>\r\n<p><strong>Cải bẹ d&uacute;n</strong> l&agrave; lo&agrave;i thực vật họ cải, c&ograve;n được gọi l&agrave; cải d&uacute;n, cải nh&uacute;n, cải bẹ nh&uacute;ng. Loại rau n&agrave;y chứa nhiều th&agrave;nh phần dinh dưỡng c&oacute; lợi cho sức khỏe như vitamin C, mềm ngọt m&aacute;t v&agrave; nhiều nguy&ecirc;n tố vi lượng, c&oacute; t&aacute;c dụng l&agrave;m m&aacute;t gan, thanh lọc, giải nhiệt cơ thể, giảm c&acirc;n, ngừa giảm tr&iacute; nhớ, trẻ h&oacute;a l&agrave;n da,...</p>\r\n<p><strong>Cải bẹ d&uacute;n</strong> thơm ngon, dễ ăn, th&iacute;ch hợp với khẩu vị của cả nh&agrave;.</p>",
                        discount = 0,
                        price = 9000,
                        quantity = 100,
                        totalPrice = 9000,
                        summary = "450-500g",
                        unit = "kg",
                        isActive = true,
                        dateCreated = DateTime.Now
                    },
                     new Product
                     {
                         Id = "JZENO1",
                         name = "Xà Lách",
                         categoryId = "Rau Lá",
                         description = "<p>Xà lách xanh được nuôi trồng và đóng gói theo những tiêu chuẩn nghiêm ngặt, bảo đảm các tiêu chuẩn xanh - sạch, chất lượng và an toàn với người dùng. Chứa nhiều chất xơ, hàm lượng dinh dưỡng cao, vị ngọt, giòn nên thường dùng làm rau ăn kèm cho các món cuốn như bánh xèo.</p>",
                         discount = 0,
                         price = 14000,
                         quantity = 100,
                         totalPrice = 14000,
                         summary = "300g",
                         unit = "kg",
                         isActive = true,
                         dateCreated = DateTime.Now
                     },
                      new Product
                      {
                          Id = "JZENO2",
                          name = "Cải Thìa",
                          categoryId = "Rau Lá",
                          description = "<p><strong>Cải th&igrave;a </strong>được nu&ocirc;i trồng v&agrave; đ&oacute;ng g&oacute;i theo những ti&ecirc;u chuẩn nghi&ecirc;m ngặt, bảo đảm c&aacute;c ti&ecirc;u chuẩn xanh - sach, chất lượng v&agrave; an to&agrave;n với người d&ugrave;ng. Vị cải gi&ograve;n, ngọt, m&aacute;t v&agrave; chứa nhiều chất xơ, h&agrave;m lượng dinh dưỡng cao n&ecirc;n thường được d&ugrave;ng để chế biến c&aacute;c m&oacute;n rau x&agrave;o hoặc luộc.</p>\r\n<p><strong>C&aacute;ch sơ chế cải th&igrave;a</strong> Cải mua về, t&aacute;ch rời từng l&aacute;. Rửa với nước sạch nhiều lần cho hết c&aacute;t. Ng&acirc;m nước muối lo&atilde;ng khoảng 30 ph&uacute;t. Sau đ&oacute; cắt kh&uacute;c 2 - 3cm vừa ăn. Chế biến ph&ugrave; hợp theo m&oacute;n ăn. M&oacute;n ăn dinh dưỡng, thanh m&aacute;t với cải th&igrave;a Cải th&igrave;a x&agrave;o dầu h&agrave;o. Gi&ograve;n ngon với cải th&igrave;a x&agrave;o nấm đ&ocirc;ng c&ocirc;. G&agrave; hấp cải th&igrave;a nấm đ&ocirc;ng c&ocirc;. Canh t&ocirc;m cải th&igrave;a thanh m&aacute;t cơ thể.</p>\r\n<p><strong>-&gt; Lưu &yacute;: </strong>Sản phẩm nhận được c&oacute; thể kh&aacute;c với h&igrave;nh ảnh về m&agrave;u sắc v&agrave; số lượng nhưng vẫn đảm bảo về mặt khối lượng v&agrave; chất lượng.</p>",
                          discount = 0,
                          price = 15000,
                          quantity = 100,
                          totalPrice = 9000,
                          summary = "450-500g",
                          unit = "kg",
                          isActive = true,
                          dateCreated = DateTime.Now
                      },
                       new Product
                       {
                           Id = "JZENO3",
                           name = "Bẹ Xanh",
                           categoryId = "Rau Lá",
                           description = "<p><strong>Cải bẹ xanh</strong>&nbsp;được nu&ocirc;i trồng v&agrave; đ&oacute;ng g&oacute;i theo những ti&ecirc;u chuẩn nghi&ecirc;m ngặt, bảo đảm c&aacute;c ti&ecirc;u chuẩn xanh - sach, chất lượng v&agrave; an to&agrave;n với người d&ugrave;ng. Với bẹ l&aacute; to, vị hơi đắng nhẹ, m&aacute;t v&agrave; thơm n&ecirc;n thường được d&ugrave;ng để nấu canh hoặc rau cuốn ăn k&egrave;m với b&aacute;nh x&egrave;o, gỏi cuốn.</p>\r\n<p><strong>Ngo&agrave;i t&aacute;c dụng chế biến m&oacute;n ăn:</strong>&nbsp;cải xanh c&ograve;n c&oacute; c&aacute;c t&aacute;c dụng chữa bệnh tuyệt vời, ăn nhiều cải xanh bổ sung vitamin K rất cần thiết cho cơ thể, gi&uacute;p tăng cường hệ miễn dịch, bảo vệ sức khỏe tim mạch v&agrave; c&oacute; thể ngăn ngừa c&aacute;c biểu hiện ung thư, ăn cải xanh nhiều c&ograve;n gi&uacute;p mắt s&aacute;ng khỏe, gi&uacute;p da ngăn ngừa l&atilde;o h&oacute;a, chắc khỏe hỗ trợ chị em phụ nữ trong việc chăm s&oacute;c sắc đẹp. Sơ chế cải bẹ xanh Cải sau khi mua về cần được lặt theo từng l&aacute;, rửa sạch lần đầu bằng nước muối để loại bỏ bụi bẩn cũng như lớp h&oacute;a chất hay chất bảo quản c&oacute; thể c&ograve;n lại tr&ecirc;n bề mặt l&aacute;. Sau đ&oacute; cần lược lại bằng nước thường th&ecirc;m một lần nữa mới đem cắt nhỏ rau t&ugrave;y theo m&oacute;n ăn sắp chế biến.</p>\r\n<p><strong>C&aacute;c m&oacute;n ngon chế biến từ cải bẹ xanh:</strong> Canh h&agrave;u cải bẹ xanh Canh cải bẹ xanh nấu ngh&ecirc;u Canh cải bẹ xanh nấu gừng Ch&aacute;o lươn cải bẹ xanh Ch&aacute;o c&aacute; r&ocirc; cải xanh Cải bẹ xanh c&ugrave;ng c&aacute;c loại rau kh&aacute;c như: rau cần, rau muống, bắp cải thảo, t&iacute;a t&ocirc;, hoa chuối, mồng tơi, x&agrave; l&aacute;ch, cải xoong, cải ngọt,... chụng nấu lẩu Th&aacute;i cũng rất hợp v&agrave; ngon.</p>\r\n<p><strong>-&gt; Lưu &yacute;</strong>: Sản phẩm nhận được c&oacute; thể kh&aacute;c với h&igrave;nh ảnh về m&agrave;u sắc v&agrave; số lượng nhưng vẫn đảm bảo về mặt khối lượng v&agrave; chất lượng.</p>",
                           discount = 0,
                           price = 10000,
                           quantity = 100,
                           totalPrice = 10000,
                           summary = "450-500g",
                           unit = "kg",
                           isActive = true,
                           dateCreated = DateTime.Now
                       },
                        new Product
                        {
                            Id = "JZENO4",
                            name = "Khổ Qua",
                            categoryId = "Củ, Quả",
                            description = "Chưa Cập Nhật",
                            discount = 0,
                            price = 22500,
                            quantity = 100,
                            totalPrice = 22500,
                            summary = "3-5 trái (500g)",
                            unit = "kg",
                            isActive = true,
                            dateCreated = DateTime.Now
                        },
                          new Product
                          {
                              Id = "JZENO5",
                              name = "Bí Hồ Lô",
                              categoryId = "Củ, Quả",
                              description = "Bí đỏ hồ lô hay bí đỏ hạt đậu, đây là giống bí có ruột rất đặc, ít hả ăn dẻo và ngọt. Bí hồ lô chứa nhiều chất dinh dưỡng và mang lại nhiều lợi ích cho sức khoẻ. Bí hồ lô có thể chế biến thành nhiều món ăn ngon như: sữa bí, canh bí, súp bí,... món nào cũng đều thơm ngon.",
                              discount = 0,
                              price = 13300,
                              quantity = 100,
                              totalPrice = 13300,
                              summary = "700-900g",
                              unit = "kg",
                              isActive = true,
                              dateCreated = DateTime.Now
                          },
                         new Product
                         {
                             Id = "JZENO6",
                             name = "Khoai Mỡ",
                             categoryId = "Củ, Quả",
                             description = "<p><strong>Khoai mỡ</strong> l&agrave; loại củ kh&aacute; được ưa chuộng trong những bữa ăn gia đ&igrave;nh.</p>\r\n<p><strong>Khoai mỡ</strong> c&oacute; h&agrave;m lượng kho&aacute;ng chất v&agrave; vitamin gi&uacute;p cải thiện hệ ti&ecirc;u ho&aacute;, gi&uacute;p nhuận tr&agrave;ng, chữa t&aacute;o b&oacute;n rất tốt. Khoai mỡ c&oacute; thể sử dụng để chế biến th&agrave;nh c&aacute;c m&oacute;n như: canh, b&aacute;nh khoai mỡ, khoai mỡ chi&ecirc;n gi&ograve;n,...</p>\r\n<p><strong>C&aacute;ch bảo quản khoai mỡ tươi ngon:</strong> Khoai mỡ c&oacute; thể được bảo quản trong điều kiện thường, để nơi kh&ocirc; r&aacute;o, tho&aacute;ng m&aacute;t. Hoặc quấn giấy, m&agrave;ng bọc v&agrave; bảo quản trong ngăn m&aacute;t tủ lạnh.</p>\r\n<p><strong>-&gt; Lưu &yacute;:</strong> Sản phẩm nhận được c&oacute; thể kh&aacute;c với h&igrave;nh ảnh về m&agrave;u sắc v&agrave; số lượng nhưng vẫn đảm bảo về mặt khối lượng v&agrave; chất lượng.</p>",
                             discount = 50,
                             price = 33000,
                             quantity = 100,
                             totalPrice = 33000 - (33000 * 0.5),
                             summary = "900g-1.1kg (1-2 củ)",
                             unit = "kg",
                             isActive = true,
                             dateCreated = DateTime.Now
                         },
                          new Product
                          {
                              Id = "JZENO7",
                              name = "Chuối Nam Mỹ",
                              categoryId = "Trái Cây",
                              description = "Chuối già là giống chuối chứa nhiều chất dinh dưỡng như kali, chất xơ, vitamin,... đem lại nhiều lợi ích cho sức khỏe như hỗ trợ giảm cân, hỗ trợ sức khoẻ tim mạch, cải thiện sức khoẻ của thận,... Trái cây tại Bách hóa XANH được đảm bảo chất lượng, cam kết đúng khối lượng.",
                              discount = 20,
                              price = 26000,
                              quantity = 100,
                              totalPrice = 26000 - (26000 * 0.2),
                              summary = "1 nải",
                              unit = "kg",
                              isActive = true,
                              dateCreated = DateTime.Now
                          },
                            new Product
                            {
                                Id = "JZENO8",
                                name = "Táo Pink Lady",
                                categoryId = "Trái Cây",
                                description = "<p>Táo nhập khẩu 100% từ New Zealand.&nbsp;Đạt tiêu chuẩn xuất khẩu toàn cầu.&nbsp;Bảo quản tươi ngon đến tận tay khách hàng.&nbsp;Trái vừa ăn, chắc tay, vỏ táo màu hồng xanh đẹp mắt.&nbsp;<strong>Táo ngon nhất khi có lớp vỏ màu đỏ đậm, táo còn cứng, không bị dập.</strong></p>",
                                discount = 10,
                                price = 69000,
                                quantity = 100,
                                totalPrice = 69000 - (69000 * 0.1),
                                summary = "5-7 trái (1kg)",
                                unit = "kg",
                                isActive = true,
                                dateCreated = DateTime.Now
                            },
                             new Product
                             {
                                 Id = "JZENO9",
                                 name = "Dưa Hấu Không Hạt",
                                 categoryId = "Trái Cây",
                                 description = "Dưa hấu không hạt là trái cây nhiều nước và các vitamin, khoáng chất cần thiết, đặc biệt là ít calo và chất béo. Dưa hấu được xem là một sản phẩm thay thế cho nước uống thông thường. Giúp giải khát thanh nhiệt mà còn bổ sung nhiều chất dinh dưỡng cho cơ thể, giúp bạn tràn đầy năng lượng.\n",
                                 discount = 0,
                                 price = 42000,
                                 quantity = 100,
                                 totalPrice = 42000,
                                 summary = "2kg trở lên",
                                 unit = "kg",
                                 isActive = true,
                                 dateCreated = DateTime.Now
                             },
                             new Product
                             {
                                 Id = "JZENO10",
                                 name = "Nấm Kim Châm Thái Lan",
                                 categoryId = "Nấm",
                                 description = "Nấm kim châm Thái Lan tươi ngon, được đóng gói cẩn thận, chất lượng và an toàn với người dùng. Sợi nấm dai, giòn và ngọt, khi nấu chín rất thơm nên thường được lăn bột chiên giòn, nấu súp hoặc để nướng ăn kèm.",
                                 discount = 0,
                                 price = 11000,
                                 quantity = 0,
                                 totalPrice = 42000,
                                 summary = "2kg trở lên",
                                 unit = "kg",
                                 isActive = false,
                                 dateCreated = DateTime.Now
                             },
                             new Product
                             {
                                 Id = "JZENO11",
                                 name = "Dầu Ăn Cao Cấp Happi KoKi",
                                 categoryId = "Dầu Ăn",
                                 description = "<p><strong>Dầu ăn cao cấp Happy Koki</strong> chai 1 l&iacute;t l&agrave; sản phẩm dầu ăn c&oacute; nguồn gốc 100% từ thực vật th&iacute;ch hợp chế biến thực phẩm từ chi&ecirc;n, x&agrave;o, ướp c&aacute;c m&oacute;n mặn cho đến m&oacute;n chay.</p>\r\n<p><strong>Dầu ăn Happi Koki</strong> kh&ocirc;ng chứa cholesterol, kh&ocirc;ng axit b&eacute;o cấu h&igrave;nh Trans, gi&agrave;u vitamin A, E v&agrave; Omega 3, 6, 9, an to&agrave;n cho sức khỏe.</p>",
                                 discount = 15,
                                 price = 45000,
                                 quantity = 17,
                                 totalPrice = 45000 - (45000 * 0.17),
                                 summary = "chai 1 lít",
                                 unit = "chai",
                                 isActive = true,
                                 dateCreated = DateTime.Now
                             },
                              new Product
                              {
                                  Id = "JZENO12",
                                  name = "Dầu Ăn Cao Cấp Happi KoKi",
                                  categoryId = "Dầu Ăn",
                                  description = "Dầu ăn cao cấp Happy Koki chai 5 lít là sản phẩm dầu ăn có nguồn gốc 100% từ thực vật thích hợp chế biến thực phẩm từ chiên, xào, ướp các món mặn cho đến món chay. Dầu ăn Happi Koki không chứa cholesterol, không axit béo cấu hình Trans, giàu vitamin A, E và Omega 3, 6, 9, an toàn cho sức khỏe.",
                                  discount = 15,
                                  price = 205000,
                                  quantity = 8,
                                  totalPrice = 205000 - (205000 * 0.1),
                                  summary = "chai 5 lít",
                                  unit = "chai",
                                  isActive = true,
                                  dateCreated = DateTime.Now
                              },
                               new Product
                               {
                                   Id = "JZENO13",
                                   name = "Hạt Nêm Aji-ngon Vị Heo",
                                   categoryId = "Gia Vị",
                                   description = "Sản phẩm được làm từ nước dùng của xương và thịt heo cùng với một lượng cân đối các loại gia vị khác. Hạt nêm vị heo Aji-ngon 400g là đến từ loại hạt nêm mang lại hương vị thơm ngon tự nhiên cho món ăn của gia đình bạn. Hạt nêm Aji-ngon gói nhỏ phù hợp nhu cầu sử dụng gia đình và dễ mang đi.",
                                   discount = 5,
                                   price = 33000,
                                   quantity = 20,
                                   totalPrice = 33000 - (33000 * 0.05),
                                   summary = "400g/gói",
                                   unit = "gói",
                                   isActive = true,
                                   dateCreated = DateTime.Now
                               },
                                new Product
                                {
                                    Id = "JZENO14",
                                    name = "Hạt Nêm Aji-ngon Vị Nấm",
                                    categoryId = "Gia Vị",
                                    description = "<p>Sản phẩm được l&agrave;m từ nước d&ugrave;ng của nấm c&ugrave;ng với một lượng c&acirc;n đối c&aacute;c loại gia vị kh&aacute;c.</p>\r\n<p>Hạt n&ecirc;m vị heo Aji-ngon 400g l&agrave; đến từ loại hạt n&ecirc;m mang lại hương vị thơm ngon tự nhi&ecirc;n cho m&oacute;n ăn của gia đ&igrave;nh bạn. Hạt n&ecirc;m Aji-ngon g&oacute;i nhỏ ph&ugrave; hợp nhu cầu sử dụng gia đ&igrave;nh v&agrave; dễ mang đi.</p>",
                                    discount = 5,
                                    price = 33000,
                                    quantity = 20,
                                    totalPrice = 33000 - (33000 * 0.05),
                                    summary = "400g/gói",
                                    unit = "gói",
                                    isActive = true,
                                    dateCreated = DateTime.Now
                                }

                    );

            });
            builder.Entity<ProductImage>(entity =>
            {
                entity.HasData(
                    new ProductImage
                    {
                        id = "images01",
                        fileName = "bedun.jpg",
                        productId = "JZENO"
                    },
                    new ProductImage
                    {
                        id = "images02",
                        fileName = "bedun01.jpg",
                        productId = "JZENO"
                    },
                    new ProductImage
                    {
                        id = "images03",
                        fileName = "xalach.png",
                        productId = "JZENO1"
                    },
                    new ProductImage
                    {
                        id = "images04",
                        fileName = "xalach01.jpg",
                        productId = "JZENO1"
                    },
                      new ProductImage
                      {
                          id = "images05",
                          fileName = "caithia.jpg",
                          productId = "JZENO2"
                      },
                        new ProductImage
                        {
                            id = "images06",
                            fileName = "caithia01.png",
                            productId = "JZENO2"
                        },
                     new ProductImage
                     {
                         id = "images07",
                         fileName = "bexanh.jpg",
                         productId = "JZENO3"
                     },
                     new ProductImage
                     {
                         id = "images08",
                         fileName = "bexanh01.png",
                         productId = "JZENO3"
                     },
                      new ProductImage
                      {
                          id = "images09",
                          fileName = "khoqua.jpg",
                          productId = "JZENO4"
                      },
                     new ProductImage
                     {
                         id = "images10",
                         fileName = "khoqua01.jpg",
                         productId = "JZENO4"
                     },
                      new ProductImage
                      {
                          id = "images11",
                          fileName = "biholo.jpg",
                          productId = "JZENO5"
                      },
                     new ProductImage
                     {
                         id = "images12",
                         fileName = "khoaimo.jpg",
                         productId = "JZENO6"
                     },
                      new ProductImage
                      {
                          id = "images13",
                          fileName = "chuoi.png",
                          productId = "JZENO7"
                      },
                       new ProductImage
                       {
                           id = "images14",
                           fileName = "chuoi01.jpg",
                           productId = "JZENO7"
                       },
                      new ProductImage
                      {
                          id = "images15",
                          fileName = "taopinklady.jpg",
                          productId = "JZENO8"
                      },
                      new ProductImage
                      {
                          id = "images16",
                          fileName = "duahau.jpg",
                          productId = "JZENO9"
                      },
                       new ProductImage
                       {
                           id = "images17",
                           fileName = "duahau01.jpg",
                           productId = "JZENO9"
                       },
                         new ProductImage
                         {
                             id = "images18",
                             fileName = "namkimcham.jpg",
                             productId = "JZENO10"
                         },
                         new ProductImage
                         {
                             id = "images19",
                             fileName = "dauan.jpg",
                             productId = "JZENO11"
                         },
                         new ProductImage
                         {
                             id = "images20",
                             fileName = "dauan01.jpg",
                             productId = "JZENO12"
                         },
                          new ProductImage
                          {
                              id = "images21",
                              fileName = "botnem.jpg",
                              productId = "JZENO13"
                          },
                           new ProductImage
                           {
                               id = "images22",
                               fileName = "botnem01.jpg",
                               productId = "JZENO14"
                           }
                    );

            });

        }
        public JZenoDbContext(DbContextOptions<JZenoDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<CategoryChild> CategoryChildren { get; set; }
        public DbSet<ProductImage> ProductImage { get; set; }
        public DbSet<Bill> Bill { get; set; }
        public DbSet<DetailOrder> DetailOrder { get; set; }
    }
}