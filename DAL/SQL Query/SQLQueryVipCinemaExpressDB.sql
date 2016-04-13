
create database VipCinemaExpressDB

Insert into ReservacionesDetalle(ReservacionId, Cantidad, Nombre, CineId, SalaId, Fecha, Monto) Values(16, 2, 'dos mas dos', 3, 12, '2016-07-04', 900) 

select * from Peliculas 
Select * from PeliculasDetalle
select * from Peliculas
select *from Cines
select *from cinesSalasDetalle

use VipCinemaExpressDB
update Usuarios set Tipo = 1 where UsuarioId = 15

select *from Usuarios
go
CREATE VIEW View_PeliculasDetalle
AS
Select pd.PeliculaDetalleId, pd.PeliculaId, pd.CineId, ci.Nombre as 'Nombre', pd.CinesSalasId
FROM PeliculasDetalle pd INNER JOIN Cines ci ON pd.CineId = ci.CineId

GO
SELECT * FROM View_PeliculasDetalle


create table Cines(
			CineId int primary key identity,
			Nombre varchar(40),
			Ciudad varchar(40),
			Direccion varchar(40),
			Telefono varchar(20),
			Email varchar(40),
			CantidadSalas int
)

go

create table CinesSalasDetalle(
			CinesSalasId int primary key identity,
			CineId int References Cines(CineId),
			NombreSala varchar(40),
			NoAsiento int,
			EsActiva int
			
)

go
create table Usuarios(
			UsuarioId int primary key identity,
			Tipo int,
			Nombres varchar(40),
			Apellidos varchar(40),
			Direccion varchar(40),
			Telefono varchar(20),
			Celular varchar(20),
			Email varchar(40),
			Usuario varchar(40),
			Contrasena varchar(30)
)

go
select *from Peliculas
create table Peliculas(
			PeliculaId int primary key identity,
			Nombre varchar(40),
			Genero varchar(25),
			Clasificacion varchar(30),
			Idioma varchar(25),
			Subtitulo bit,
			Director varchar(40),
			Actores varchar(500),
			Activa bit,
			FechaInicio datetime,
			FechaFin datetime,
			Duracion time,
			Precio float,
			Imagen nvarchar(100),
			Video nvarchar(350)
)

go
create table PeliculasDetalle(
			PeliculaDetalleId int primary key identity,
			PeliculaId int References Peliculas(PeliculaId),
			CineId int References Cines(CineId),
			CinesSalasId int References CinesSalasDetalle(CinesSalasId)
)
select *from PeliculasDetalle
go
create table Carteleras(
			CarteleraId int primary key identity,
			PeliculaId int References Peliculas(PeliculaId)
)
select *from Peliculas

go
create table Reservaciones(
			ReservacionId int primary key identity,
			UsuarioId int References Usuarios(UsuarioId),
			MontoTot float
)
drop table Reservaciones
drop table ReservacionesDetalle
go
create table ReservacionesDetalle(
			ReservacionDetalleId int primary key identity,
			ReservacionId int References Reservaciones(ReservacionId),
			Cantidad int,
			Nombre varchar(40),
			SalaId int References CinesSalasDetalle(CinesSalasId),
			CineId int References Cines(CineId),
			Fecha datetime,
			Monto float
)

