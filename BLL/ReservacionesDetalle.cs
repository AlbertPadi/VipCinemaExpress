using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
namespace BLL
{
    public class ReservacionesDetalle
    {
        public readonly int PeliculaId;
        public int Cantidad { get; set; }
        public string Nombre { get; set; }
        public int SalaId { get; set; }
        public int CineId { get; set; }
        public DateTime Fecha { get; set; }
        public double Monto { get; set; }

        public ReservacionesDetalle(int cantidad, string nombre, int cineId, int salaId, DateTime fecha, double precio)
        {
            this.Cantidad = cantidad;
            this.Nombre = nombre;
            this.CineId = cineId;
            this.SalaId = salaId;
            this.Fecha = fecha;
            this.Monto = precio;
        }
    }
}
