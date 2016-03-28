using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLL;
namespace VIPCinemaExpress
{
    public partial class Default : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            Peliculas pelicula = new Peliculas();
            DataTable dt = new DataTable();

            //{
            //    PeliculaImage.ImageUrl = @"\temp\" + pelicula.Imagen;

            //}

            dt = pelicula.Listado("PeliculaId, Nombre, Imagen", " 1=1 ", "");
            foreach (DataRow item in dt.Rows)
            {

                Response.Write("<img src='/temp/" + item["Imagen"] + "'alt= 'image04'" + "style=' height:210px; width:150px;'/> ");


                //int valor = CarteleraRepeater.Items.Count;
                //var = Convert.ToInt32(item[0]);
                //pelicula.BuscarPeliculas(var);
                //Image img = CarteleraRepeater.FindControl("PeliculaImage") as Image;
                //PeliculaImage.ImageUrl = @/temp/ + pelicula.Imagen;
                //CarteleraRepeater.Controls. PeliculaImage.ImageUrl = @\temp\ + pelicula.Imagen;

            }


        }
    }
    }