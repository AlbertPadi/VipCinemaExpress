create database VipCinemaExpressDB

use VipCinemaExpressDB
select * from Cines
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
select *from CinesSalasDetalle
create table CinesSalasDetalle(
			CinesSalasId int primary key identity,
			CineId int References Cines(CineId),
			NombreSala varchar(40),
			NoAsiento int,
			EsActiva int
			
)
drop table CinesSalasDetalle
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
create table PeliculaDetalle(
			PeliculaDetalleId int primary key identity,
			PeliculaId int References Peliculas(PeliculaId),
			CineId int References Cines(CineId),
			CinesSalasId int References CinesSalasDetalle(CinesSalasId)
)
drop table PeliculaDetalle
go
create table Carteleras(
			CarteleraId int primary key identity,
			PeliculaId int References Peliculas(PeliculaId)
)

go
create table Reservaciones(
			ReservacionId int primary key identity,
			CineId int References Cines(CineId),
			UsuarioId int References Usuarios(UsuarioId),
			SalaId int References CinesSalasDetalle(CinesSalasId),
			Fecha datetime,
			Cantidad int,
			Monto float
)

go
create table ReservacionesDetalle(
			ReservacionDetalleId int primary key identity,
			ReservacionId int References Reservaciones(ReservacionId),
			PeliculaId int References Peliculas(PeliculaId)
)