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
        public int CineId { get; set; }
        
        public string Nombres { get; set; }
        public string Ciudad { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public List<CinesSalasDetalle> Sala { get; set; }
        public Cines()
        {
            this.CineId = 0;
            this.Nombres = "";
            this.Ciudad = "";
            this.Direccion = "";
            this.Telefono = "";
            this.Email = "";
            Sala = new List<CinesSalasDetalle>();
        }

        public void AgregarSalas(int SalaId)
        {
            this.Sala.Add(new CinesSalasDetalle(SalaId));
        }

         public DataTable getSalas(string select)
        {
            ConexionDb conexion = new ConexionDb();
            DataTable dt = new DataTable();
            dt = conexion.ObtenerDatos(select);
            return dt;
            
        }

        public override bool Insertar()
        {
            bool retorno = false;
            StringBuilder comando = new StringBuilder();
            ConexionDb conexion = new ConexionDb();
            retorno = conexion.Ejecutar(String.Format("Insert into Cines(Nombre, Ciudad, Direccion, Telefono, Email) values('{0}', '{1}', '{2}', '{3}', '{4}')", this.Nombres, this.Ciudad, this.Direccion, this.Telefono, this.Email));

            if (retorno)
            {
                this.CineId = (int)conexion.ObtenerDatos("Select MAX(CineId) as CineId from Cines").Rows[0]["CineId"];
                foreach (var sala in Sala)
                {
                    comando.AppendLine(String.Format("Insert into CinesSalasDetalle(SalaId, CineId) Values({0}, {1})", sala.SalaId, this.CineId));
                }

                retorno = conexion.Ejecutar(comando.ToString());
            }

            return retorno;
        }

        public override bool Editar()
        {
            bool retorno = false;
            StringBuilder comando = new StringBuilder();
            ConexionDb conexion = new ConexionDb();
            retorno = conexion.Ejecutar(String.Format("Update Cines set Nombre = '{0}', Ciudad = '{1}', Direccion = '{2}', Telefono = '{3}', Email = '{4}' where CineId = {5}", this.Nombres, this.Ciudad, this.Direccion, this.Telefono, this.Email, this.CineId));
            if (retorno)
            {
                conexion.Ejecutar(String.Format("Delete from CinesSalasDetalle where CineId = " + this.CineId));

                foreach (var sala in Sala)
                {
                    comando.AppendLine(String.Format("Insert into CinesSalasDetalle(SalaId) Values({0)", sala.SalaId));
                }

                retorno = conexion.Ejecutar(comando.ToString());
            }
            return retorno;
        }

        public override bool Eliminar()
        {
            bool retorno = false;
            ConexionDb conexion = new ConexionDb();
            retorno = conexion.Ejecutar(String.Format("Delete from Cines where CineId = {0}" +this.CineId +";"
                    + "Delete from CinesSalasDetalle where CineId = " + this.CineId));
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
                this.Nombres = dt.Rows[0]["Nombre"].ToString();
                this.Ciudad = dt.Rows[0]["Ciudad"].ToString();
                this.Direccion = dt.Rows[0]["Direccion"].ToString();
                this.Telefono = dt.Rows[0]["Telefono"].ToString();
                this.Email = dt.Rows[0]["Email"].ToString();

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
