using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
namespace VIPCinemaExpress.adm.Registros
{
    public partial class rSalas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            int CineId;
            int noAsiento;
            Salas sala = new Salas();
            if (SalaIdTextBox.Text.Length == 0)
            {
                CineId = Convert.ToInt32(CineIdTextBox.Text);
                sala.SalaId = CineId;
                noAsiento = Convert.ToInt32(NoAsientoTextBox.Text);
                sala.NoAsiento = noAsiento;
                sala.Descripcion = DescripcionTextBox.Text;

                if (sala.Insertar())
                {
                    Response.Write("<SCRIPT>alert('Se han guardado los datos')</SCRIPT>");
                }
                else
                {
                    Response.Write("<SCRIPT>alert('Error al guardar')</SCRIPT>");
                }

            }
            else
            {
                int SalaId;
                SalaId = Convert.ToInt32(SalaIdTextBox.Text);
                sala.SalaId = SalaId;
                CineId = Convert.ToInt32(CineIdTextBox.Text);
                sala.SalaId = CineId;
                noAsiento = Convert.ToInt32(NoAsientoTextBox.Text);
                sala.NoAsiento = noAsiento;
                sala.Descripcion = DescripcionTextBox.Text;

                if (sala.Editar())
                {
                    Response.Write("<SCRIPT>alert('Se han actualizado los datos')</SCRIPT>");
                }
                else
                {
                    Response.Write("<SCRIPT>alert('Error al actualizar')</SCRIPT>");
                }

            }
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            Salas sala = new Salas();
            int salaId;
            if (SalaIdTextBox.Text.Length > 0)
            {
                salaId = Convert.ToInt32(SalaIdTextBox.Text);
                sala.SalaId = salaId;

                if (sala.Eliminar())
                {
                    Response.Write("<SCRIPT>alert('Se han eliminado los datos')</SCRIPT>");
                }
                else
                {
                    Response.Write("<SCRIPT>alert('Error al eliminar')</SCRIPT>");
                }
            }
            else
            {
                Response.Write("<SCRIPT>alert('Ingrese un Id')</SCRIPT>");
            }
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            SalaIdTextBox.Text = string.Empty;
            CineIdTextBox.Text = string.Empty;
            NoAsientoTextBox.Text = string.Empty;
            DescripcionTextBox.Text = string.Empty;
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            Salas sala = new Salas();
            int salaId;
            if (SalaIdTextBox.Text.Length > 0)
            {
                salaId = Convert.ToInt32(SalaIdTextBox.Text);
                sala.SalaId = salaId;
                CineIdTextBox.Text = sala.CineId.ToString();
                NoAsientoTextBox.Text = sala.NoAsiento.ToString();
                DescripcionTextBox.Text = sala.Descripcion.ToString();

            }
        }
    }
}