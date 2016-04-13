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
    public partial class cReservaciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Reservaciones reservas = new Reservaciones();
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
                    filtro = "ReservacionId = " + DatosTextBox.Text;
                }
            }

            else if (DatosDropDownList.SelectedIndex == 1)
                if (DatosTextBox.Text.Trim().Length == 0)
                {
                    filtro = "1=1";
                }
                else
                {

                    filtro = "UsuarioId like '%" + DatosTextBox.Text + "%'";
                }
            

            dt = reservas.Listado(" * ", filtro, "ReservacionId ASC");
            DatosGridView.DataSource = dt;
            DatosGridView.DataBind();
        }
    }
}