create database VipCinemaExpressDB

use VipCinemaExpressDB

create table Cines(
			CineId int primary key identity,
			Nombre varchar(40),
			Ciudad varchar(40),
			Direccion varchar(40),
			Telefono varchar(20),
			Email varchar(40)
)

create table Salas(
			SalaId int primary key identity,
			CineId int References Cines(CineId),
			Descripcion varchar(50),
			NoAsiento int
)

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
			Imagen image,
			Video varchar(300)
)
insert into Peliculas(Genero, Clasificacion, Idioma, Subtitulo, Director, Actores, Activa, FechaInicio, FechaFin, Video) values('asdf', 'dsfgw', 'Espanor', 1, 'Guancho', 'Pepe, Yano, Haron', 0, '254521', '5465', 'sd/D')
select *from Peliculas
drop table Peliculas
create table Carteleras(
			CarteleraId int primary key identity,
			PeliculaId int References Peliculas(PeliculaId)
)
drop table Carteleras

select * from Usuarios

create table Reservaciones(
			ReservacionId int primary key identity,
			CineId int References Cines(CineId),
			UsuarioId int References Usuarios(UsuarioId),
			SalaId int References Salas(SalaId),
			Cantidad int,
			Monto float
)
drop table Reservaciones
create table ReservacionesDetalle(
			ReservacionDetalleId int primary key identity,
			ReservacionId int References Reservaciones(ReservacionId),
			PeliculaId int References Peliculas(PeliculaId)
)
drop table ReservacionesDetalle