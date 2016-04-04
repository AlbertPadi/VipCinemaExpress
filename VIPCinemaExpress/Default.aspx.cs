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
            if (!IsPostBack)
            {
                Peliculas pelicula = new Peliculas();
                yourRepeater.DataSource = pelicula.Listado(" * ","1=1","");
                yourRepeater.DataBind();
                //if (pelicula.Listado(" * ", " 1=1 ", "").Rows.Count > 0)
                //{
                //    imgImagen.url = pelicula.Listado(" * ", " 1=1 ", "").Rows[0]["Imagen"].ToString();
                //}
            }
            DataTable dt = new DataTable();
            int var = 0;
            //{
            //    PeliculaImage.ImageUrl = @"\temp\" + pelicula.Imagen;

            //}

            //dt = pelicula.Listado("PeliculaId, Nombre, Imagen", " 1=1 ", "");
            //foreach (DataRow item in dt.Rows)
            //{

            //      Response.Write("<img src='/temp/" + item["Imagen"] + "'alt= 'image04'" + "style=' height:210px; width:150px;'/> ");


           
           // }


        }

        protected void yourRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            Response.Redirect("~/rPeliculas.aspx?Id=" + e.CommandArgument);
        }
    }
}