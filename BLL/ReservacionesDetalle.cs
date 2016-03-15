using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
namespace BLL
{
    public class ReservacionesDetalle
    {
        public int PeliculaId { get; set; }

        public ReservacionesDetalle(int PeliculaId)
        {
            
            this.PeliculaId = PeliculaId;
        }
    }
}
