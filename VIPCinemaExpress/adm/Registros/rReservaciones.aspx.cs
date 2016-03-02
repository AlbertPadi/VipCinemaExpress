using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
namespace VIPCinemaExpress.adm.Registros
{
    public partial class rReservaciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Cines cine = new Cines();
            Peliculas pelicula = new Peliculas();
            CinesDropDownList.DataSource = cine.Listado(" * ", "1=1", "");
            CinesDropDownList.DataTextField = "Nombre";
            CinesDropDownList.DataValueField = "CineId";
            CinesDropDownList.DataBind();

            SalaIdDropDownList.DataSource = cine.getSalas("Select S.Descripcion from CinesSalasDetalle CSD inner join Salas S on S.SalaId = CSD.SalaId where CSD.CineId = 1");
            SalaIdDropDownList.DataTextField = "Descripcion";
            SalaIdDropDownList.DataValueField = "SalaId";
            SalaIdDropDownList.DataBind();

            PeliculaIdDropDownList.DataSource = pelicula.Listado(" * ", "1=1", "");
            PeliculaIdDropDownList.DataTextField = "Peliculas";
            PeliculaIdDropDownList.DataValueField = "PeliculaId";
            PeliculaIdDropDownList.DataBind();
        }

        protected void BuscarCineButton_Click1(object sender, EventArgs e)
        {
            CineIdTextBox.Text = CinesDropDownList.Text;
        }

        public void Limpiar()
        {
            ReservacionIdTextBox.Text = string.Empty;
            CineIdTextBox.Text = string.Empty;
            UsuarioIdTextBox.Text = string.Empty;
            SalaIdTextBox.Text = string.Empty;
            CantidadTextBox.Text = string.Empty;
            MontoTextBox.Text = string.Empty;
        }
        
        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            Peliculas pelicula = new Peliculas();
            Reservaciones reservas = new Reservaciones();
            int cineId, salaID, peliculaID, cantidad;
            double monto, res;
            peliculaID = Convert.ToInt32(PeliculaIdDropDownList.SelectedValue);
            cineId = Convert.ToInt32(CinesDropDownList.SelectedValue);
            salaID = Convert.ToInt32(SalaIdDropDownList.SelectedValue);
            if (ReservacionIdTextBox.Text.Length == 0)
            {
                reservas.UsuarioId = Convert.ToInt32(UsuarioIdTextBox.Text);
                cantidad = Convert.ToInt32(CantidadTextBox.Text);
                reservas.Cantidad = cantidad;
                reservas.SalaId = salaID;
                reservas.CineId = cineId;

                for (int i = 0; i < PeliculaIdDropDownList.Items.Count; i++)
                {
                    reservas.AgregarReservacion(peliculaID);
                }
                monto = pelicula.Precio * reservas.Cantidad;
                reservas.Monto = monto;
                MontoTextBox.Text = reservas.Monto.ToString();

                if (reservas.Insertar())
                {
                    HttpContext.Current.Response.Write("<SCRIPT>'Se han guardado los datos'</SCRIPT>");
                }
                else
                {
                    HttpContext.Current.Response.Write("<SCRIPT>'Error al guardar los datos'</SCRIPT>");
                }
            }
            else if (ReservacionIdTextBox.Text.Length > 0)
            {
                int reservaId;
                reservaId = Convert.ToInt32(ReservacionIdTextBox.Text);
                reservas.ReservacionId = reservaId;

                reservas.UsuarioId = Convert.ToInt32(UsuarioIdTextBox.Text);
                cantidad = Convert.ToInt32(CantidadTextBox.Text);
                reservas.Cantidad = cantidad;
                reservas.SalaId = salaID;
                reservas.CineId = cineId;

                for (int i = 0; i < PeliculaIdDropDownList.Items.Count; i++)
                {
                    reservas.AgregarReservacion(peliculaID);
                }
                monto = pelicula.Precio * reservas.Cantidad;
                reservas.Monto = monto;
                MontoTextBox.Text = reservas.Monto.ToString();

                if (reservas.Insertar())
                {
                    HttpContext.Current.Response.Write("<SCRIPT>'Se han actualizado los datos'</SCRIPT>");
                }
                else
                {
                    HttpContext.Current.Response.Write("<SCRIPT>'Error al actualizar los datos'</SCRIPT>");
                }
            }
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

        
    }
}