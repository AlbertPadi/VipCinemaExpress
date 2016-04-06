using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    public class CinesSalasDetalle: ClaseMaestra
    {
        public readonly int CineId;
        public string NombreSala { get; set; }
        public int NoAsiento { get; set; }
        public int EsActiva { get; set; }

        public CinesSalasDetalle(string NombreSala, int NoAsiento, int esActiva)
        {
            this.NombreSala = NombreSala;
            this.NoAsiento = NoAsiento;
            this.EsActiva = esActiva;
        }

        public CinesSalasDetalle()
        {
            this.CineId = 0;
            this.NombreSala = "";
            this.NoAsiento = 0;
            this.EsActiva = 0;
        }

        public override bool Insertar()
        {
            throw new NotImplementedException();
        }

        public override bool Editar()
        {
            throw new NotImplementedException();
        }

        public override bool Eliminar()
        {
            throw new NotImplementedException();
        }

        public override bool Buscar(int IdBuscado)
        {
            ConexionDb conexion = new ConexionDb();
            DataTable dt = new DataTable();
            dt = conexion.ObtenerDatos(String.Format("Select * from CinesSalasDetalle where CineId = {0}", IdBuscado));
            if (dt.Rows.Count > 0)
            {
                this.NombreSala = dt.Rows[0]["NombreSala"].ToString();
                this.NoAsiento = (int)dt.Rows[0]["NoAsiento"];
                this.EsActiva = (int)dt.Rows[0]["EsActiva"];
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
            return conexion.ObtenerDatos("Select " + Campos + " from CinesSalasDetalle where " + Condicion + " " + OrdenFinal);
        }
    }

    
}
