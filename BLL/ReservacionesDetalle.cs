using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
namespace BLL
{
    public class ReservacionesDetalle
    {
        public int ReservacionDetalleId { get; set; }
        public int ReservacionId { get; set; }
        public int PeliculaId { get; set; }

        public ReservacionesDetalle(int ReservacionId, int PeliculaId)
        {
            
            this.ReservacionDetalleId = 0;
            this.ReservacionId = ReservacionId;
            this.PeliculaId = PeliculaId;
        }
    }
}
