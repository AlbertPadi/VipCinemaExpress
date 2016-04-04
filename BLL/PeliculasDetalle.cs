using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Data;

namespace BLL
{
    public class PeliculasDetalle
    {
        public int PeliculaId { get; set; }
        public int CineId { get; set; }
        public int CinesSalasId { get; set; }

        public PeliculasDetalle(int cineId, int cinesSalasId)
        {
            this.CineId = cineId;
            this.CinesSalasId = cinesSalasId;

        }

        public PeliculasDetalle()
        {
            this.CineId = 0;
            this.CinesSalasId = 0;
        }

        public bool BuscarPeliculas(int IdBuscado)
        {
            ConexionDb conexion = new ConexionDb();
            DataTable dt = new DataTable();
            dt = conexion.ObtenerDatos(String.Format("Select * from PeliculasDetalle Where PeliculaId = {0}", IdBuscado));

            if (dt.Rows.Count > 0)
            {
                this.PeliculaId = IdBuscado;
                this.CineId = (int)dt.Rows[0]["CineId"];
                this.CinesSalasId = (int)dt.Rows[0]["CinesSalasId"];
            }

            return dt.Rows.Count > 0;
        }
    }
}
