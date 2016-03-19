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
            throw new NotImplementedException();
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
