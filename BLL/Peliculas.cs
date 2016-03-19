﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DAL;
namespace BLL
{
    public class Peliculas : ClaseMaestra
    {
        public int PeliculaId { get; set; }
        public string Nombre { get; set; }
        public string Genero { get; set; }
        public string Clasificacion { get; set; }
        public string Idioma { get; set; }
        public int Subtitulo { get; set; }
        public string Director { get; set; }
        public string Actores { get; set; }
        public int Activa { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
        public TimeSpan Duracion { get; set; }
        public double Precio { get; set; }
        public string Imagen { get; set; }
        public string Video { get; set; }
        public List<PeliculasDetalle> Detalle;

        public Peliculas()
        {
            this.PeliculaId = 0;
            this.Genero = "";
            this.Clasificacion = "";
            this.Idioma = "";
            this.Subtitulo = 0;
            this.Director = "";
            this.Actores = "";
            this.Activa = 0;
            this.FechaInicio = "";
            this.FechaFin = "";
            this.Duracion = TimeSpan.Zero;
            this.Precio = 0;
            this.Imagen = string.Empty;
            this.Video = "";
            Detalle = new List<PeliculasDetalle>();
        }
        public void AddCinesSalas(int cineId, int cinaSalaId)
        {
            Detalle.Add(new PeliculasDetalle(cineId, cinaSalaId));
        }

        public override bool Insertar()
        {
            int retorno = 0;
            object identity;

            ConexionDb conexion = new ConexionDb();
            identity = conexion.ObtenerDatos(String.Format("Insert into Peliculas(Nombre, Genero, Clasificacion, Idioma, Subtitulo, Director, Actores, Activa, FechaInicio, FechaFin, Duracion, Precio, Imagen, Video) Values('{0}', '{1}', '{2}', '{3}', {4}, '{5}', '{6}', {7}, '{8}', '{9}', '{9}', {11}, '{12}', '{13}') select @@Identity", this.Nombre, this.Genero, this.Clasificacion, this.Idioma, this.Subtitulo, this.Director, this.Actores, this.Activa, this.FechaInicio, this.FechaFin, this.Duracion, this.Precio, this.Imagen, this.Video));

            int.TryParse(identity.ToString(), out retorno);
            this.PeliculaId = retorno;
            foreach (PeliculasDetalle item in this.Detalle)
            {
                conexion.Ejecutar(String.Format("Insert into PeliculasDetalle(PeliculaId, CineId, CineSalaId) Values({0}, {1}, {2})", this.PeliculaId, (int)item.CineId, (int)item.CinesSalasId));
            }

            return retorno > 0;

        }

        public override bool Editar()
        {
            bool retorno = false;
            ConexionDb conexion = new ConexionDb();
            retorno = conexion.Ejecutar(String.Format("Update Peliculas set Nombre = '{0}', Genero = '{1}', Clasificacion = '{2}', Idioma = '{3}', Subtitulo = {4}, Director ='{5}', Actores = '{6}', Activa = {7}, FechaInicio = '{8}', FechaFin = '{9}', Duracion = '{9}', Precio = {11}, Imagen = '{12}' Video = '{13}' where PeliculaId = {14}", this.Nombre, this.Genero, this.Clasificacion, this.Idioma, this.Subtitulo, this.Director, this.Actores, this.Activa, this.FechaInicio, this.FechaFin, this.Duracion, this.Precio, this.Imagen, this.Video, this.PeliculaId));
            return retorno;
        }

        public override bool Eliminar()
        {
            bool retorno = false;
            ConexionDb conexion = new ConexionDb();
            retorno = conexion.Ejecutar(String.Format("Delete from Peliculas where PeliculaId = {0}", this.PeliculaId));
            if (retorno)
            {
                conexion.Ejecutar(String.Format("Delete from Peliculasdetalle where PeliculaId = {0}", this.PeliculaId));
            }
            return retorno;
        }

        public override bool Buscar(int IdBuscado)
        {
            ConexionDb conexion = new ConexionDb();
            DataTable dt = new DataTable();
            DataTable dtDetalle = new DataTable();
            dt = conexion.ObtenerDatos(String.Format("Select * from Peliculas Where PeliculaId = {0}", IdBuscado));

            if (dt.Rows.Count > 0)
            {
                this.Nombre = dt.Rows[0]["Nombre"].ToString();
                this.Genero = dt.Rows[0]["Genero"].ToString();
                this.Clasificacion = dt.Rows[0]["Clasificacion"].ToString();
                this.Idioma = dt.Rows[0]["Idioma"].ToString();
                this.Subtitulo = Convert.ToInt32(dt.Rows[0]["Subtitulo"]);
                this.Director = dt.Rows[0]["Director"].ToString();
                this.Actores = dt.Rows[0]["Actores"].ToString();
                this.Activa = Convert.ToInt32(dt.Rows[0]["Activa"]);
                this.FechaInicio = dt.Rows[0]["FechaInicio"].ToString();
                this.FechaFin = dt.Rows[0]["FechaFin"].ToString();
                this.Duracion = (TimeSpan)dt.Rows[0]["Duracion"];
                this.Precio = (double)dt.Rows[0]["Precio"];
                this.Imagen = dt.Rows[0]["Imagen"].ToString();
                this.Video = dt.Rows[0]["Video"].ToString();
            }
            dt = conexion.ObtenerDatos(String.Format("Select * from PeliculasDetalle where PeliculaId = {0} --", this.PeliculaId));
            if (dtDetalle.Rows.Count > 0)
            {
                foreach (DataRow dr in dtDetalle.Rows)
                {
                    AddCinesSalas((int)dr["CineId"], (int)dr["CineSalaId"]);
                }
            }
            return dt.Rows.Count > 0;
        }

        public override DataTable Listado(string Campos, string Condicion, string Orden)
        {
            ConexionDb conexion = new ConexionDb();
            string OrdenFinal = string.Empty;
            if (!Orden.Equals(""))
            {
                OrdenFinal = " Order by " + Orden;
            }
            return conexion.ObtenerDatos("Select " + Campos + "from Peliculas where " + Condicion + " " + OrdenFinal);
        }
    }
}
