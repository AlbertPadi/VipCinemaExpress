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
            
            if (CarteleraIdTextBox.Text.Length < 0)
            {
                cartelera.PeliculaId = Convert.ToInt32(PeliculaIdTextBox.Text);
                if (cartelera.Insertar())
                {
                    HttpContext.Current.Response.Write("<SCRIPT>'Se han guardado los datos'</SCRIPT>");
                }
                else
                {
                    HttpContext.Current.Response.Write("<SCRIPT>'Error al guardar los datos'</SCRIPT>");
                }
            }
            else
            {
                
                
                cartelera.CarteleraId = Convert.ToInt32(CarteleraIdTextBox.Text);

                if (cartelera.Editar())
                {
                    HttpContext.Current.Response.Write("<SCRIPT>'Se han editado los datos'</SCRIPT>");
                }
                else
                {
                    HttpContext.Current.Response.Write("<SCRIPT>'Error al actualizar'</SCRIPT>");
                }

            }
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            Carteleras cartelera = new Carteleras();
            
            if (CarteleraIdTextBox.Text.Length > 0)
            {
                cartelera.CarteleraId = Convert.ToInt32(CarteleraIdTextBox.Text);
            }
            else
            {
                HttpContext.Current.Response.Write("<SCRIPT>'Ingrese un Id'</SCRIPT>");
            }

            if (cartelera.Eliminar())
            {
                HttpContext.Current.Response.Write("<SCRIPT>'Se eliminaron los datos'</SCRIPT>");
            }
            else
            {
                HttpContext.Current.Response.Write("<SCRIPT>'No se e=han eliminado los datos'</SCRIPT>");
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
                HttpContext.Current.Response.Write("<SCRIPT>'Ingrese un Id'</SCRIPT>");
            }

            
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            CarteleraIdTextBox.Text = string.Empty;
            PeliculaIdTextBox.Text = string.Empty;

        }
    }
}