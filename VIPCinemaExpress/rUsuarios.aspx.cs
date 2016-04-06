using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
namespace VIPCinemaExpress
{
    public partial class rUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void Limpiar()
        {
            NombresTextBox.Text = string.Empty;
            ApellidosTextBox.Text = string.Empty;
            DireccionTextBox.Text = string.Empty;
            TelefonoTextBox.Text = string.Empty;
            CelularTextBox.Text = string.Empty;
            EmailTextBox.Text = string.Empty;
            UsuarioTextBox.Text = string.Empty;
            PassWordTextBox.Text = string.Empty;
            PassWord1TextBox.Text = string.Empty;
        }
        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            Usuarios usuario = new Usuarios();


            usuario.Nombres = NombresTextBox.Text;
            usuario.Apellidos = ApellidosTextBox.Text;
            usuario.Direccion = DireccionTextBox.Text;
            usuario.Telefono = TelefonoTextBox.Text;
            usuario.Celular = CelularTextBox.Text;
            usuario.Email = EmailTextBox.Text;
            usuario.Usuario = UsuarioTextBox.Text;
            usuario.Contrasena = PassWordTextBox.Text;
            usuario.Tipo = 1;

            if (PassWord1TextBox.Text != PassWordTextBox.Text)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No se guardaron los datos')", true);
            }
            else if (usuario.Insertar())
            {

                {
                    Utilitarios.ShowToastr(this.Page, "Se han insertado los datos", "Correcto", "Insertado");
                    Limpiar();
                }
            }

            else
            {
                Utilitarios.ShowToastr(this.Page, "Error al guardar los datos", "Error", "Error");
                Limpiar();
            }
        }


        protected void EliminarButton_Click(object sender, EventArgs e)
        {

        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {

        }

        protected void PassWord1TextBox_TextChanged(object sender, EventArgs e)
        {
            Usuarios usuario = new Usuarios();
            if (PassWord1TextBox.Text != PassWordTextBox.Text)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No se registraron los datos')", true);
            }
        }
    }

}
