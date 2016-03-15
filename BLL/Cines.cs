using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DAL;
namespace BLL
{
    public class Cines : ClaseMaestra
    {
        object identity;
        int valor = 0;
        public int CineId { get; set; }

        public string Nombres { get; set; }
        public string Ciudad { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public int CantidadSalas { get; set; }
        public List<CinesSalasDetalle> Sala { get; set; }
        public Cines()
        {
            this.CineId = 0;
            this.Nombres = "";
            this.Ciudad = "";
            this.Direccion = "";
            this.Telefono = "";
            this.Email = "";
            this.CantidadSalas = 0;
            Sala = new List<CinesSalasDetalle>();
        }

        public void AgregarSalas(string NombreSala, int NoAsiento, int esActiva)
        {
            Sala.Add(new CinesSalasDetalle(NombreSala, NoAsiento, esActiva));
        }



        public override bool Insertar()
        {
            object identity;
            int retorno = 0;
            ConexionDb conexion = new ConexionDb();
            identity = conexion.ObtenerValor(String.Format("Insert into Cines(Nombre, Ciudad, Direccion, Telefono, Email, CantidadSalas) values('{0}', '{1}', '{2}', '{3}', '{4}', {5}) Select @@Identity", this.Nombres, this.Ciudad, this.Direccion, this.Telefono, this.Email, this.CantidadSalas));


            int.TryParse(identity.ToString(), out retorno);
            this.CineId = retorno;

            foreach (CinesSalasDetalle item in this.Sala)
            {
                conexion.Ejecutar(String.Format("Insert into CinesSalasDetalle(CineId, NombreSala, NoAsiento, EsActiva) Values({0}, '{1}', {2}, {3})", retorno, (string)item.NombreSala, (int)item.NoAsiento, (int)item.EsActiva));
            }

            return retorno > 0;


        }

        public override bool Editar()
        {
            bool retorno = false;
            ConexionDb conexion = new ConexionDb();

            retorno = conexion.Ejecutar(String.Format("Update Cines set Nombre = '{0}', Ciudad = '{1}', Direccion = '{2}', Telefono = '{3}', Email = '{4}', CantidadSalas = {5} where CineId = {6}", this.Nombres, this.Ciudad, this.Direccion, this.Telefono, this.Email, this.CantidadSalas, this.CineId));
            identity = conexion.ObtenerValor(String.Format("select CineId from Cines where CineId = {0}", this.CineId));
            int.TryParse(identity.ToString(), out valor);
            if (retorno)
            {
                conexion.Ejecutar(String.Format("Delete from CinesSalasDetalle where CineId = {0}", valor));


                foreach (CinesSalasDetalle item in this.Sala)
                {
                    conexion.Ejecutar(String.Format("Insert into CinesSalasDetalle(CineId, NombreSala, NoAsiento, EsActiva) Values({0}, '{1}', {2}, {3})", valor, (string)item.NombreSala, (int)item.NoAsiento, (int)item.EsActiva));
                }
            }
            return retorno;
        }

        public override bool Eliminar()
        {
            bool retorno = false;
            ConexionDb conexion = new ConexionDb();
            retorno = conexion.Ejecutar(String.Format("Delete from CinesSalasDetalle where CineId = {0}", this.CineId));
            if (retorno)
            {
                conexion.Ejecutar(string.Format("Delete from Cines where CineId = {0}", this.CineId));

            }

            return retorno;
        }
        public override bool Buscar(int IdBuscado)
        {
            ConexionDb conexion = new ConexionDb();
            DataTable dt = new DataTable();
            DataTable dtCinesSalas = new DataTable();
            dt = conexion.ObtenerDatos(String.Format("Select * from Cines Where CineId = '{0}'", IdBuscado));

            if (dt.Rows.Count > 0)
            {
                this.CineId = IdBuscado;
                this.Nombres = dt.Rows[0]["Nombre"].ToString();
                this.Ciudad = dt.Rows[0]["Ciudad"].ToString();
                this.Direccion = dt.Rows[0]["Direccion"].ToString();
                this.Telefono = dt.Rows[0]["Telefono"].ToString();
                this.Email = dt.Rows[0]["Email"].ToString();

            }
            dtCinesSalas = conexion.ObtenerDatos(String.Format("Select * from CinesSalasDetalle where CineId = {0} --", this.CineId));
            if (dtCinesSalas.Rows.Count > 0)
            {
                foreach (DataRow dr in dtCinesSalas.Rows)
                {
                    AgregarSalas((string)dr["NombreSala"], (int)dr["NoAsiento"], (int)dr["EsActiva"]);
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
            return conexion.ObtenerDatos("Select " + Campos + "from Cines where " + Condicion + " " + OrdenFinal);
        }
    }
}
