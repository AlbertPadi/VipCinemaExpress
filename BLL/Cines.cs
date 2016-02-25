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
        public List<Salas> Sala { get; set; }
        public Cines()
        {
            this.CineId = 0;
            this.Nombres = "";
            this.Ciudad = "";
            this.Direccion = "";
            this.Telefono = "";
            this.Email = "";
            Sala = new List<Salas>();
        }

        public void AgregarSalas(int SalaId)
        {
            this.Sala.Add(new Salas(SalaId));
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
                    comando.AppendLine(String.Format("Insert into CinesSalasDetalle(SalaId) Values({0})", sala.SalaId));
                }

                retorno = conexion.Ejecutar(comando.ToString());
            }

            return retorno;
        }

        public override bool Editar()
        {
            bool retorno = false;
            ConexionDb conexion = new ConexionDb();
            retorno = conexion.Ejecutar(String.Format("Update Cines set Nombres = '{0}', Ciudad = '{1}', Direccion = '{2}', Telefono = '{3}', Email = '{4}' where CineId = {5}", this.Nombres, this.Ciudad, this.Direccion, this.Telefono, this.Email, this.CineId));
            return retorno;
        }

        public override bool Eliminar()
        {
            bool retorno = false;
            ConexionDb conexion = new ConexionDb();
            retorno = conexion.Ejecutar(String.Format("Delete from Cines wehre CineId = {0}", this.CineId));
            return retorno;
        }
        public override bool Buscar(int IdBuscado)
        {
            ConexionDb conexion = new ConexionDb();
            DataTable dt = new DataTable();
            dt = conexion.ObtenerDatos(String.Format("Select * from Cines where CineId = '{0}'", IdBuscado));

            if (dt.Rows.Count > 0)
            {
                this.Nombres = dt.Rows[0]["Nombres"].ToString();
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
