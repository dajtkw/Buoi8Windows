create database QuanlySV
use QuanlySV

drop database QuanlySV

create table Lop(
	MaLop char(3) not null,
	TenLop nvarchar(30) not null,

)

create table Sinhvien(
	MaSV char(6) not null,
	HotenSV nvarchar(30),
	NgaySinh datetime,
	MaLop char(3)
)

alter table Lop
	add constraint pk_MaLop primary key (MaLop)

alter table Sinhvien
	add constraint pk_MaSV primary key (MaSV),
		constraint fk_MaLop foreign key (MaLop) references Lop (MaLop)


insert into Lop (MaLop, TenLop)
values
('L01', N'Tâm Lý Học'),
('L02', N'Công nghệ thông tin');


insert into Sinhvien(MaSV, HotenSV, NgaySinh, MaLop)
values
('SV001', N'Nguyễn Văn Nam','2004-01-15' , 'L01'),
('SV002', N'Trần Hoài Bão','2003-02-16', 'L02'),
('SV003', N'Lê Thị Trúc','2004-03-20', 'L01'),
('SV004', N'Phạm Thị Nguyên Anh','2003-12-15', 'L02');

select * from Sinhvien