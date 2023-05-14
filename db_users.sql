create database db_users;



use db_users
go


create table Users
(
	id_users int not null identity(1,1) primary key,
	LSurname nvarchar(50) check (LSurname <> '') not null,
	LName nvarchar(50) check (LName  <> '') not null,
	LPobatkovi nvarchar(50) check (LPobatkovi  <> '') not null,
	LEmail nvarchar(50) check (LEmail  <> '') not null,
	LPhone int not null,
	LDateBrith date not null
);
go

insert into Users values
('Кириленко', 'Жора', 'Олександрович', '1234@gmail.com', 0995545687, '1996-02-05'),
('Сидоренко', 'Світлана', 'Олександрівна', '3454@gmail.com', 0899999987, '1990-06-05');
go
