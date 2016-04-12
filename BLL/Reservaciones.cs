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
        public int Cantidad { get; set; }
        public double Monto { get; set; }
        public int UsuarioId { get; set; }
        public List<ReservacionesDetalle> Peliculas;

        object Identity;
        int valor = 0;
        public Reservaciones()
        {

            this.ReservacionId = 0;
            this.UsuarioId = 0;
            this.Cantidad = 0;
            this.Monto = 0;
            Peliculas = new List<ReservacionesDetalle>();
        }

        public void AgregarReservacion(int cantidad, string nombre, int cineId, int salaId, DateTime fecha, double Monto)
        {
            this.Peliculas.Add(new ReservacionesDetalle(cantidad, nombre, cineId, salaId, fecha, Monto));
        }


        public bool AddCine(int id)
        {
            DataTable dt = new DataTable();
            Cines cine = new Cines();
            ConexionDb conexion = new ConexionDb();
            dt = conexion.ObtenerDatos(String.Format("Select Nombre, Ciudad, Direccion, Telefono from Cines where CineId = {0}", id));
            return dt.Rows.Count > 0;

        }

        public override bool Insertar()
        {


            object identity;
            int retorno = 0;
            ConexionDb conexion = new ConexionDb();
            identity = conexion.ObtenerValor(String.Format("Insert into Reservaciones(UsuarioId, MontoTot)Values({0}, '{1}') Select @@Identity", this.UsuarioId,  this.Monto));


            int.TryParse(identity.ToString(), out retorno);
            this.ReservacionId = retorno;

            foreach (ReservacionesDetalle item in this.Peliculas)
            {
                conexion.Ejecutar(String.Format("Insert into ReservacionesDetalle(ReservacionId, Cantidad, Nombre, CineId, SalaId, Fecha, Precio) Values({0}, {1}, '{2}', {3}, {4}, '{5}', {6})", retorno, (int)item.Cantidad, (string)item.Nombre, (int)item.CineId, (int)item.SalaId, (DateTime)item.Fecha, (double)item.Monto));
            }

            return retorno > 0;
        }

        public override bool Editar()
        {
            bool retorno = false;
            ConexionDb conexion = new ConexionDb();

            retorno = conexion.Ejecutar(String.Format("Update Reservasiones set UsuarioId = {0}, Fecha = '{1}', Cantidad = {2}, MontoTot = {3} where ReservacionId = {6}", this.UsuarioId, this.Cantidad, this.Monto, this.ReservacionId));
            int.TryParse(Identity.ToString(), out valor);
            if (retorno)
            {
                conexion.Ejecutar(String.Format("Delete from ReservacionesDetalle where ReservacionId = {0}", valor));

                foreach (ReservacionesDetalle item in this.Peliculas)
                {
                    conexion.Ejecutar(String.Format("Insert into ReservacionesDetalle(ReservacionId, Cantidad, Nombre, CineId, SalaId, Fecha, Precio) Values({0}, {1}, '{2}', {3}, {4}, '{5}', {6})", retorno, (int)item.Cantidad, (string)item.Nombre, (int)item.CineId, (int)item.SalaId, (DateTime)item.Fecha, (double)item.Monto));
                }


            }

            return retorno;
        }

        public override bool Eliminar()
        {
            bool retorno = false;
            ConexionDb conexion = new ConexionDb();
            retorno = conexion.Ejecutar(String.Format("Delete from Reservasiones where ReservasionId = {0}" + this.ReservacionId + ": " + "delete from ReservacionesDetalle where ReservacionId =" + this.ReservacionId));
            
            if (retorno)
            {
                conexion.Ejecutar(String.Format("Delete from ReservacionesDetalle where ReservacionId= {0}", this.ReservacionId));
            }
            return retorno;
        }
        public override bool Buscar(int IdBuscado)
        {
            ConexionDb conexion = new ConexionDb();
            DataTable dt = new DataTable();
            DataTable dtReservas = new DataTable();
            dt = conexion.ObtenerDatos(String.Format("Select * from Reservaciones where ReservasionId = {0}", IdBuscado));

            if (dt.Rows.Count > 0)
            {
                this.ReservacionId = IdBuscado;
                this.UsuarioId = (int)dt.Rows[0]["UsuarioId"];
                this.Monto = (double)dt.Rows[0]["MontoTot"];

                dtReservas = conexion.ObtenerDatos(String.Format("Select * from ReservacionesDetalle where ReservacionId = {0} --", IdBuscado));

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dtr in dtReservas.Rows)
                    {
                        AgregarReservacion((int)dtr["Cantidad"], (string)dtr["Nombre"], (int)dtr["CineId"], (int)dtr["SalaId"], (DateTime)dtr["Fecha"], (double)dtr["Monto"]);
                    }
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
            return conexion.ObtenerDatos("Select " + Campos + " from Reservasiones where " + Condicion + " " + OrdenFinal);
        }
    }
}
