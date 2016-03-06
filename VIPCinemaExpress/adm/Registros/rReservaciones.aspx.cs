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

        protected void BuscarCineButton_Click1(object sender, EventArgs e)
        {
            CineIdTextBox.Text = CinesDropDownList.Text;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            int id;
            int.TryParse(CineIdTextBox.Text, out id);
           
            if (!IsPostBack)
            {
                Peliculas pelicula = new Peliculas();
                Cines cine = new Cines();

                CinesDropDownList.DataSource = cine.Listado(" * ", "1=1", "");
                CinesDropDownList.DataTextField = "Nombre";
                CinesDropDownList.DataValueField = "CineId";
                CinesDropDownList.DataBind();

                PeliculaIdDropDownList.DataSource = pelicula.Listado(" * ", "1=1", "");
                PeliculaIdDropDownList.DataTextField = "Peliculas";
                PeliculaIdDropDownList.DataValueField = "PeliculaId";
                PeliculaIdDropDownList.DataBind();
            }
        }

        

        public void Limpiar()
        {
            ReservacionIdTextBox.Text = string.Empty;
            CineIdTextBox.Text = string.Empty;
            UsuarioIdTextBox.Text = string.Empty;
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
            if (ReservacionIdTextBox.Text.Length == 0)
            {
                reservas.UsuarioId = Convert.ToInt32(UsuarioIdTextBox.Text);
                cantidad = Convert.ToInt32(CantidadTextBox.Text);
                reservas.Cantidad = cantidad;
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
                    HttpContext.Current.Response.Write("<SCRIPT>alert('Se han guardado los datos')</SCRIPT>");
                }
                else
                {
                    HttpContext.Current.Response.Write("<SCRIPT>alert('Error al guardar los datos')</SCRIPT>");
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
                    HttpContext.Current.Response.Write("<SCRIPT>alert('Se han actualizado los datos')</SCRIPT>");
                }
                else
                {
                    HttpContext.Current.Response.Write("<SCRIPT>alert('Error al actualizar los datos')</SCRIPT>");
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

        protected void AddSalaButton_Click(object sender, EventArgs e)
        {
            SalaIdTextBox.Text = SalaIdDropDownList.Text;
        }

        protected void CinesDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cines cine = new Cines();
            SalaIdDropDownList.DataSource = cine.getSalas("Select S.SalaId, S.Descripcion from CinesSalasDetalle CSD inner join Salas S on S.SalaId = CSD.SalaId where CSD.CineId = " + CinesDropDownList.SelectedValue);
            SalaIdDropDownList.DataTextField = "Descripcion";
            SalaIdDropDownList.DataValueField = "SalaId";
            SalaIdDropDownList.DataBind();


        }
    }
}