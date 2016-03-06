create database VipCinemaExpressDB

use VipCinemaExpressDB

create table Cines(
			CineId int primary key identity,
			Nombre varchar(40),
			Ciudad varchar(40),
			Direccion varchar(40),
			Telefono varchar(20),
			Email varchar(40),
			CantidadSalas int
)
select * from Cines
go
insert into CinesSalasDetalle (CineId, NombreSala, NoAsiento, EsActiva) Values(5, 'hgvh', 200, 1)

go
create table CinesSalasDetalle(
			CinesSalasId int primary key identity,
			CineId int References Cines(CineId),
			NombreSala varchar(40),
			NoAsiento int,
			EsActiva int
			
)
select *from CinesSalasDetalle


drop table CinesSalasDetalle
Select SalaId from CinesSalasDetalle
drop table CinesSalasDetalle
select *from CinesSalasDetalle
go
create table Usuarios(
			UsuarioId int primary key identity,
			Nombres varchar(40),
			Apellidos varchar(40),
			Direccion varchar(40),
			Telefono varchar(20),
			Celular varchar(20),
			Email varchar(40),
			Usuario varchar(40),
			Contrasena varchar(30)
)
select *from Usuarios
go
Select S.SalaId, S.Descripcion from CinesSalasDetalle CSD inner join Salas S on S.SalaId = CSD.SalaId where CSD.CineId = 6
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
			Precio float,
			Imagen nvarchar(350),
			Video nvarchar(350)
)
drop table Peliculas
go
create table Carteleras(
			CarteleraId int primary key identity,
			PeliculaId int References Peliculas(PeliculaId)
)
drop table Carteleras
go
create table Reservaciones(
			ReservacionId int primary key identity,
			CineId int References Cines(CineId),
			UsuarioId int References Usuarios(UsuarioId),
			SalaId int References CinesSalasDetalle(CineSalaId),
			Cantidad int,
			Monto float
)
drop table Reservaciones
go
create table ReservacionesDetalle(
			ReservacionDetalleId int primary key identity,
			ReservacionId int References Reservaciones(ReservacionId),
			PeliculaId int References Peliculas(PeliculaId)
)
drop table ReservacionesDetalle