using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLL;
namespace VIPCinemaExpress.adm.Registros
{
    public partial class rReservaciones : System.Web.UI.Page
    {
        double monto;
        int cantidad;

        protected void Page_Load(object sender, EventArgs e)
        {
            FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dddd hh:mm:ss");

            if (!IsPostBack)
            {

            }
        }
        protected void BuscarCineButton_Click1(object sender, EventArgs e)
        {
        }
        protected void AddPeliculaButton_Click(object sender, EventArgs e)
        {

        }

        public void Limpiar()
        {
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            Reservaciones reservas = new Reservaciones();
            monto = Convert.ToDouble(MontoTextBox.Text);
            cantidad = Convert.ToInt32(CantidadTextBox.Text);
        }

        protected void CineIdTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        protected void SalaIdDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void BuscarCineButton_Click(object sender, EventArgs e)
        {

        }

        protected void AddSalaButton_Click(object sender, EventArgs e)
        {
        }

        protected void CinesDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


    }
}