using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
namespace VIPCinemaExpress.adm.Registros
{
    public partial class rCarteleras : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            Carteleras cartelera = new Carteleras();
            int peliculaId;
            peliculaId = Convert.ToInt32(PeliculaIdTextBox.Text);
            if (CarteleraIdTextBox.Text.Length < 0)
            {
                cartelera.PeliculaId = peliculaId;
                if (cartelera.Insertar())
                {
                    Response.Write("<SCRIPT>'Se han guardado los datos'</SCRIPT>");
                }
                else
                {
                    Response.Write("<SCRIPT>'Error al guardar los datos'</SCRIPT>");
                }
            }
            else
            {
                int carteleraId;
                carteleraId = Convert.ToInt32(CarteleraIdTextBox.Text);
                cartelera.CarteleraId = carteleraId;
                peliculaId = Convert.ToInt32(PeliculaIdTextBox.Text);

                if (cartelera.Editar())
                {
                    Response.Write("<SCRIPT>'Se han editado los datos'</SCRIPT>");
                }
                else
                {
                    Response.Write("<SCRIPT>'Error al actualizar'</SCRIPT>");
                }

            }
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            int carteleraId;
            Carteleras cartelera = new Carteleras();
            carteleraId = Convert.ToInt32(CarteleraIdTextBox.Text);
            if (CarteleraIdTextBox.Text.Length > 0)
            {
                cartelera.CarteleraId = carteleraId;
            }
            else
            {
                Response.Write("<SCRIPT>'Ingrese un Id'</SCRIPT>");
            }

            if (cartelera.Eliminar())
            {
                Response.Write("<SCRIPT>'Se eliminaron los datos'</SCRIPT>");
            }
            else
            {
                Response.Write("<SCRIPT>'No se e=han eliminado los datos'</SCRIPT>");
            }

        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            int carteleraId;
            Carteleras cartelera = new Carteleras();
            carteleraId = Convert.ToInt32(CarteleraIdTextBox.Text);
            if (CarteleraIdTextBox.Text.Length > 0)
            {
                cartelera.CarteleraId = carteleraId;
                if (cartelera.Buscar(carteleraId))
                {
                    PeliculaIdTextBox.Text = cartelera.PeliculaId.ToString();
                }
                
            }
            else
            {
                Response.Write("<SCRIPT>'Ingrese un Id'</SCRIPT>");
            }

            
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            CarteleraIdTextBox.Text = string.Empty;
            PeliculaIdTextBox.Text = string.Empty;

        }
    }
}