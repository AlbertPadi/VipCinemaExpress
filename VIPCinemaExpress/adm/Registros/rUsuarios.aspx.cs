using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
namespace VIPCinemaExpress.adm.Registros
{
    public partial class rUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void Limpiar()
        {
            UsuarioIdTextBox.Text = string.Empty;
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

        protected void NombresTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            Usuarios usuario = new Usuarios();

            if (UsuarioIdTextBox.Text.Length == 0)
            {
                usuario.Nombres = NombresTextBox.Text;
                usuario.Apellidos = ApellidosTextBox.Text;
                usuario.Direccion = DireccionTextBox.Text;
                usuario.Telefono = TelefonoTextBox.Text;
                usuario.Celular = CelularTextBox.Text;
                usuario.Email = EmailTextBox.Text;
                usuario.Usuario = UsuarioTextBox.Text;
                usuario.Contrasena = PassWordTextBox.Text;

                if (PassWord1TextBox.Text != PassWordTextBox.Text)
                {
                    Utilitarios.ShowToastr(this.Page, "Error", "Error al guardar los datos", "Error");
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
            else
            {
                int id;
                id = Convert.ToInt32(UsuarioIdTextBox.Text);
                usuario.UsuarioId = id;
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
                    Utilitarios.ShowToastr(this.Page, "Error al actualizar", "Error", "Error");
                }
                else
                {
                    if (usuario.Editar())
                    {
                        Utilitarios.ShowToastr(this.Page, "Se han actualizado los datos", "Correcto", "Actualizado");
                        Limpiar();
                    }
                    else
                    {
                        Utilitarios.ShowToastr(this.Page, "Error al actualizar los datos", "Error", "Error");
                        Limpiar();
                    }

                }


            }
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            int id;
            Usuarios usuario = new Usuarios();
            id = Convert.ToInt32(UsuarioIdTextBox.Text);
            if (UsuarioIdTextBox.Text.Length > 0)
            {
                usuario.UsuarioId = id;
                if (usuario.Eliminar())
                {
                    Utilitarios.ShowToastr(this.Page, "Se han eliminado los datos", "Correcto", "Eliminado");
                    Limpiar();
                }
                else
                {
                    Utilitarios.ShowToastr(this.Page, "Error al eliminar los datos", "Error", "Error");

                }
            }
            else
            {
                Utilitarios.ShowToastr(this.Page, "Ingrese un Id", "Error", "Error");

            }
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            int id;
            Usuarios usuario = new Usuarios();
            id = Convert.ToInt32(UsuarioIdTextBox.Text);
            if (UsuarioIdTextBox.Text.Length > 0)
            {
                usuario.UsuarioId = id;
                if (usuario.Buscar(id))
                {
                    NombresTextBox.Text = usuario.Nombres;
                    ApellidosTextBox.Text = usuario.Apellidos;
                    DireccionTextBox.Text = usuario.Direccion;
                    TelefonoTextBox.Text = usuario.Telefono;
                    CelularTextBox.Text = usuario.Celular;
                    EmailTextBox.Text = usuario.Email;
                    UsuarioTextBox.Text = usuario.Usuario;
                    PassWordTextBox.Text = usuario.Contrasena;
                }

            }
            else
            {
                Utilitarios.ShowToastr(this.Page, "Ingrese un Id", "Error", "Error");
            }
        }

        protected void PassWord1TextBox_TextChanged(object sender, EventArgs e)
        {
            Usuarios usuario = new Usuarios();
            if (PassWord1TextBox.Text != PassWordTextBox.Text)
            {
                Utilitarios.ShowToastr(this, "Error", "Las contrasenas no son idanticas", "Error");
            }
        }
    }
}