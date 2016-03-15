using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLL;
namespace VIPCinemaExpress.adm.Consultas
{
    public partial class cPeliculas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Peliculas pelicula = new Peliculas();
            DataTable dt = new DataTable();
            string filtro = "1=1";

            if (DatosDropDownList.SelectedIndex == 0)
            {
                if (DatosTextBox.Text.Trim().Length == 0)
                {
                    filtro = "1=1";
                }
                else
                {
                    filtro = "PeliculaId = " + DatosTextBox.Text;
                }
            }

            else if (DatosDropDownList.SelectedIndex == 1)
                if (DatosTextBox.Text.Trim().Length == 0)
                {
                    filtro = "1=1";
                }
                else
                {

                    filtro = "Nombre like '%" + DatosTextBox.Text + "%'";
                }
            else if (DatosDropDownList.SelectedIndex == 2)
                if (DatosTextBox.Text.Trim().Length == 0)
                {
                    filtro = "1=1";
                }
                else
                {

                    filtro = "Clasificacion like '%" + DatosTextBox.Text + "%'";
                }
            else if (DatosDropDownList.SelectedIndex == 3)
                if (DatosTextBox.Text.Trim().Length == 0)
                {
                    filtro = "1=1";
                }
                else
                {

                    filtro = "Director like '%" + DatosTextBox.Text + "%'";
                }

            else if (DatosDropDownList.SelectedIndex == 4)
                if (DatosTextBox.Text.Trim().Length == 0)
                {
                    filtro = "1=1";
                }
                else
                {

                    filtro = "Genero like '%" + DatosTextBox.Text + "%'";
                }

            dt = pelicula.Listado(" * ", filtro, "PeliculaId ASC");
            DatosGridView.DataSource = dt;
            DatosGridView.DataBind();
        }
    }
}