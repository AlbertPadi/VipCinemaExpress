using System;
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
        public string  Genero { get; set; }
        public string Clasificacion { get; set; }
        public string Idioma { get; set; }
        public int Subtitulo { get; set; }
        public string Director { get; set; }
        public string Actores { get; set; }
        public int Activa { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public double Precio { get; set; }
        public string Imagen { get; set; }
        public string Video { get; set; }

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
            this.FechaInicio = DateTime.Now;
            this.FechaFin = DateTime.Now;
            this.Precio = 0;
            this.Imagen = "";
            this.Video = "";
        }

        public override bool Insertar()
        {
            bool retorno = false;
            ConexionDb conexion = new ConexionDb();
            retorno = conexion.Ejecutar(String.Format("Insert into Peliculas(Nombre, Genero, Clasificacion, Idioma, Subtitulo, Director, Actores, Activa, FechaInicio, FechaFin, Precio, Imagen, Video) Values('{0}', '{1}', '{2}', '{3}', {4}, '{5}', '{6}', {7}, '{8}', '{9}', {10}, '{11}', {12})", this.Nombre, this.Genero, this.Clasificacion, this.Idioma, this.Subtitulo, this.Director, this.Actores, this.Activa, this.FechaInicio, this.FechaFin, this.Precio, this.Imagen, this.Video));
            return retorno;
            
        }

        public override bool Editar()
        {
            bool retorno = false;
            ConexionDb conexion = new ConexionDb();
            retorno = conexion.Ejecutar(String.Format("Update Peliculas set Nombre = '{0}', Genero = '{1}', Clasificacion = '{2}', Idioma = '{3}', Subtitulo = {4}, Director ='{5}', Actores = '{6}', Activa = {7}, FechaInicio = '{8}', FechaFin = '{9}', Precio = {10}, Imagen = '{11}' Video = '{12}' where PeliculaId = {13}", this.Nombre, this.Genero, this.Clasificacion, this.Idioma, this.Subtitulo, this.Director, this.Actores, this.Activa, this.FechaInicio, this.FechaFin, this.Precio, this.Imagen, this.Video, this.PeliculaId));
            return retorno;
        }

        public override bool Eliminar()
        {
            bool retorno = false;
            ConexionDb conexion = new ConexionDb();
            retorno = conexion.Ejecutar(String.Format("Delete from Peliculas where PeliculaId = {0}", this.PeliculaId));
            return retorno;
        }
        
        public override bool Buscar(int IdBuscado)
        {
            ConexionDb conexion = new ConexionDb();
            DataTable dt = new DataTable();
            dt = conexion.ObtenerDatos(String.Format("Select * from Peliculas Wherer PeliculaId = {0}", IdBuscado));

            if (dt.Rows.Count > 0)
            {
                this.Nombre = dt.Rows[0]["Nombre"].ToString();
                this.Genero = dt.Rows[0]["Genero"].ToString();
                this.Clasificacion = dt.Rows [0]["Clasificacion"].ToString();
                this.Idioma = dt.Rows[0]["Idioma"].ToString();
                this.Subtitulo = (int)dt.Rows[0]["Subtitulo"];
                this.Director = dt.Rows[0]["Director"].ToString();
                this.Actores = dt.Rows[0]["Actores"].ToString();
                this.Activa = (int)dt.Rows[0]["Activa"];
                this.FechaInicio = (DateTime)dt.Rows[0]["FechaInicio"];
                this.FechaFin = (DateTime)dt.Rows[0]["FechaFin"];
                this.Precio = (double)dt.Rows[0]["Precio"];
                this.Imagen = dt.Rows[0]["Imagen"].ToString();
                this.Video = dt.Rows[0]["Video"].ToString();
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
