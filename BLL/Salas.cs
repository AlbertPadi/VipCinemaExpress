using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DAL;
namespace BLL
{
    public class Salas : ClaseMaestra
    {
        public int SalaId { get; set; }
        public string Descripcion { get; set; }
        public int NoAsiento { get; set; }

        public Salas()
        {
            this.SalaId = 0;
            this.Descripcion = "";
            this.NoAsiento = 0;
        }
        public Salas(int salaId)
        {
            this.SalaId = salaId;
        }
        public override bool Insertar()
        {
            bool retorno = false;
            ConexionDb conexion = new ConexionDb();
            retorno = conexion.Ejecutar(String.Format("Insert into Salas(Descripcion, NoAsiento) values('{0}', {1})",  this.Descripcion, this.NoAsiento));
            return retorno;
        }

        public override bool Editar()
        {
            bool retorno = false;
            ConexionDb conexion = new ConexionDb();
            retorno = conexion.Ejecutar(String.Format("Update Salas set Descripcion = '{0}', NoAsiento = {1} where SalaId = {2}", this.Descripcion, this.NoAsiento, this.SalaId));
            return retorno;
        }

        public override bool Eliminar()
        {
            bool retorno = false;
            ConexionDb conexion = new ConexionDb();
            retorno = conexion.Ejecutar(String.Format("Delete from Salas where SalaId = {0}", this.SalaId));
            return retorno;
        }
        public override bool Buscar(int IdBuscado)
        {
            ConexionDb conexion = new ConexionDb();
            DataTable dt = new DataTable();
            dt = conexion.ObtenerDatos(String.Format("Select * from Salas where SalaId = {0}", IdBuscado));

            if (dt.Rows.Count > 0)
            {
                this.Descripcion = dt.Rows[0]["Descripcion"].ToString();
                this.NoAsiento = (int)dt.Rows[0]["NoAsiento"];
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
            return conexion.ObtenerDatos("Select " + Campos + "from Salas where " + Condicion + " " + OrdenFinal);
        }
    }
}
