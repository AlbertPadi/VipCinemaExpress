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
                    Utilitarios.ShowToastr(this.Page, "Se han guardado los datos", "Guardado", "Success");
                   

                }
                else
                {
                    Utilitarios.ShowToastr(this.Page, "Error al guardar los datos", "Error", "Error");
                }
            }
            else
            {
                
                
                cartelera.CarteleraId = Convert.ToInt32(CarteleraIdTextBox.Text);

                if (cartelera.Editar())
                {
                    Utilitarios.ShowToastr(this.Page, "Se han actualizado los datos", "Actualizado", "Success");
                }
                else
                {
                    Utilitarios.ShowToastr(this.Page, "Error al actualizar", "Error", "Error");
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
                Utilitarios.ShowToastr(this.Page, "Ingrese un Id", "Error", "Error");
            }

            if (cartelera.Eliminar())
            {
                Utilitarios.ShowToastr(this.Page, "Se han eliminado los datos", "Eliminado", "Success");
            }
            else
            {
                Utilitarios.ShowToastr(this.Page, "Error al eliminar", "Error", "Error");
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
                Utilitarios.ShowToastr(this.Page, "Ingrese un Id", "Error", "Error");
            }

            
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            CarteleraIdTextBox.Text = string.Empty;
            PeliculaIdTextBox.Text = string.Empty;

        }
    }
}