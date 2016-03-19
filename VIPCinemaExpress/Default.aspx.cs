using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;

namespace VIPCinemaExpress
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Peliculas pelicula = new Peliculas();
            DataTable dt = new DataTable();
            //if (pelicula.Buscar(3))
            //{
            //    PeliculaImage.ImageUrl = @"\temp\"+ pelicula.Imagen;

            //}
            dt = pelicula.Listado(" Imagen ", " 1=1 ", "");
            foreach (DataRow item in dt.Rows)
            {
                Response.Write("<img src='/temp/"+ item["Imagen"] + "' alt='image04'style=' height:210px; width:150px;' />");
            }
        }
    }
}