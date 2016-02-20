using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DAL;
namespace BLL
{
    public class Reservaciones : ClaseMaestra
    {
        public int ReservacionId { get; set; }
        public int CineId { get; set; }
        public int UsuarioId { get; set; }
        public int SalaId { get; set; }
        public int Cantidad { get; set; }
        public double Monto { get; set; }

        public Reservaciones()
        {
            this.ReservacionId = 0;
            this.CineId = 0;
            this.UsuarioId = 0;
            this.SalaId = 0;
            this.Cantidad = 0;
            this.Monto = 0;
        }

        public override bool Insertar()
        {
            bool retorno = false;
            ConexionDb conexion = new ConexionDb();
            retorno = conexion.Ejecutar(String.Format("Insert into Reservasiones(CineId, UsuarioId, SalaId, Cantidad, Monto) values({0}, {1}, {2}, {3}, {4})", this.CineId, this.UsuarioId, this.SalaId, this.Cantidad, this.Monto));
            return retorno;
        }

        public override bool Editar()
        {
            bool retorno = false;
            ConexionDb conexion = new ConexionDb();
            retorno = conexion.Ejecutar(String.Format("Update Reservasiones set CineId = {0}, UsuarioId = {1}, SalaId = {2}, Cantidad = {3}, Monto = {4} where ReservacionId = {5}", this.CineId, this.UsuarioId, this.SalaId, this.Cantidad, this.Monto, this.ReservacionId));
            return retorno;
        }

        public override bool Eliminar()
        {
            bool retorno = false;
            ConexionDb conexion = new ConexionDb();
            retorno = conexion.Ejecutar(String.Format("Delete from Reservasiones where ReservasionId = {0}", this.ReservacionId));
            return retorno;
        }
        public override bool Buscar(int IdBuscado)
        {
            ConexionDb conexion = new ConexionDb();
            DataTable dt = new DataTable();
            dt = conexion.ObtenerDatos(String.Format("Select * from Reservaciones where ReservasionId = {0}", IdBuscado));

            if (dt.Rows.Count > 0)
            {
                this.CineId = (int)dt.Rows[0]["CineId"];
                this.UsuarioId = (int)dt.Rows[0]["UsuarioId"];
                this.SalaId = (int)dt.Rows[0]["SalaId"];
                this.Cantidad = (int)dt.Rows[0]["Cantidad"];
                this.Monto = (double)dt.Rows[0]["Monto"];
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
            return conexion.ObtenerDatos("Select " + Campos + "from Reservasiones where " + Condicion + " " + OrdenFinal);
        }
    }
}
