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
        public string Clasificacion { get; set; }
        public string Idioma { get; set; }
        public int Subtitulo { get; set; }
        public string Director { get; set; }
        public string Actores { get; set; }
        public int Activa { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
        public string Video { get; set; }

        public Peliculas()
        {
            this.PeliculaId = 0;
            this.Clasificacion = "";
            this.Idioma = "";
            this.Subtitulo = 0;
            this.Director = "";
            this.Actores = "";
            this.Activa = 0;
            this.FechaInicio = "";
            this.FechaFin = "";
            this.Video = "";
        }

        public override bool Insertar()
        {
            bool retorno = false;
            ConexionDb conexion = new ConexionDb();
            retorno = conexion.Ejecutar(String.Format("Insert into Peliculas(Clasificacion, Idioma, Subtitulo, Director, Actores, Activa, FechaInicio, FechaFin, Video) Values('{0}', '{1}', {2}, '{3}', '{4}', {5}, '{6}', '{7}', '{8}')", this.Clasificacion, this.Idioma, this.Subtitulo, this.Director, this.Actores, this.Activa, this.FechaInicio, this.FechaFin, this.Video));
            return retorno;
            
        }

        public override bool Editar()
        {
            bool retorno = false;
            ConexionDb conexion = new ConexionDb();
            retorno = conexion.Ejecutar(String.Format("Update Peliculas set Clasificacion = '{0}', Idioma = '{1}', Subtitulo = {2}, Director ='{3}', Actores = '{4}', Activa = {5}, FechaInicio = '{6}', FechaFin = '{7}', Video = '{8}' where PeliculaId = {9}", this.Clasificacion, this.Idioma, this.Subtitulo, this.Director, this.Actores, this.Activa, this.FechaInicio, this.FechaFin, this.Video, this.PeliculaId));
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
                this.Clasificacion = dt.Rows [0]["Clasificacion"].ToString();
                this.Idioma = dt.Rows[0]["Idioma"].ToString();
                this.Subtitulo = (int)dt.Rows[0]["Subtitulo"];
                this.Director = dt.Rows[0]["Director"].ToString();
                this.Actores = dt.Rows[0]["Actores"].ToString();
                this.Activa = (int)dt.Rows[0]["Activa"];
                this.FechaInicio = dt.Rows[0]["FechaInicio"].ToString();
                this.FechaFin = dt.Rows[0]["FechaFin"].ToString();
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
