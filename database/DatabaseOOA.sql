use iclinic;

create table BENH_NHAN
(
	MaBenhNhan varchar(15) primary key,
	TenBenhNhan	nvarchar(255),
	GioiTinh tinyint,
	NgaySinh SmallDateTime, 
	NgheNghiep nvarchar(255),
	DiaChi nvarchar(255),
	SoDT varchar(20),
	TienSuBenh nvarchar(255), 
	NgayTiepNhan SmallDateTime
)

create table DON_VI_TINH 
(
	MaDonViTinh varchar(15) primary key,
	TenDonViTinh nvarchar(255)
)

create table THUOC
(
	MaThuoc varchar(15) primary key,
	TenThuoc nvarchar(255),
	DonGia decimal(15, 5),
	DonViTinh varchar(15),
	SoLuong int,
	constraint FK_THUOC_DVT foreign key (DonViTinh) references DON_VI_TINH(MaDonViTinh)
)

--Bac si, y ta, tiep tan, ...
create table CHUC_VU
(
	MaChucVu varchar(15) primary key,
	TenChucVu nvarchar(255)
)


--khoa kham benh, xet nghiem, nha thuoc, tiep tan
create table BO_PHAN 
(
	MaBoPhan varchar(15) primary key,
	TenBoPhan nvarchar(255),
	TruongBoPhan varchar(15), --add constraint
	constraint FK_BOPHAN_NHANVIEN foreign key (TruongBoPhan) references NHAN_VIEN(MaNhanVien)
)

create table PHONG 
(
	--ma, ten, bo phan
	MaPhong varchar(15) primary key,
	TenPhong nvarchar(255),
	MaBoPhan varchar(15),
	constraint FK_PHONG_BOPHAN foreign key (MaBoPhan) references BO_PHAN(MaBoPhan)
)

create table NHAN_VIEN 
(
	MaNhanVien varchar(15) primary key,
	TenNhanVien nvarchar(255),
	--Them gioi tinh, ngay sinh
	GioiTinh tinyint,
	NgaySinh SmallDateTime,
	SoDT varchar(20),
	DiaChi varchar(255),
	MaChucVu varchar(15), 
	MaPhong varchar(15), 
	constraint FK_NHANVIEN_PHONG foreign key (MaPhong) references PHONG(MaPhong),
	constraint FK_NHANVIEN_CHUCVU foreign key (MaChucVu) references CHUC_VU(MaChucVu)
)

create table PHIEU_KHAM_BENH
(
	MaPhieuKhamBenh varchar(15) primary key,
	MaBenhNhan varchar(15),
	MaBacSiKham varchar(15),
	NgayKham SmallDateTime,
	--MaDonThuoc varchar(15),
	ChanDoan nvarchar(255),
	LoiDan nvarchar(255),
	constraint FK_PHIEUKHAMBENH_BENHNHAN foreign key (MaBenhNhan) references BENH_NHAN(MaBenhNhan),
	constraint FK_PHIEUKHAMBENH_NHANVIEN foreign key (MaBacSiKham) references NHAN_VIEN(MaNhanVien)
)

create table CHI_TIET_PHIEU_KHAM_BENH 
(
	MaPhieuKhamBenh varchar(15),
	Ma
)

create table DON_THUOC 
(
	MaDonThuoc varchar(15) primary key,
	MaPhieuKhamBenh varchar(15),
	MaBacSi varchar(15),
	NgayKeDon SmallDateTime,
	TongTien Decimal(15, 5)
	constraint FK_DONTHUOC_BACSI foreign key (MaBacSi) references NHAN_VIEN(MaNhanVien),
	constraint FK_DONTHUOC_PHIEUKHAMBENH foreign key (MaPhieuKhamBenh) references PHIEU_KHAM_BENH(MaPhieuKhamBenh)
)

create table CHI_TIET_DON_THUOC
(
	MaDonThuoc varchar(15),
	MaThuoc varchar(15),
	DonGia Decimal(15, 5),
	DonViTinh varchar(15),
	SoLuong int,
	--Ngay dung: so luong thuoc dung trong 1 ngay,
	NgayDung int,
	Sang int,
	Trua int,
	Chieu int,
	Toi int,
	constraint FK_CHITIETDONTHUOC_THUOC foreign key (MaThuoc) references THUOC(MaThuoc),
	constraint FK_CHITIETDONTHUOC_DONTHUOC foreign key (MaDonThuoc) references DON_THUOC(MaDonThuoc),
	constraint PK_CHITIETDONTHUOC primary key (MaDonThuoc, MaThuoc)
)

create table PHIEU_YEU_CAU_KHAM
(
	MaPhieuYeuCauKham varchar(15) primary key,
	MaBenhNhan varchar(15),
	MaBacSiChiDinh varchar(15),
	MaBacSiThucHien varchar(15),
	ThoiGianThucHien SmallDateTime, 
	ChanDoan nvarchar(255), 
	LoiDan nvarchar(255),
	NgayLap SmallDateTime,
	constraint FK_PHIEUYEUCAUKHAM_BENHNHAN foreign key (MaBenhNhan) references BENH_NHAN(MaBenhNhan),
	constraint FK_PHIEUYEUCAUKHAM_NHANVIEN foreign key (MaBacSiChiDinh) references NHAN_VIEN(MaNhanVien),
	constraint FK_PHIEUYEUCAUKHAM_NHANVIEN foreign key (MaBacSiThucHien) references NHAN_VIEN(MaNhanVien)
)

create table PHIEU_YEU_CAU_XN
(
	MaPhieuYeuCauXN varchar(15) primary key,
	MaBenhNhan varchar(15),
	MaBacSiChiDinh varchar(15),
	MaBacSiThucHien varchar(15),
	ThoiGianThucHien SmallDateTime,
	ChanDoan nvarchar(255), 
	LoiDan nvarchar(255),
	NgayLap SmallDateTime,
	constraint FK_PHIEUYEUCAUXN_BENHNHAN foreign key (MaBenhNhan) references BENH_NHAN(MaBenhNhan),
	constraint FK_PHIEUYEUCAUXN_NHANVIEN foreign key (MaBacSiChiDinh) references NHAN_VIEN(MaNhanVien),
	constraint FK_PHIEUYEUCAUXN_NHANVIEN foreign key (MaBacSiThucHien) references NHAN_VIEN(MaNhanVien)
)
