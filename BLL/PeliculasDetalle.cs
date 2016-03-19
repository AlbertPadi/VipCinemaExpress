using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
    }
}
