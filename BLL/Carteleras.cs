using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DAL;
namespace BLL
{
    public class Carteleras : ClaseMaestra
    {
        public int CarteleraId { get; set; }
        public int PeliculaId { get; set; }

        public Carteleras()
        {
            this.CarteleraId = 0;
            this.PeliculaId = 0;
        }

        public override bool Insertar()
        {
            bool retorno = false;
            ConexionDb conexion = new ConexionDb();
            retorno = conexion.Ejecutar(String.Format("Insert into Carteleras(PeliculaId) Values({0})", this.PeliculaId));
            return retorno;
        }

        public override bool Editar()
        {
            bool retorno = false;
            ConexionDb conexion = new ConexionDb();
            retorno = conexion.Ejecutar(String.Format("Update Carteleras set PeliculaId = {0} where CarteleraId = {1}", this.PeliculaId, this.CarteleraId));
            return retorno;
        }

        public override bool Eliminar()
        {
            bool retorno = false;
            ConexionDb conexion = new ConexionDb();
            retorno = conexion.Ejecutar(String.Format("Delete from Carteleras where CarteleraId = {0}", CarteleraId));
            return retorno;
        }
        public override bool Buscar(int IdBuscado)
        {
            ConexionDb conexion = new ConexionDb();
            DataTable dt = new DataTable();
            dt = conexion.ObtenerDatos(String.Format("Select *from Carteleras where CarteleraId = {0}", IdBuscado));

            if (dt.Rows.Count > 0)
            {
                this.PeliculaId = (int)dt.Rows[0]["PeliculaId"];
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
            return conexion.ObtenerDatos("Select " + Campos + "from Carteleras where " + Condicion + " " + OrdenFinal);
        }
    }
}
