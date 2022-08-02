# QL_BanHang-.NET

create database QL_BanDH

drop database QL_BanDH

go
use [QL_BanDH]

create table HANGHOA
(
	MaHang nchar(10),
	TenHang nvarchar(100),
	MoTa nvarchar(1000),
	SL int,
	DG int,
	constraint PK_HANGHOA primary key(MaHang)
)
create table CHUCVU
(
MaCV nchar(10) primary key,
TenCV nvarchar(50),
)

create table HOADON
(
MaHD nchar(10),
SLXuat int,
NgayTao date,
TenNV nvarchar(50),
MaNV nchar(10),
constraint PK_HOADON primary key(MaHD,MaNV)
)

create table NHANVIEN
(
MaNV nchar(10),
TenNV nvarchar(50),
DiaChi nvarchar(50),
DienThoai nchar(10),
Luong nchar(50),
MaCV nchar(10),
constraint PK_NHANVIEN primary key(MaNV),
constraint FK_CHUCVU_NHANVIEN foreign key(MaCV) references CHUCVU(MaCV),
constraint FK_HOADON_NHANVIEN foreign key(MaHD) references HOADON(MaHD)
)
create table KHACHHANG
(
MaKH nchar(10) primary key,
TenKH nvarchar(50),
DiaChi nvarchar(50),
DienThoai nchar(10),

)

create table NCC
(
MaNCC nchar(10) primary key,
TenNCC nvarchar(50),
SDT nchar(10),
DiaChi nvarchar(50),

)





create table XUATKHO
(
SoPhieuX nchar(10) primary key,
NgayXuat datetime,
MaKH nchar(10),
LyDoXuat nvarchar(50),
MaNV nchar(10),
constraint FK_KHACHHANG_XUATKHO foreign key(MaKH) references KHACHHANG(MaKH),
constraint FK_NHANVIEN_XUATKHO foreign key(MaNV) references NHANVIEN(MaNV)
)



create table XUATKHO_CT
(
SoPhieuX nchar(10) ,
STT int,
MaHang nchar(10) ,
SLXuat int,
DGXuat int,
MaHD nchar(10),
constraint PK_XUATKHO_CT primary key (SoPhieuX,MaHang, MaHD),
constraint FK_XUATKHO_CT_XUATKHO foreign key(SoPhieuX) references XUATKHO(SoPhieuX),
constraint FK_XUATKHO_CT_HANGHOA foreign key(MaHang) references HANGHOA(MaHang)
)


create table NHAPHANG
(
SoPhieuN nchar(10) primary key,
MaNCC nchar(10),
NgayNhap datetime,
ThanhTien float,
MaNV nchar(10),
constraint FK_NHANVIEN_NHAPHANG foreign key(MaNV) references NHANVIEN(MaNV),
constraint FK_NCC_NHAPHANG foreign key(MaNCC) references NCC(MaNCC)
)
create table NHAPHANG_CT
(
SoPhieuN nchar(10),
MaHang nchar(10),
SLNhap int,
DGNhap int,
constraint PK_NHAPHANG_CT primary key(SoPhieuN, MaHang),
constraint FK_NHAPHANG_NHAPHANG_CT foreign key(SoPhieuN) references NHAPHANG(SoPhieuN),
constraint FK_HANGHOA_NHAPHANG_CT foreign key(MaHang) references HANGHOA(MaHang)
)
create table BAOHANH
(
SoPhieuBH nchar(10),
MaHang nchar(10),
TenHang nvarchar(100),
MaKH nchar(10),
TenKH nvarchar(50),
DiaChi nvarchar(50),
DienThoai nchar(10),
ThoiGianBaoHang int,
NgayMua date,
NgayNhanBH date,
NgayHenTra date,
LoaiSuaChua nvarchar(50),
SL int,
PHI int,
constraint PK_BAOHANH primary key(SoPhieuBH, MaHang, MaKH),
constraint FK_BAOHANH_HANGHOA foreign key(MaHang) references HANGHOA(MaHang),
constraint FK_BAOHANH_KHACHHANG foreign key(MaKH) references KHACHHANG(MaKH)
)

--create table BAOHANH_CT
--(
--SoPhieuBH nchar(10),
--MaHang nchar(10),
--SL int,
--PHI int,
--constraint PK_BAOHANH_CT primary key(SoPhieuBH, MaHang),
--constraint FK_BAOHANH_CT_BAOHANH foreign key(SoPhieuBH) references BAOHANH(SoPhieuBH),
--constraint FK_BAOHANH_CT_HANGHOA foreign key(MaHang) references HANGHOA(MaHang)
--)




go
insert into HANGHOA values ('HH02', N'ĐỒNG HỒ CASIO MTP-1374L-1AVDF NAM PIN DÂY DA', N'Đồng hồ nam CASIO MTP-1374L-1AVDF thay cho thiết kế cửa sổ lich cổ điển là thiết kế mới lịch ngày và thứ đều sử dụng đồng hồ kim mang tính hiện đại, trẻ trung. Nổi bật trên nền mặt số đen là thiết kế phá cách kim giây đỏ làm điểm nhấn nổi bật. Dây đeo bằng da tạo vân cá sấu nổi bật với hai đường chỉ may trắng tinh xảo.', 10, 1677000)
insert into HANGHOA values ('HH03', N'ĐỒNG HỒ CITIZEN AU1080-20A NAM ECO-DRIVE DÂY VẢI', N'Đồng hồ nam Citizen AU1080-20A nổi bật Pin sử dụng công nghệ hiện đại Eco-Drive (Năng Lượng Ánh Sáng), với thiết kế theo phong cách thời trang với dây đeo chất liệu bằng vải tông màu kem trẻ trung.', 15, 5000000)
insert into HANGHOA values ('HH04', N'ĐỒNG HỒ LOUIS ERARD 13900AA05.BDC102 NAM PIN DÂY DA', N'Đây là dòng sản phẩm tuyệt vời cho những người đang tìm kiếm chiếc đồng hồ được thiết kế riêng mang đầy đủ sự “chất” Vintage cho đến hiện nay, đó là “chất cổ điển” và chỉ là “cổ điển” tinh khiết.', 5, 18195300)
insert into HANGHOA values ('HH05', N'ĐỒNG HỒ OLYM PIANUS OP99141-71AGSK TRẮNG NAM TỰ ĐỘNG DÂY INOX', N'Mẫu đồng hồ Olym Pianus OP99141-71AGSK vẻ ngoài tinh tế sang trọng ấn tượng với kiểu thiết kế độc đáo đến từ ô chân kính phô diễn ra 1 phần trải nghiệm hoạt động của bộ máy cơ đầy nam tính.', 11, 1098000)
insert into HANGHOA values ('HH06', N'ĐỒNG HỒ ORIENT FSTAA002W0 NAM PIN DÂY DA', N'Đồng hồ Orient FSTAA002W0 có vỏ kim loại phủ màu vàng sang trọng, kim chỉ và vạch số thanh mãnh nổi bật trên nền số, ô lịch ngày vị trí 3h tinh tế, dây đeo bằng chất liệu da cao cấp màu nâu đem lại phong cách lịch lãm, sang trọng cho phái mạnh', 15, 2737000)
insert into HANGHOA values ('HH07', N'ĐỒNG HỒ SEIKO SGEG99P1 NAM PIN DÂY DA', N'Đồng hồ Seiko SGEG99P1 dành cho nam, mặt đồng hồ màu đen, chữ số La Mã lớn màu trắng, vỏ thép không gỉ, dây da màu đen, mặt kính Sapphire chịu lực chống trầy, 1 ô lịch hiển thị ngày.', 7, 3684000)
insert into HANGHOA values ('HH08', N'ĐỒNG HỒ TISSOT T063.907.11.058.00 NAM TỰ ĐỘNG DÂY INOX', N'Giản dị và thanh lịch đến từ mẫu đồng hồ Tissot T063.907.11.058.00, được gia công tạo hình với kiểu dáng mỏng tạo nên vẻ tinh tế đầy sang trọng cùng chi tiết kim chỉ vạch số được bao phủ vàng hồng.', 6, 2194000)
insert into HANGHOA values ('HH09', N'ĐỒNG HỒ CASIO GA-110GB-1ADR NAM PIN DÂY NHỰA', N'Đồng hồ nam CASIO GA-110GB-1AVDF có thiết kế mới sử dụng kim loại màu vàng làm vạch số và kim nổi bật, sang trọng hơn so với thiết kế cũ nên mẫu GA-110GB-1AVDF rất được lòng giới trẻ hiện nay.', 9, 10000000)
insert into HANGHOA values ('HH10', N'ĐỒNG HỒ CANDINO C4433/3 NỮ PIN DÂY INOX', N'Đồng hồ dây da thời trang nữ Candino C4433/3, với mặt đồng hồ sang trọng nền trắng có ánh xà cừ có đính hạt pha lê viền xung quang, kính Sapphire, chữ số lớn dễ đọc, 3 kim chỉ màu bạc.', 10, 3996000)
insert into HANGHOA values ('HH11', N'ĐỒNG HỒ CASIO GA-100DE-2ADR NỮ PIN DÂY NHỰA', N'Mẫu G-Shock GA-100DE-2ADR với vẻ ngoài cá tính thích hợp cho những bạn trẻ năng động, phù hợp cho những chuyến đi phượt ấn tượng với khả năng chịu nước lên đến 20ATM, với đồng hồ điện tử hiện thị đa chức năng tiện ích.', 12, 4393000)
insert into HANGHOA values ('HH12', N'ĐỒNG HỒ CASIO LA670WL-1BDF NỮ PIN DÂY DA', N'Mẫu đồng hồ Casio LA670WL-1BDF  với thiết kế bộ máy nhỏ gọn tạo nên vẻ ngoài thanh mảnh nữ tính, vỏ máy tông màu vàng phối cùng mẫu dây đeo kim loại đen tăng thêm vẻ đẹp thời trang.', 10, 766000)
insert into HANGHOA values ('HH13', N'ĐỒNG HỒ CITIZEN EX1410-88A NỮ ECO-DRIVE DÂY INOX', N'Đồng hồ Citizen EX1410-88A có mặt số hình chữ nhật bầu tinh tế, kim chỉ và vạch số thanh mãnh nổi bật trên nền số màu trắng trang nhã, phần quai được đính pha lê Swarovski sang trọng mang đến vẻ thanh lịch, duyên dáng dành cho phái nữ.', 14, 6120000)
insert into HANGHOA values ('HH14', N'ĐỒNG HỒ DANIEL WELLINGTON DW00500001 NỮ PIN DÂY INOX', N'Mẫu đồng hồ nữ Daniel Wellington DW00500001 với nét đặc trưng giản dị đến từ thương hiệu Daniel Wellington với thiết kế bộ máy nhỏ gọn thanh mảnh kết hợp cùng mẫu dây đeo chất liệu vải mang phong cách trẻ trung.', 14, 4230000)
insert into HANGHOA values ('HH15', N'ĐỒNG HỒ OGIVAL OG385-032LW-T NỮ PIN DÂY INOX', N'Vẻ ngoài trẻ trung với phần mặt số được phối tông nền trắng có họa tiết thời trang nữ tính với vỏ máy mỏng chứa đựng một trải nghiệm nữ tính từ bộ may cơ là yếu tố tạo nên mẫu đồng hồ nữ Ogival', 11, 9384000)
insert into HANGHOA values ('HH16', N'ĐỒNG HỒ SKAGEN 885SSLB NỮ PIN DÂY DA', N'Đồng hồ độc đáo dành cho nữ giới Skagen 885SSLB, với vỏ đồng hồ là thép không gỉ, kiểu dáng xoáy, mặt đồng hồ có trắng, dây da màu đen cao cấp, còn có 2 kim chỉ tinh tế.', 10, 5900000)
insert into HANGHOA values ('HH17', N'ĐỒNG HỒ TISSOT T41.1.183.34 NỮ TỰ ĐỘNG DÂY INOX', N'Mẫu Tissot T41.1.183.34 vẻ ngoài giản dị của chiếc đồng hồ 3 kim nhưng lại khoác lên sự trang nhã với nền mặt số được phối tông màu trắng trước bề mặt kính Sapphire kết hợp cùng tổng thể chiếc đồng hồ kim loại màu bạc đầy sang trọng.', 10, 17640000)
insert into HANGHOA values ('HH18', N'ĐỒNG HỒ ĐÔI ALEXANDRE CHRISTIE AC8C26-1LK TRẮNG – AC8C26-1MK TRẮNG PIN DÂY INOX', N'ALEXANDRE CHRISTIE là thương hiệu đồng hồ chính hãng nổi tiếng của Nhật Bản với những thiết kế cầu kỳ và vô cùng tinh tế. Ngay từ khi ra đời mẫu đồng hồ đeo tay này đã nhanh chóng được mọi người yêu thích vì chất lượng tốt động cơ bền bỉ vô cùng sang trọng.', 12, 6080000)
insert into HANGHOA values ('HH19', N'ĐỒNG HỒ ĐÔI SUNRISE SG – SL1085.1601 PIN DÂY INOX', N'Khi mua cặp đồng hồ đôi Sunrise SG.SL1085.1601, quý khách sẽ được bảo hành toàn cầu 1 năm, ngoài ra quý khách sẽ được tặng gói bảo hành máy và thay pin miễn phí trọn đời tại cửa hàng chúng tôi.', 2, 4230000)
insert into HANGHOA values ('HH20', N'ĐỒNG HỒ ĐÔI OLYMPIA STAR OPA58012-07MSK TRẮNG – OPA58012-07LSK TRẮNG PIN DÂY INOX', N'Đồng hồ đôi Olym Pianus (Olympia Star) mặt đồng hồ vàng sang trọng với chất liệu thép không gỉ, dây đeo đờ mi cao cấp, còn có 3 kim chỉ và 1 lịch ngày.', 13, 6955000)

insert into KHACHHANG values('KH01', N'Nguyễn Văn Sơn',N'Hồ Chí Minh','0165124862')
insert into KHACHHANG values('KH02', N'Nguyễn Quốc Bảo',N'Hà Nội','0956412357')
insert into KHACHHANG values('KH03', N'Lê Văn Nghĩa',N'Cà Mau','0965412378')
insert into KHACHHANG values('KH04', N'Nguyễn Văn Dũng',N'Cần Thơ','0985642301')
insert into KHACHHANG values('KH05', N'Lệ Thị Hồng',N'Long An','0954123254')

insert into CHUCVU values('CV1', N'Quản Lý')
insert into CHUCVU values('CV2', N'Nhân viên thu ngân')
insert into CHUCVU values('CV3', N'Nhân viên kho')

insert into NHANVIEN values('NV01', N'Nguyễn Văn An',N'Hồ Chí Minh','0321456987',20000000,'CV1')
insert into NHANVIEN values('NV02', N'Nguyễn Văn Bảo',N'Cà Mau','0956412357',10000000,'CV1')
insert into NHANVIEN values('NV03', N'Lê Văn Chi',N'Hồ Chí Minh','0965412378',9000000,'CV2')
insert into NHANVIEN values('NV04', N'Hoàng Văn Dũng',N'Cần Thơ','0985642301',12000000,'CV2')
insert into NHANVIEN values('NV05', N'Nguyễn Thị Hồng',N'Long An','0954123254',14000000,'CV3')
insert into NHANVIEN values('NV06', N'Trần Văn Duy',N'Bến Tre','0937561235',21000000,'CV3')
insert into NHANVIEN values('NV07', N'Hồ Văn Giang',N'Vũng Tàu','0987463214',11000000,'CV3')

insert into NCC values ('1', N'ĐỒNG HỒ HT LUXURY', '0833743222', N'Quận Đống Đa, TP Hà Nội (TPHN)')
insert into NCC values ('2', N'CÔNG TY CỔ PHẦN WATCHSTORE VIỆT NAM', '0931892222', N'Tân Bình, Tp Hồ Chí Minh (TpHCM)')
insert into NCC values ('3', N'CÔNG TY TNHH SAO HỎA', '0903731769', 'Quận 2, TP Hồ Chí Minh (TPHCM)')
insert into NCC values ('4', N'CÔNG TY CỔ PHẦN TYP VIỆT NAM', '0956342567', N'Q. Hoàn Kiếm, TP Hà Nội (TPHN)')

insert into NHAPHANG values ('01','1','2022/03/21',16770000,'NV05')
insert into NHAPHANG values ('02','3','2022/05/01',150000000,'NV06')
insert into NHAPHANG values ('03','2','2022/02/02',181953000,'NV07')
insert into NHAPHANG values ('04','4','2022/01/13',10980000,'NV06')
insert into NHAPHANG values ('05','4','2022/03/11',27370000,'NV06')
insert into NHAPHANG values ('06','2','2022/04/20',86840000,'NV07')


insert into NHAPHANG_CT values ('01','HH02',10,1677000)
insert into NHAPHANG_CT values ('02','HH03',30,5000000)
insert into NHAPHANG_CT values ('03','HH04',10,18195300)
insert into NHAPHANG_CT values ('04','HH05',10,1098000)
insert into NHAPHANG_CT values ('05','HH06',10,2737000)
insert into NHAPHANG_CT values ('06','HH07',10,3684000)
insert into NHAPHANG_CT values ('06','HH09',5,10000000)

insert into XUATKHO values('XK01', '2022/05/06','KH01',N'Bán lẻ','NV01')
insert into XUATKHO values('XK02', '2022/07/06','KH02',N'Bán sĩ','NV02')
insert into XUATKHO values('XK03', '2022/05/022','KH03',N'Bán lẻ','NV02')
insert into XUATKHO values('XK04', '2022/01/06','KH04',N'Bán sĩ','NV01')
insert into XUATKHO values('XK05', '2022/05/05','KH05',N'Bán lẻ','NV01')

insert into XUATKHO_CT values('XK01',1,'HH05',2,1098000)
insert into XUATKHO_CT values('XK02',1,'HH06',15,1677000)
insert into XUATKHO_CT values('XK03',1,'HH04',2,18195300)
insert into XUATKHO_CT values('XK04',1,'HH07',20,3684000)
insert into XUATKHO_CT values('XK05',1,'HH02',2,1677000)

insert into BAOHANH values('BH01','HH02',N'ĐỒNG HỒ CASIO MTP-1374L-1AVDF NAM PIN DÂY DA','KH01',N'Nguyễn Văn Sơn',N'Hồ Chí Minh','0165124862',3,'2020/05/06','2022/05/22','2022/06/1',N'Bảo hành',1,0)
insert into BAOHANH values('BH02','HH05', N'ĐỒNG HỒ OLYM PIANUS OP99141-71AGSK TRẮNG NAM TỰ ĐỘNG DÂY INOX','KH05', N'Lệ Thị Hồng',N'Long An','0954123254',2, '2015/02/03','2022/05/21','2022/05/28',N'Dịch vụ',1,100000)

--insert into BAOHANH_CT values('BH01','HH02',1,0)
--insert into BAOHANH_CT values('BH02','HH05',1,100000)


--In phiếu bán hàng
select HANGHOA.MaHang, TenHang, KHACHHANG.MaKH,TenKH,DiaChi, XUATKHO_CT.SLXuat,DGXuat,SLXuat*DGXuat as ThanhTien
from HANGHOA, KHACHHANG, XUATKHO,XUATKHO_CT
where XUATKHO_CT.MaHang = HANGHOA.MaHang and XUATKHO_CT.SoPhieuX = XUATKHO.SoPhieuX and KHACHHANG.MaKH = XUATKHO.MaKH

--In báo cáo nhập xuất hàng tồn
select MaHang, TenHang, SL 
from HANGHOA

select HANGHOA.MaHang,TenHang,SL from HANGHOA


Update XUATKHO set NgayXuat = '2022/05/06',MaKH= 'KH01',LyDoXuat =N'Bán sĩ' where SoPhieuX = 'XK01'

--Tìm kiếm
select * from HANGHOA where MaHang = 'HH03'

