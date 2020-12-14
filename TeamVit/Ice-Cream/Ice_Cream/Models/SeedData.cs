using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Ice_Cream.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            StoreDbContext context = app.ApplicationServices
                .CreateScope().ServiceProvider.GetRequiredService<StoreDbContext>();
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.Products.Any())
            {
                context.Products.AddRange(
                     new Product
                     {
                         Name = "Kem socola",
                         Image = "https://themes.muffingroup.com/be/icecream2/wp-content/uploads/2019/09/icecream2-ourproducts-pic1.png",
                         Description = "Không chỉ là một món kem tráng miệng giải nhiệt cho mùa hè còn giúp bạn thư giãn tinh thần.",
                         Ingredients = "Nguyên liệu" + "Bột cacao: 20 gram" + "Socola đen loại 70 % cacao: 90 gram" + "Đường cát trắng: 50 – 70 gram(tùy chọn gia giảm sao cho phù hợp với khẩu vị)" + "Kem tươi – whipping cream: 200 ml" + "Sữa tươi: 125 ml",
                         Recipe = "Hướng Dẫn Cách Làm Kem Socola" + "Bước 1: Đầu tiên bạn nên chuẩn bị một cái nồi, sau đó cho lần lượt các nguyên liệu kem tươi, bột cacao, đường vào nồi, khuấy đều. Đặt lên bếp, đun cho đến khi đường tan chảy hoàn toàn."
                                + "Bước 2: Sau đó, tiếp tục khuấy đều và đun cho đến khi hỗn hợp sôi nhẹ thì tắt bếp.Cho socolate đen vào khuấy đều cho tan.Cho tiếp sữa vào và khuấy tới khi hỗn hợp bóng lên."
                                + "Bước 3: Lọc qua rây qua để được một hỗn hợp mịn.Sau đó cho vào hộp đựng để nơi thoáng mát cho nguội."
                                + "Bước 4: Khi kem đã nguội đặt vào ngăn đông của tủ lạnh, cứ 1 tiếng bạn lại xới kem lên để tránh bị đóng đá.Làm như vậy khoảng 2 – 3 lần rồi để kem đông thêm 3 giờ nữa là có thể dùng được.",
                         Note = "Lưu ý:" + "Nếu không muốn kem tan nhanh thì trong quá trình làm kem bạn không nên cho nhiều đường. Đây không chỉ là một món kem tráng miệng giải nhiệt hiệu quả cho mùa hè mà còn giúp bạn thư giãn tinh thần nữa đấy. Món này luôn là sự lựa chọn hàng đầu của các bạn trẻ, vì thế nếu muốn kinh doanh kem đắt khách bạn không nên quên thêm món này vào menu của quán đâu đấy.",
                         Price = 0,
                         Category = "Free"
                     },
                     new Product
                     {
                         Name = "Kem chanh",
                         Image = "https://themes.muffingroup.com/be/icecream2/wp-content/uploads/2019/09/icecream2-ourproducts-pic2.png",
                         Description = "Kem chanh chua chua mát mát, ngọt dịu cực thơm, mát mẻ lo gì hè nóng bức.",
                         Ingredients = "Nguyên liệu" + "500ml whipping cream" + "250ml sữa tươi" + "5 quả trứng gà" + "100ml nước cốt chanh1 – 2 trái chanh (chanh giấy hoặc chanh vàng)"
                                        + "45ml mứt chanh sệt" + "150ml siro đường" + "Dụng cụ: Máy làm kem, tô đựng, dụng cụ đánh trứng, dụng cụ bào vỏ chanh, khuôn kem hoặc hộp nhựa…",
                         Recipe = "Cách làm" + "--Sơ Chế Nguyên Liệu:" + "Chanh: dùng dụng cụ bào vỏ chanh, bào lấy vỏ chanh để sẵn." + "Trứng gà: bỏ phần lòng trắng,chỉ lấy lòng đỏ."
                                    + "--Nấu Nền Kem:" + "Tiếp đến, bạn cho whipping cream, sữa tươi, siro đường, mứt chanh sệt vào chảo rồi nấu trên bếp, nhỏ lửa.Trong lúc nấu khuấy đều cho nguyên liệu tan đều vào nhau, nấu khoảng 5 phút thì tắt bếp.Bạn nên để lửa nhỏ liu ríu thôi nhé."
                                    + "Ở bước này, bạn không nên cho trực tiếp nước cốt chanh vào vì sẽ làm sữa tươi kết tủa.Mứt chanh đã được xử lý với nhiều đường hơn nên có thể cho vào nấu chung để tạo hương vị cho hỗn hợp kem ban đầu."
                                    + "--Làm Kem Chanh Đơn Giản:" + "Đầu tiên, bạn cho lòng đỏ vào tô rồi đánh đều.Rót từ từ hỗn hợp kem vừa nấu vào phần lòng đỏ trứng.Lưu ý, vừa rót vừa đánh đều hỗn hợp.Tiếp đến, bạn dùng màng bọc thực phẩm đậy kín, cho vào ngăn mát tủ lạnh khoảng 24 tiếng."
                                    + "Sau khi hỗn hợp kem để lạnh đủ thời gian, vắt lấy khoảng 100ml nước cốt chanh cho vào hỗn hợp, sau đó khuấy đều.Tùy vào khẩu vị thích ăn chua nhiều hay chua ít mà bạn gia giảm lượng nước cốt chanh cho vào kem."
                                    + "--Làm Kem Chanh Không Cần Dùng Máy:"
                                    + "– Nếu có máy làm kem, bạn cho hỗn hợp kem chanh vào máy quay khoảng 40 phút – 60 phút, sau đó đông lạnh tiếp khoảng 1 giờ là có thể dùng được."
                                    + "– Nếu không có máy làm kem, bạn cho hỗn hợp vào hộp nhựa rồi cho vào ngăn đông tủ lạnh.Khoảng 30 phút – 1 giờ, bạn lấy kem ra xới đều lên, sau đó tiếp tục cho vào ngăn đông.Khoảng 2 – 3 tiếng sau, tiếp tục lấy kem ra xới một lần nữa là được.Nếu có thời gian, bạn có thể xới kem nhiều lần để kem tơi xốp hơn.",
                         Note = "Lưu ý:" + "Khi Vắt Chanh Để Kem Không Bị Đắng:" + "Khi vắt nước chanh lưu ý nên chuẩn bị sẵn một chén nước đá lạnh có cho thêm chút đường và một chiếc khăn sạch."
                                + "Sau khi vắt xong một miếng chanh,bạn cho các đầu ngón tay tiếp xúc với vỏ chanh vào chén nước lạnh rửa sạch, lau khô tay sau đó mới tiếp tục vắt miếng chanh tiếp theo.Cách làm này đảm bảo tinh dầu trong vỏ chanh không lẫn vào nước cốt chanh gây đắng."
                                + "Để món kem chanh thêm hấp dẫn và dậy mùi thơm dễ chịu của chanh, sau khi lấy từng viên kem ra, bạn có thể cho 1 vài lát chanh lên trên hoặc bào một ít vỏ chanh tươi rắc lên mặt kem.Vị kem béo ngọt.vị chanh chua nhẹ và mùi hương dễ chịu từ tinh dầu vỏ chanh chắc chắn sẽ làm bạn thích thú.",
                         Price = 0,
                         Category = "Free"
                     },
                     new Product
                     {
                         Name = "Kem dâu tây sữa",
                         Image = "https://themes.muffingroup.com/be/icecream2/wp-content/uploads/2019/09/icecream2-ourproducts-pic6.png",
                         Description = "Kem dâu nước cốt dừa hòa quyện với dâu tây kem không quá ngọt khiến bạn ăn hoài không ngán.",
                         Ingredients = "Nguyên liệu" + "Dâu tây 500 gr" + "Thickened cream 600 ml(hoặc whipping cream/heavy cream)" + "Sữa bột nguyên kem 65 gr"
                                        + "Sữa đặc có đường 400 ml" + "Nước cốt chanh 1 muỗng canh" + "Dụng cụ thực hiện: Máy đánh trứng, tô, thìa khuấy,...",
                         Recipe = "Cách chế biến Kem dâu tây sữa:" + "--Sơ chế dâu:" + "500gr dâu tây bạn bóc bỏ phần cuống lá xanh, rửa sạch, để ráo." + "Dùng máy xay cầm tay xay nhỏ dâu rồi trộn đều với 65gr sữa bột nguyên kem."
                                + "--Đánh kem tươi:" + "Đổ thickened cream vào tô, dùng máy đánh cho tới khi kem đạt trạng thái bông cứng."
                                + "--Làm kem:" + "Bạn đổ lần lượt dâu sữa bột, 400ml sữa đặc có đường, 1 muỗng canh nước cốt chanh vào tô kem tươi, dùng thìa khuấy đến khi hỗn hợp hòa quyện đều với nhau."
                                + "Đổ hỗn hợp kem vào khuôn, bọc kín bằng màng bọc thực phẩm rồi đem cấp đông trong vòng 2 giờ. Sau đó bạn dùng nĩa đánh trộn để kem tơi ra."
                                + "Tiếp theo bọc kem lại cấp đông thêm khoảng 5 giờ cho kem đông cứng lại là có thể thưởng thức."
                                + "--Thành phẩm:" + "Kem sữa dâu ngọt ngào, dịu thơm, mát lạnh, tan ngay trong miệng thật sảng khoái, thích thú. Khi ăn bạn rắc thêm một ít dâu xay để tăng thêm hương vị nhé.",
                         Note = "",
                         Price = 0,
                         Category = "Free"
                     },
                     new Product
                     {
                         Name = "Kem dưa hấu chanh tươi",
                         Image = "https://themes.muffingroup.com/be/icecream2/wp-content/uploads/2019/09/icecream2-ourproducts-pic7.png",
                         Description = "Kem dưa hấu với hương vị thanh mát, ngọt dịu là món ăn được nhiều người yêu thích.",
                         Ingredients = "Nguyên liệu làm kem dưa hấu chanh tươi" + "600 gram dưa hấu (khoảng ½ trái)." + "100 gram đường cát trắng." + "2 quả chanh tươi – nên chọn chanh vàng của Mỹ sẽ không bị chát và đắng."
                                        + "200ml sữa tươi không đường." + "4 hộp sữa chua có đường." + "50ml sữa đặc.",
                         Recipe = "Cách làm kem dưa hấu chanh tươi" + "Bước 1: Chanh vắt lấy nước. Dưa hấu gọt vỏ, cắt miếng nhỏ. Rưới nước chanh lên dưa hấu, thêm đường cát và trộn đều. Bỏ dưa hấu vào ngăn mát tủ lạnh khoảng 1 tiếng."
                                    + "Bước 2: Cho dưa hấu vào máy xay sinh tố, xay nhuyễn. Dùng rây lọc nhiều lần để bỏ bã và nước dưa hấu không bị cặn."
                                    + "Bước 3: Cho nước dưa hấu vào tô to, cho thêm sữa tươi, sữa chua, sữa đặc vào và dùng máy đánh trứng đánh đều khoảng 2 phút để các nguyên liệu đều quyện vào nhau."
                                    + "Bước 4: Cho hỗn hợp kem vào hộp, đặt vào ngăn đá của tủ lạnh. Sau khoảng 1 – 2 tiếng, bạn lấy kem ra, đánh mịn rồi cho lại vào tủ. Lặp lại khoảng 3 – 7 lần để kem xốp, mịn và mềm dẻo hơn.",
                         Note = "",
                         Price = 0,
                         Category = "Free"
                     },
                     new Product
                     {
                         Name = "Kem dưa lưới",
                         Image = "https://themes.muffingroup.com/be/icecream2/wp-content/uploads/2019/09/icecream2-ourproducts-pic4.png",
                         Description = "Món kem béo ngậy,vị ngọt thanh của dưa lưới tạo nên một món kem ngọt lành, thanh mát.",
                         Ingredients = "Nguyên liệu làm Kem dưa lưới(Cho 3 người)" + "Dưa lưới 1 trái" + "Mật ong 2 muỗng canh"
                                         + "Nước cốt chanh 1 muỗng canh"
                                        + "Dụng cụ: Dao, thớt, máy xay sinh tố, khay hoặc hộp đựng.",
                         Recipe = "Cách chế biến Kem dưa lưới"
                                + "--Sơ chế nguyên liệu:"
                                + "Dưa lưới bổ đôi, dùng muỗng múc bỏ phần hạt. Gọt vỏ, sau đó dùng dao cắt dưa lưới thành những khối vuông nhỏ."
                                + "Xếp dưa lưới đã cắt lên khay sau đó bỏ ngăn đá khoảng 1 - 2 tiếng cho phần dưa lưới đông lại."
                                + "--Xay dưa lưới:"
                                + "Lấy dưa lưới ở ngăn đá xuống. Sau đó cho vào máy xay, xay khoảng 30 giây cho rã phần dưa lưới đã đông."
                                + "Sau đó cho thêm mật ong, nước cốt chanh vào, bật máy ở chế độ xay nhuyễn để cho các nguyên liệu hòa quyện vào nhau"
                                + "Cho phần kem dưa lưới vào khuôn đựng hoặc hộp rồi cho vào tủ lạnh dùng dần."
                                + "--Thành phẩm:"
                                + "Món kem dưa lưới mát lạnh, hương thơm dịu nhe, vị chua chua ngọt ngọt vừa giải nhiệt, vừa tốt cho sức khỏe.",
                         Note = "Lưu ý: khi xay dưa lưới bạn cho thêm khoảng 2 muỗng canh nước lọc để xay dễ hơn do lúc này phần dưa lưới đã bị đông đá nên khá cứng.",
                         Price = 0,
                         Category = "Free"
                     },
                     new Product
                     {
                         Name = "Kem cacao",
                         Image = "https://themes.muffingroup.com/be/icecream2/wp-content/uploads/2019/09/icecream2-ourproducts-pic8.png",
                         Description = "Kem cacao luôn là món kem chưa bao giờ hết HOT trong các mùa hè oi bức.",
                         Ingredients = "Nguyên liệu làm kem cacao:"
                                        + "Bột cacao: 1/2 bát con"
                                        + "Whipping cream: 150ml"
                                        + "Đường: 1/2 bát con"
                                        + "Sữa tươi không đường: 180ml",
                         Recipe = "Các bước làm kem cacao:"
                                + "Bước 1:Bạn cho sữa tươi, bột cacao, đường kính vào một cái nồi, bắc lên bếp rồi đun ở lửa nhỏ. Bạn đun hỗn hợp khoảng 5 - 10 phút, khuấy đều và không được để hỗn hợp sôi."
                                + "Bước 2: Cho whipping cream vào một cái bát, dùng máy đánh trứng đánh bông hỗn hợp lên.Nếu không có máy thì bạn có thể đánh bằng phớ lồng cũng được."
                                + "Bước 3: Sau khi đã đánh bông whipping cream, bạn trộn hỗn hợp cacao vào, khuấy đều nhẹ tay cho chúng hòa quyện vào nhau. Trút hỗn hợp vào một chiếc hộp nhựa sạch, để vào ngăn đá tủ lạnh khoảng 2 tiếng. Sau 2 tiếng, bạn đem ra và đảo đều lên để kem không bị xuất hiện đá dăm. Lặp lại công đoạn này 1 - 2 lần thì kem sẽ rất xốp mềm và thơm ngon y như ngoài hàng đấy nha.",
                         Note = "",
                         Price = 0,
                         Category = "Free"
                     },
                     new Product
                     {
                         Name = "Kem mochi Nhật Bản",
                         Image = "https://cdn.dayphache.edu.vn/wp-content/uploads/2018/01/kem-mochi-nhat-ban.jpg",
                         Description = "Đậm đà hương vị Nhật Bản với Kem Mochi Nhật Bản với vỏ bánh mềm dẻo dai bọc ngoài nhân kem mát lạnh ngọt lịm người.",
                         Ingredients = "-Nguyên liệu:"
                                        + "100 gram Shiratamako (một loại bột được làm từ gạo nếp Nhật Bản)."
                                        + "1/3 chén bột bắp."
                                        + "Nước 180 ml."
                                        + "55 gram đường cát trắng."
                                        + "Kem tươi (hương vị tùy chọn).",
                         Recipe = "-Thực hiện:"
                                + "Bước 1: Đầu tiên bạn cần chuẩn bị 1 chiếc khay đựng trứng, sau đó dùng màn bọc thực phẩm phủ lên trên những ô tròn đựng trứng. Kem tươi dùng dụng cụ múc thành những viên tròn và cho chúng mỗi ô trống tương ứng, tiếp tục dùng màn bọc quấn lại và cho vào tủ lạnh bảo quản qua đêm đến khi được đông cứng."
                                + "Bước 2: Trong một cái tô, bạn lần lượt cho đường cát trắng và bột shiratamako vào dùng whisk trộn đều hỗn hợp. Cho thêm nước và tiếp tục đánh cho đến khi nhuyễn mịn và bột shiratamako được hòa tan hoàn toàn."
                                + "Bước 3: Dùng màn bọc thực phẩm bọc lại miệng tô hỗn hợp đường, bột shiratamako vừa đánh xong, cho vào lò vi sóng nấu từ 3 – 4 phút. Sau đó lấy ra dùng muỗng gỗ khuấy trộn lại lần nữa.Tiếp tục nấu trong lò vi sóng thêm 1 phút hoặc đến khi bột mịn, không nấu quá lâu bột dễ bị cứng."
                                + "Bước 4: Chuẩn bị 1 tờ giấy nến, đỗ hỗn hợp bột ra gói lại và nắn thành hình chữ nhật. Lấy tiếp 1 tờ giấy nến khác phủ lên trên bột rồi dùng cây cán thành miếng bột mỏng khoảng 2mm. Để bột nguội ở nhiệt độ phòng khoảng 10 – 15 phút thì gỡ lớp giấy ở trên ra.Rắc đều bột ngô lên trên bề mặt bột.Dùng khuôn cắt thành những miếng hình tròn."
                                + "Bước 5: Khéo léo gỡ những miếng vỏ hình tròn vừa cắt xong để sang một cái mâm hoặc khay chờ sử dụng. Lưu ý các bạn nên lót phía dưới mâm hoặc khay sẵn một miếng bọc nilon để khi dùng đến sẽ dễ lấy và không bị dính.Phần bột còn thừa tiếp tục lấy cán và cắt cho đến khi hết."
                                + "Bước 6: Lấy phần nhân kem đã chuẩn bị ở bước 1 ra khỏi tủ lạnh. Cho nhân kem vào vỏ, dùng tay gói tất cả lại cho đến khi hết kem và vỏ."
                                + "Bước 7: Gói kín những viên kem mochi vào trong từng miếng bọc nilon được cắt hình vuông đã chuẩn bị sẵn. Để kem mochi vào trong hộp có nắp đậy kín, bảo quản trong ngắn đá.Trước khi ăn nên để ngoài nhiệt độ phòng từ 5 - 10 phút hoặc ngăn mát khoảng 15 phút cho vỏ bánh được mềm.",
                         Note = "Khi bọc kem, các bạn nên lưu ý thao tác phải nhanh dứt khoát. Tránh để kem bị dính vào tay hoặc mép bột, sẽ khó bọc phần vỏ bột lại.Nếu trời nóng hay nhiệt độ ở phòng quá cao, thì khi bọc kem chỉ nên làm viên nào lấy ra viên đó rồi lập tức cho lại vào ngắn đá, chứ không nên lấy ra hết kem sẽ bị chảy.",
                         Price = 1,
                         Category = "Fee"
                     },
                     new Product
                     {
                         Name = "Kem chà là thịt xông khói",
                         Image = "https://image.cooky.vn/recipe/g4/37992/s640/recipe37992-cook-step3-636709761991463871.jpg",
                         Description = "Kem chà là thịt xông khói khá lạ miệng với vị chà là ngọt ngon kèm theo chút vị mằn mặn của thịt xông khói mang đến cho bạn một cảm nhận khác biệt .",
                         Ingredients = "-Nguyên liệu:"
                                    + " Trái chà là 85 gr"
                                     + "Thịt xông khói 4 lát"
                                     + "Siro đường 120 m"
                                     + "Sữa đặc 100 gr"
                                     + "Nhục đậu khấu 1/4 muỗng cà phê"
                                     + "Heavy cream 415 gr(kem sữa béo)"
                                     + "Rượu Brandy 2 muỗng canh"
                                     + "Dầu ăn 2 muỗng canh"
                                + "Dụng cụ:	Lò vi sóng, máy xay sinh tố,...",
                         Recipe = "-Thực hiện:"
                                + "Bước 1: Chiên thịt xông khói:Bạn bắc chảo lên bếp mở lửa vừa, đợi nóng thêm 2 muỗng canh dầu ăn vào rồi cho chiên thịt xông khói vào chiên, chiên cho tới khi thấy vàng nâu thì tắt bếp, lấy thịt xông khói ra để ráo dầu, cắt nhỏ.Bạn lấy 2 muỗng canh dầu chiên thịt xông khói để nguội sau đó cho vào ngăn đông tủ lạnh."
                                + "Bước 2: Sơ chế chà là: Chà là bạn tách hạt, cắt nhỏ rồi cho vào tô với 2 muỗng canh rượu Brandy và cho vào lò vi sóng khoảng 30 - 40 giây, lấy ra trộn đều rồi ngâm khoảng 10 phút."
                                + "Bước 3: Trộn hỗn hợp chà là và thịt xông khóiBạn cho thịt xông khói, hỗn hợp chà là vào tô lớn trộn đều, sau đó cho thêm 100 gr sữa đặc, 120 ml siro đường, 1/4 muỗng nhục đậu khấu trong tô, đảo nhẹ tay cho đều hỗn hợp."
                                + "Bước 4: Làm kem: Bạn cho heavy cream, 2 muỗng dầu chiên thịt xông khói đã đông lạnh vào máy xay sinh tố xay nhuyễn. Sau đó cho hỗn hợp chà là, thịt xông khói vào và trộn thật đều. Có thể cho thêm siro nếu thích ăn ngọt. Cuối cùng cho kem vào hộp và cho vào tủ lạnh để 6 tiếng là kem đông có thể ăn được rồi đó."
                                + "Bước 5:Thành phẩm: Khi ăn bạn lấy kem ra, múc thành từng viên ra ly và thưởng thức.Kem chà là thịt xông khói đẹp mắt thơm ngon với vị ngọt thanh của chà là quyện cùng vị thịt mằn mặn béo béo khá lạ miệng đấy."
                                + "Nếu bạn thích sự mới lạ thì hãy thử ngay món kem này nhé. Chúc bạn ngon miệng! ",
                         Note = "MẸO: Bạn nên làm kem theo đúng tỉ lệ hướng dẫn để kem ngon. Kem dùng ngon nhất khi dùng trong ngày, nếu ăn không hết có thể bảo quản trong ngăn đông tủ lạnh và dùng trong khoảng 1 tuần."
                                    + "Heavy cream không dùng hết có thể để ngăn đông tủ lạnh, lau sạch phần kem dính trên miệng hộp bọc kín lại bằng màng bọc thực phẩm rồi cho vào ngăn đông, cách này sẽ bảo quản heavy cream được khoảng nửa tháng.",
                         Price = 1,
                         Category = "Fee"
                     },
                     new Product
                     {
                         Name = "Kem Ý gelato",
                         Image = "https://static.hotdeal.vn/images/593/593433/500x500/118657-don-nam-moi-voi-thuong-hieu-kem-y-goody-noi-tieng-lau-nam-tai-viet-nam.jpg",
                         Description = "Gelato là từ 'kem' trong tiếng Ý - một món tráng miệng đặc trưng nổi tiếng của đất nước này.",
                         Ingredients = "-Nguyên liệu:"
                                        + "500ml sữa tươi"
                                        + "250ml kem tươi (whipping cream)"
                                        + "4 lòng đỏ trứng"
                                        + "100gr đường"
                                        + "40gr hạt dẻ cười (tách vỏ)"
                                        + "40gr hạt dẻ cười nghiền nhuyễn (pistachio nut paste)",
                         Recipe = "-Thực hiện:"
                                    + "Bước 1: Đầu tiên, bạn đổ sữa tươi và kem tươi vào nồi đun nóng đến khi nổi bọt."
                                    + "Bước 2: Tiếp theo, bạn lấy 4 lòng đỏ trứng cho vào bát to rồi thêm đường. Đánh đều đến khi hỗn hợp bông, xốp. Đầu tiên, bạn đổ sữa tươi và kem tươi vào nồi đun nóng đến khi nổi bọt."
                                    + "Bước 3: Giờ thì đổ một nửa hỗn hợp sữa kem vào hỗn hợp trứng vừa đánh bông."
                                    + "+ Trộn đều lên thật nhanh."
                                    + "Bước 4: - Đổ hỗn hợp vừa trộn vào nốt phần hỗn hợp sữa kem còn lại trên bếp."
                                    + "Bước 5: Thêm tiếp phần hạt dẻ cười nghiền nhuyễn vào nồi, khuấy đều quyện lên."
                                    + "Bước 6: Sau đó, đổ hỗn hợp đã nấu xong vào khay đựng rồi cất tủ đá đợi đông lại."
                                    + "Bước 7: - Cuối cùng, trước khi ăn 15 - 30 phút: Bạn lấy kem ra rồi rắc hạt dẻ cười tách vỏ lên trên, ấn nhẹ tay xuống là có thể thưởng thức được rồi."
                                    + "*Giờ chỉ việc lấy từng phần kem ra đĩa rồi mời cả nhà thưởng thức ngay nào!*",
                         Note = "*Lưu ý: Đánh thật nhanh để tránh làm trứng chín ở nhiệt độ nóng.",
                         Price = 1,
                         Category = "Fee"
                     },
                     new Product
                     {
                         Name = "Kem trà sữa",
                         Image = "https://cdn.tgdd.vn/Files/2020/04/24/1251565/cach-lam-kem-tra-sua-tran-chau-duong-den-mat-lanh-.jpg",
                         Description = "Kem trà sữa trân châu đường đen mát lạnh, thơm thơm béo béo, thoang thoảng vị trà.",
                         Ingredients = "-Nguyên liệu:"
                                        + "Kem whipping500 ml"
                                        + "Trà túi lọc10 Gr"
                                        + "Sữa đặc100 Gr",
                         Recipe = "-Thực hiện:"
                                    + "Bước 1: Cho 4gr trà Earl grey vào máy xay mịn. Cho 500ml kem whipping cho vào nồi đun sôi, sau đó thêm 6gr trà Earl grey vào nấu khoảng 3 phút ở lửa nhỏ. Tiếp theo cho thêm 4gr trà đã xay nhuyễn vào khuấy đều, tắt bếp, ủ trà 5 phút sau đó lọc hỗn hợp qua rây để bỏ bả trà."
                                    + "Bước 2: Để tô kem trà sữa thật nguội thì cho vào ngăn mát tủ lạnh 2 tiếng hoặc cho vào ngăn đông đến khi nhiệt độ của tô kem hạ xuống khoảng 10 độ C. Tiếp theo lấy tô kem trà sữa ra đánh bông chóp mềm. Sau đó cho sữa đặc vào tô kem, trộn đều lên cho tất cả hòa quyện. Đổ hỗn hợp kem trà sữa ra khuôn kem, bọc lại đem làm đông từ 6 tiếng đến qua đêm."
                                    + "Bước 3:Bày trí kem trà sữa trân châu đường đen: Chuẩn bị sẵn trân châu đường nâu, cho ra ly, múc kem vào từng ly và thưởng thức thôi nào. Nếu thích nhiều trân châu hơn bạn có thể rưới thêm trân châu lên trên viên kem cho thêm phần đẹp mắt và ngon miệng."
                                    + "Bước 4: Kem trà sữa trân châu đường đen là sự kết hợp hoàn hảo giữa một ly kem mát lạnh và một ly trà sữa ngọt ngào, điểm tô những viên trân châu dai dai thơm mùi đường đen."
                                    + "Cách làm món kem trà sữa trân châu này thì cực kì đơn giản, với 3 nguyên liệu cơ bản, chỉ cần bỏ ra chưa đến 30 phút thực hiện thôi.",
                         Note = "",
                         Price = 1,
                         Category = "Fee"
                     },
                     new Product
                     {
                         Name = "Kem trà sữa trân châu đường đen",
                         Image = "https://kenh14cdn.com/thumb_w/660/2019/5/16/photo-3-1558011059896924672579.jpg",
                         Description = "Kem trà sữa trân châu đường đen",
                         Ingredients = "-Nguyên liệu:"
                                        + "Kem whipping 500 ml"
                                        + "Trà túi lọc Earl Grey 4 miếng"
                                        + "Sữa đặc 100 ml"
                                        + "Trân châu làm sẵn 100 gr"
                                        + "Đường đen 70 gr"
                                    + "-Dụng cụ: Máy xay sinh tố, máy đánh trứng",
                         Recipe = "-Thực hiện:"
                                    + "Bước 1:Nấu kem sữa tươi và trà: Cắt 1 túi trà lọc, cho 4g trà Earl Grey vào máy xay sinh tố, xay cho nhuyễn mịn."
                                    + "+Cho 500ml kem whipping cho vào nồi đun sôi với lửa vừa, cho thêm 3 túi trà Earl Grey còn lại vào nấu khoảng 3 phút ở lửa nhỏ.Cho thêm 4g trà đã xay nhuyễn vào nồi rồi khuấy đều, sau đó tắt bếp, ủ trà khoảng 5 phút nữa, sau đó lọc hỗn hợp qua rây để bỏ bả trà và lấy được hỗn hợp mịn."
                                    + "Bước 2:Trộn và ủ lạnh hỗn hợp kem" + "Đợi tô kem trà sữa nguội hoàn toàn thì cho vào ngăn mát tủ lạnh khoảng 2 tiếng hoặc cho vào ngăn đông, nhiệt độ của tô kem khoảng 10 độ C là được."
                                    + "+Lấy tô kem trà sữa ra khỏi tủ lạnh, dùng máy đánh trứng đánh bông ở tốc độ vừa cho tới khi có chóp mềm.Cho sữa đặc vào tô kem, trộn đều lên cho hỗn hợp hòa quyện.Đổ hỗn hợp kem trà sữa ra khuôn kem, bọc lại cho vào ngăn đá tủ lạnh từ 6 - 8 tiếng hoặc qua đêm cho kem đông cứng lại hoàn toàn."
                                    + "Bước 3:Làm trân châu đường đen: Đối với trân châu làm sẵn: Bắc 1 nồi nước lên bếp, nước sôi các bạn cho trân châu mua sẵn vào luộc, đun tầm 25 phút cho chín. Sau đó vớt ra 1 tô nước lạnh cho nguội rồi vớt ra để ráo nước. Cho 70g đường đen với 50ml nước nấu cho đường tan là được. Sau cùng bạn cho phần nước đường này vào trân châu đã vớt ra lúc nãy, trộn đều lên là được."
                                    + "Bước 4: Hoàn thành: Kem đã đông đá, bạn lấy kem ra.Dùng dụng cụ lấy kem chuyên dụng múc kem thành từng viên tròn cho vào ly, sau đó tùy theo khẩu vị mà bạn cho trân châu vào nhiều hay ít.",
                         Note = " *Mẹo nhỏ: Nếu không có dụng cụ múc kem, bạn có thể dùng muỗng to có lòng hơi sâu một chút mà múc kem thành viên cho vào ly. Bạn lấy kem xong nhớ cho phần kem còn lại vào ngăn đá để bảo quản nhé! ",
                         Price = 1,
                         Category = "Fee"
                     },
                     new Product
                     {
                         Name = "Kem phô mai",
                         Image = "https://danangfantasticity.com/wp-content/uploads/2019/03/hokkaido-baked-cheese-tart-da-nang-tung-menu-moi-cuc-hap-dan-04.jpg",
                         Description = "Kem phô mai sau khi làm xong có mùi thơm và vị ngọt của sữa, vị chua nhẹ của chanh, và mằn mặn của một chút muối.",
                         Ingredients = "-Nguyên liệu:"
                                        + "4 lòng đỏ trứng gà"
                                        + "1+1/4 cup kem tươi ( whipping cream )"
                                        + "1+1/4 cup sữa tươi nguyên kem"
                                        + "400g phô mai cheddar hoặc vị phô mai bạn thích"
                                        + "1/8 tsp muối "
                                        + "1/2 cup mật ong",
                         Recipe = "-Thực hiện: "
                                    + "Bước 1:Trước hết, các bạn đổ kem tươi, sữa nguyên kem khuấy đều. Xem độ ngọt có vừa khẩu vị để gia giảm mật ong."
                                    + "Bước 2: Cho trứng vào hỗn hợp kem sữa trên trộn đều, bắc lên bếp đun nhỏ lửa trong vòng 10 phút. Sử dụng lòng trắng cũng được nhưng dễ bị lợn cợn và tạo nhiều bọt khí ở bước làm kem tiếp theo."
                                    + "Bước 3: Hỗn hợp vừa đun cho ra bát, trộn cùng với phô mai cheddar, không cần khuấy tan phô mai, chỉ cần trộn đều là được, để trong tủ lạnh ngăn mát 3 tiếng."
                                    + "Bước 4: Sau 3 tiếng, sử dụng máy đánh trứng ở mức cao nhất trong vòng 15 phút đến khi hỗn hợp trở nên gấp đôi."
                                    + "Bước 5: Cuối cùng cho kem phô mai vào khuôn, gõ nhẹ để giảm bớt bọt khí. Bảo quản kem trong tủ đá, sử dụng muỗng múc kem để có những viên kem đẹp mắt. Hoặc có thể cho vào túi bắt bông kem, bơm tạo hình lên ốc quế là y hệt kem của Hokkaido nhé!",
                         Note = "**MẸO: +Kem tươi sử dụng loại có phần trăm cao hơn 30% để đảm bảo kem không bị đông đá, vẫn dẻo mịn. Nếu không có loại kem tươi độ béo tương ứng thì có thể lấy kem tươi tùy ý và thêm 30g bơ nhạt."
                            + "Không thể thay thế topping cream cho whipping cream các bạn nhé!"
                            + "Khi các nguyên liệu khác thêm vào làm tăng tỷ lệ chất lỏng (sữa) so với whipping cream thì mình có thể giảm sữa tươi đi. Lưu ý thêm là nếu xay các loại hoa quả mà cần đổ thêm nước để có lực đẩy cho lưỡi dao thì mình nên dùng chính sữa tươi chứ đừng đổ nước lọc. Thành phần càng ít chất lỏng thì kem càng dẻo mịn."
                            + "Không cần hộp kem chuyên dụng, chỉ cần hộp có nắp kín để hạn chế kem bị dăm đá. Hộp kem phô mai để trong tủ trước từ 4-5 tiếng."
                            + "Bước đến đánh bông hỗn hợp nên để trước que đánh trứng trong tủ đá 10 phút để hỗn hợp bông tốt nhất."
                            + "Kem phô mai để lâu trong tủ đá sẽ bị cứng, khó thao tác múc kem, các bạn nên để cả hộp kem xuống tủ mát 20 phút để kem mềm dễ dàng múc ra. Không nên để cả hộp kem ra ngoài, vì như vậ hộp kem sẽ hết lạnh nhưng kem bên trong vẫn cứng.",
                         Price = 1,
                         Category = "Fee"
                     },
                     new Product
                     {
                         Name = "Kem sầu riêng",
                         Image = "https://www.banmaylamkem.com/uploads/userfiles/cach-lam-kem-sau-rieng-ngon(1).jpg",
                         Description = "Ngoài việc ăn sầu riêng tươi chúng ta có thể khéo léo trổ tài biến nó thành một món ăn mới mang hương vị mới!",
                         Ingredients = "-Nguyên liệu:"
                                        + "Thịt sầu riêng: 350 gram."
                                        + "Kem whipping: 250 ml."
                                        + "Sữa tươi không đường: 100 ml."
                                        + "Sữa đặc: 30 gram."
                                        + "Đường: 60 gram.",
                         Recipe = "-Thực hiện:"
                                    + "Bước 1: Xay sầu riêng: Đầu tiên, các bạn chuẩn bị máy xay sinh tố, tiếp đó cho sầu riêng + sữa đặc và sữa tươi vào. Tiến hành xay thật đều và nhuyễn."
                                    + "Bước 2: Đánh kem và đường: Các bạn chuẩn bị một cái âu nhỏ, cho kem và đường vào. Sau đó dùng máy hoặc phới đánh sơ qua cho kem chuyển sang dạng hơi sánh là được."
                                    + "Bước 3: Trộn hỗn hợp kem và sầu riêng: Các bạn thực hiện trút hết phần kem và sầu riêng vào cùng 1 cái âu rồi trộn thật nhẹ nhàng cho 2 hỗn hợp này được đều nhau là xong."
                                    + "Bước 4: Làm đông lạnh kem: Tiến hành đổ hỗn hợp đã trộn đều ở bước 3 vào hộp hoặc hũ nhỏ, sau đó đậy kín nắp lại và đặt vào trong ngăn đá tủ lạnh khoảng từ 6 – 7 tiếng để kem được đông lại."
                                    + "Bước 5: Trình bày: Sau 6 – 7 tiếng, kem đã đông. Lúc này, chúng ta tiến hành múc kem sầu riêng ra ly, có thể thêm trái cây hoặc bánh quy vào trang trí cùng cho đẹp mắt và có thể bắt đầu thưởng thức ngay rồi đó.",
                         Note = "",
                         Price = 1,
                         Category = "Fee"
                     },
                     new Product
                     {
                         Name = "Kem bánh trung thu",
                         Image = "https://media.cooky.vn/recipe/g3/21725/s320x320/recipe21725-prepare-step4-636404874730545553.jpg",
                         Description = "Chỉ cần có khuôn bánh trung thu với hoa văn bắt mắt là bạn có thể làm ngay những chiếc bánh trung thu kem lạnh xinh xắn. Vị bánh ngọt đặc trưng, kem mát lạnh, giúp bạn vừa ăn ngọt, vừa giải nóng hiệu quả.",
                         Ingredients = "-Nguyên liệu:"
                                        + "Socola: 300g (đen, trắng hoặc màu tùy thích)"
                                        + "Đường: Thay đổi tùy khẩu vị"
                                        + "Kem vị tùy thích: 1kg ( Dâu, chanh, nho,…)"
                                        + "-Dụng cụ: Khuôn bánh Trung thu",
                         Recipe = "-Thực hiện:"
                                    + "Bước 1: Làm chảy socola: +Bạn có thể sử dụng 2 cách để làm chảy socola"
                                    + "+Chưng cách thủy: Bẻ nhỏ socola, cho vào bát và hấp cách thủy đến khi socola tan gần hết đồi đem ra khuấy đều."
                                    + "+Sử dụng lò vi sóng: Bẻ nhỏ socola, cho vào lò vi sóng khoảng 1 phút rồi đem ra khuấy đều."
                                    + "Bước 2: Đổ 2/3 lượng socola vừa đun chảy vào khuôn, xoay nhẹ nhàng cho socola giàn đều xung quanh mặt và thành khuôn. (nếu dùng khuôn nhỏ thì chia tỉ lệ cho phù hợp, 2 phần socola sẽ dành cho mặt và thành khuôn, một phần dành cho đáy khuôn), Cho khuôn vào trong ngăn mát tủ lạnh đến khi socola đông hẳn."
                                    + "Bước 3: Sau khi socola đông, lấy khuôn ra, cho kem vào lấp gần đầy khuôn (để kem cách đáy khuôn khoảng 2 phân để lát đổ lớp socola đáy bánh. Dùng dao trà láng hoặc thìa dàn đều kem cho phẳng rồi cho vào ngăn đông tủ lạnh cho kem cứng hẳn. Nếu bạn thích chiếc bánh trung thu kem lạnh của mình có nhân như trứng muối thì có thể sử dụng loại kem có màu vàng (kem xoài, chanh leo,…) để giả trứng muối mix với các loại kem khác. Bạn đổ một lớp kem bằng 1/2 lòng khuôn, lấy một viên kem tròn kích thước nhỏ (đã để đông cứng trong tủ lạnh) đặt vào giữa rồi lại đổ nốt 1/2 lượng kem còn lại để lấp đầy. Cho vào ngăn đông tủ lạnh chờ kem đông cứng."
                                    + "Bước 4: Đổ nốt phần socola còn lại vào khuôn, giàn thật đều và phẳng, phủ kín đáy khuôn. Tiếp tục cho vào ngăn đông tủ lạnh cho socola và kem đông hẳn. Vậy là bạn đã hoàn thành những chiếc bánh Trung thu kem lạnh siêu đặc biệt cho mùa Trung thu năm nay rồi, chỉ còn bước là cắt ra và thưởng thức thôi.Còn chần chừ gì nữa mà không thử ngay hôm nay.Đảm bảo ai cũng mê li món bánh Trung thu của bạn.",
                         Note = "",
                         Price = 1,
                         Category = "Fee"
                     },
                     new Product
                     {
                         Name = "Kem bơ đậu phộng",
                         Image = "https://media.cooky.vn/recipe/g2/13106/s320x320/recipe-635633684052795723.jpg",
                         Description = "Kem bơ đậu phộng vừa bùi lại rất thanh, không chỉ hợp để ăn ngày nóng mà trong những hôm mưa lạnh ăn cũng thích lắm cơ!",
                         Ingredients = "Nguyên liệu: " + "1- 2 chén sữa (Blue Diamond Almond Breeze Original Almondmilk), bạn có thể thay thế bằng sữa tươi nhé."
                                        + "1 chén sữa chua Hy Lạp (non-fat plain Greek yogurt)"
                                        + "1/2 chén bơ đậu phộng"
                                        + "1/2 chén mật ong"
                                        + "1/3 chén bột cacao không đường"
                                        + "2 muỗng cà phê vani"
                                        + "Que gỗ và khuôn làm kem",
                         Recipe = "-Thực hiện:"
                                        + "Bước 1: Sơ chế nguyên liệu làm kem bơ đậu phộng: bạn để sữa chua và bơ ở nhiệt độ phòng."
                                        + "Bước 2: Các bước thực hiện làm kem bơ đậu phộng:"
                                        + "+ Bạn ho tất cả các nguyên liệu vào một máy xay sinh tố hoặc một âu trộn lớn, bạn dùng muỗng trộn thật đều cho các thành phần thật hòa quyện với nhua. Nếu bạn thích ăn ngọt thì bạn có thể cho thêm mật ong hoặc đường cho vừa miệng. Tiếp đó ban đổ hỗn hợp kem vào từng khuôn rồi cắm một que gỗ ở trung tâm."
                                        + "+Bạn đặt khuôn vào trong ngăn đá tủ lạnh khoảng 6-8h nhé."
                                        + "+Bây giờ thì lấy kem ra ngoài và thưởng thức thôi nào. Thật đơn giản phải không bạn.",
                         Note = "*Lưu ý: + Nếu không có que gỗ, các bạn có thể cho kem vào khuôn hình chữ nhật đều được. Khi cho vào tủ lạnh cứ khoảng 1-2h, các bạn lấy hộp kem ra ngoài và đảo đều lên rồi đặt lại vào tủ lạnh. Lặp đi lặp lại bước làm này 2-3 lần sẽ giúp cho món kem dẻo như khi được làm bằng máy đó nha."
                                    + "+ Thay bằng sữa tươi bình thường nếu bạn không kiếm được loại sữa như công thức nhé.",
                         Price = 1,
                         Category = "Fee"
                     },
                     new Product
                     {
                         Name = "Kem táo",
                         Image = "https://bizweb.dktcdn.net/thumb/large/100/311/965/articles/kem-vani-tao-do-giai-nhiet-ngay-he-thumbnail.jpg?v=1532189430127",
                         Description = "Theo một số chuyên gia khuyên nên ăn từ 1 quả táo mỗi ngày sẽ duy trì thanh xuân. Thay vào đó bạn ăn kem táo cũng là một cách thay đổi lạ miệng.",
                         Ingredients = "-Nguyên liệu:"
                                        + "Táo: 4 quả"
                                        + "Sữa đặc: 2 hộp nhỏ (loại sữa vỉ ông thọ)"
                                        + "Kem tươi: 200ml (nên chọn loại kem có độ béo trên 30%)"
                                        + "Sữa tươi: 400ml (chọn loại có đường hay không đường là tùy bạn)"
                                        + "Đường trắng: 60g"
                                        + "Nước cốt chanh 2 muỗng cà phê"
                                    + "-Dụng cụ làm kem táo: Dao, thớt, máy làm kem, máy xay sinh tố, máy đánh trứng,…",
                         Recipe = "-Thực hiện:"
                                    + "Bước 1: Trước khi bắt tay vào làm kem, bạn cho hộp nhựa dùng để làm kem vào ngăn đá tủ lạnh trước 1 tiếng nhé (cách này giúp làm kem nhanh hơn)."
                                    + "Bước 2: Đầu tiên, bạn rửa sạch quả táo, gọt hết vỏ, cắt nhỏ, bỏ hạt rồi cho vào máy xay sinh tố xay thật nhuyễn cùng với sữa tươi, đường và nước cốt chanh."
                                    + "Bước 3: Bạn cho kem tươi ra âu đánh bông lên, sau đó cho từ từ hỗn hợp táo xay nhuyễn vào trộn thật đều lên để được hỗn hợp nhuyễn, mịn."
                                    + "Bước 4: Lấy hộp nhựa đã làm lạnh ra, cho hỗn hợp nhuyễn, mịn trên vào hộp rồi để vào ngăn đá tủ lạnh. Sau 2 tiếng lấy hộp kem ra đảo một lần để kem táo được tươi xốp và không bị đá dăm, lặp lại thao tác này khoảng 3 lần là được. Đó là cách làm kem táo nếu bạn không có máy làm kem, còn nếu nhà có sẵn máy làm kem, bạn hãy để hỗn hợp kem táo thật lạnh rồi cho vào máy quay kem, quay 30 phút là xong nhé!",
                         Note = "",
                         Price = 1,
                         Category = "Fee"
                     },
                     new Product
                     {
                         Name = "Kem xoài chanh leo",
                         Image = "http://www.savourydays.com/wp-content/uploads/2012/05/KemChanhLeo.jpg",
                         Description = "Viên kem mát lạnh với vị ngọt thanh đặc trưng của xoài kết hợp cùng vị chua nhẹ của chanh dây. Đây đích thị là món kem dành cho những ngày hè oi ả",
                         Ingredients = "-Nguyên liệu: "
                                        + "Xoài chín: 3 quả"
                                        + "Sữa chua: 2 hộp"
                                        + "Sữa đặc: 20ml"
                                        + "Nước chanh leo:2 quả"
                                        + "Đường: 100g"
                                        + "Nước: 160ml"
                                        + "-Dụng cụ : Khuôn làm kem",
                         Recipe = "-Thực hiện:"
                                    + "Bước 1: Các bạn làm mát hộp làm kem, nhất là hộp nhựa nên cho vào ngăn đá để làm lạnh trước."
                                    + "Bước 2: Đường với nước đun trên bếp ở lửa vừa. Đun đến khi đường tan hết và sôi lăn tăn thì bắc xuống. Làm mát trong tủ lạnh."
                                    + "Bước 3: Xoài bỏ vỏ lấy phần thịt, chanh leo rây qua rây để loại bỏ hạt."
                                    + "Bước 4: Cho tất cả các nguyên liệu và nước đường lạnh vào máy xay sinh tố xay nhuyễn nếu các bạn thấy chưa ngọt thì có thể cho thêm đường vì còn tùy vào độ ngọt của xoài nữa mà :)."
                                    + "Bước 5: Cho hỗn hợp xoài vào các khuôn làm kem để vào ngăn đá tủ lạnh 2-2,5 tiếng là kem đã đông lại và măm măm được.",
                         Note = "**Lưu ý: Khi lấy kem ra khỏi khuôn, các bạn ngâm khuôn kem vào chậu nước lạnh vài giây là sẽ lấy kem ra khỏi khuôn được nhé.",
                         Price = 1,
                         Category = "Fee"
                     },
                     new Product
                     {
                         Name = "Kem Yaourt Bơ",
                         Image = "https://lh3.googleusercontent.com/proxy/B-uPPBskQRDgtZQ6u1DHYtKrrA3qWu4RYxyLwZ4_ylr-5NCzByKTu8MARnn5XTgu2iEYlmFJzrEqtBtMRN3P_75GuRsHCvij5NHRnIdD2ewjhsegw5EWogZmQmc0-42hgQqvOcPn",
                         Description = "Cách làm kem Yourt bơ đơn giản dễ làm. Món kem ngon lành với vị béo ngậy của trái bơ và chua dịu của sữa chua sẽ khiến bé nhỏ thích mê.",
                         Ingredients = "-Nguyên liệu:"
                                        + "2 hộp sữa chua có đường"
                                        + "1 lít sữa tươi không đường"
                                        + "250ml sữa đặc"
                                        + "2 quả bơ chín",
                         Recipe = "-Thực hiện: "
                                    + "+Cách lấy thịt bơ nhanh: Dùng dao cắt quả bơ làm đôi theo chiều ngang, sau đó tách quả bơ ra. Lấy hột bơ bằng cách găm dao vào hột quả bơ và lắc nhẹ tay hoặc xoay nhẹ tay để lấy hột ra ngoài.Tiếp đến, bạn cắt bơ thành từng miếng nhỏ và dùng tay lột nhẹ phần vỏ ra là được. Bạn có thể dùng muỗng để nạo phần thịt bơ, nhưng cách này thường không lấy hết được phần màu xanh lá đậm của quả bơ. Phần xanh lá đậm chứa nhiều chất dinh dưỡng nhất. Bơ bạn có thể cắt thành những miếng vuông nhỏ vừa ăn, hoặc cho vào cối xay sinh tố xay nhuyễn trộn với phần sữa chua cái."
                                    + "+Cách làm sữa chua ngon: Chuẩn bị một cái nồi lớn, cho các nguyên liệu gồm sữa tươi, sữa đặc vào. Dùng muỗng gỗ khuấy đều cho sữa đặc hòa tan hết. Sau đó bạn bắt lên bếp đun với lửa vừa làm ấm sữa khoảng 80 – 85 độ C. Tiếp đến, trộn 2 hũ sữa chua vào hỗn hợp sữa, khuấy đều và lọc qua rây để sữa chua mịn hơn.Bước tiếp theo của cách làm sữa chua bơ là rót sữa chua cái vào từng hũ đựng thũy tinh, đậy nắp kín. Cho vào nồi đựng lớn, đổ thêm nước sôi 80 độ C ngập ½ hũ đựng. Thời gian ủ sữa chua khoảng 6 – 8 tiếng. Cứ mỗi 30 phút, bạn thay nước ủ 1 lần. Khi ủ đã đủ thời gian, cho sữa chua vào trong ngăn mát tủ lạnh làm lạnh thêm 1 – 2 giờ là có thể ăn được."
                                    + "+Cách thưởng thức sữa chua bơ: Dùng phần bơ đã sơ chế ở bước 1, bạn cho lên trên bề mắt sữa chua đã ủ lạnh và thưởng thức. Hoặc bạn có thể dùng phần bơ xay nhuyễn trộn đều lên để sữa chua bơ có màu xanh lá đẹp mắt."
                                    + "Ngoài ra, bạn có thể cho thêm một ít nước cốt chanh trộn với sữa chua bơ để cân bằng vị."
                                    + "+Cách bảo quản sữa chua bơ đúng cách: "
                                    + "– Đối với sữa chua bơ để riêng sữa chua và bơ: bạn có thể bảo quản trong ngăn mát tủ lạnh, từ 4 đến 5 ngày. Khi ăn chỉ cần kết hợp hai nguyên liệu cùng với nhau. Hoặc bạn có thể để quả bơ sẵn trong tủ lạnh, mang ra cắt nhỏ hoặc dằm trước khi ăn là được."
                                    + "– Đối với bơ trộn sữa chua: Vì bên trong sữa chua có bơ nên dễ bị lên men, có vị chua. Bạn chỉ nên sử dụng trong khoảng 1 – 2 ngày.",
                         Note = "",
                         Price = 1,
                         Category = "Fee"
                     }

                );
                context.SaveChanges();
            }
        }
    }
}