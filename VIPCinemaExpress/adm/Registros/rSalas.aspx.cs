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
            
            Salas sala = new Salas();
            if (SalaIdTextBox.Text.Length == 0)
            {
                sala.NoAsiento = Convert.ToInt32(NoAsientoTextBox.Text);
                sala.Descripcion = DescripcionTextBox.Text;

                if (sala.Insertar())
                {
                    HttpContext.Current.Response.Write("<SCRIPT>alert('Se han guardado los datos')</SCRIPT>");
                }
                else
                {
                    HttpContext.Current.Response.Write("<SCRIPT>alert('Error al guardar')</SCRIPT>");
                }

            }
            else
            {
                sala.SalaId = Convert.ToInt32(SalaIdTextBox.Text);
                sala.NoAsiento = Convert.ToInt32(NoAsientoTextBox.Text);
                if (sala.Editar())
                {
                    HttpContext.Current.Response.Write("<SCRIPT>alert('Se han actualizado los datos')</SCRIPT>");
                }
                else
                {
                    HttpContext.Current.Response.Write("<SCRIPT>alert('Error al actualizar')</SCRIPT>");
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
                    HttpContext.Current.Response.Write("<SCRIPT>alert('Se han eliminado los datos')</SCRIPT>");
                }
                else
                {
                    HttpContext.Current.Response.Write("<SCRIPT>alert('Error al eliminar')</SCRIPT>");
                }
            }
            else
            {
                HttpContext.Current.Response.Write("<SCRIPT>alert('Ingrese un Id')</SCRIPT>");
            }
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
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
                sala.Buscar(salaId);
                NoAsientoTextBox.Text = sala.NoAsiento.ToString();
                DescripcionTextBox.Text = sala.Descripcion.ToString();

            }
            else
            {
                HttpContext.Current.Response.Write("<SCRIPT>alert('Ingrese un Id')</SCRIPT>");
            }
        }
    }
}