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
    public partial class cCines : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            Cines cine = new Cines();
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
                    filtro = "CineId = " + DatosTextBox.Text;
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

                    filtro = "Ciudad like '%" + DatosTextBox.Text + "%'";
                }
            else if (DatosDropDownList.SelectedIndex == 3)
                if (DatosTextBox.Text.Trim().Length == 0)
                {
                    filtro = "1=1";
                }
                else
                {

                    filtro = "Direccion like '%" + DatosTextBox.Text + "%'";
                }

            dt = cine.Listado(" * ", filtro, "CineId ASC");
            DatosGridView.DataSource = dt;
            DatosGridView.DataBind();

        }

        protected void ImprimirButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Rpts/CinesReporte.aspx");
        }
    }

}