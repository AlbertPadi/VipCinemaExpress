using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Web.Security;

namespace VIPCinemaExpress.Include
{
    public partial class Menu : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Context.User.Identity.IsAuthenticated == true)
            {
                Usuarios Usuario = new Usuarios();

                string usuario = Context.User.Identity.Name;

                Usuario.ValidarNivelUsuario(usuario);

                if (Usuario.Tipo == 1)
                {

                    AdminPanelLabel.Attributes.Add("style", "visibility: hidden;");
                    AdminPanelLabel.Visible = false;
                    AdminPanelLabel.Enabled = false;


                }
            }
        }

        protected void EntrarButton_Click(object sender, EventArgs e)
        {
            Default defaul = new Default();


            Usuarios usuario = new Usuarios();
            Boolean paso = false;

            paso = usuario.ValidarUsuario(UsuarioTextbox.Text, PasswordTextBox.Text);

            if (paso)
            {

                FormsAuthentication.RedirectFromLoginPage(usuario.Usuario, RememberMeCheckBox.Checked);
                Response.Redirect("Default.aspx");

            }
            else
            {
                Utilitarios.ShowToastr(this.Page, "Error", "Revise usuario o contrasena", "Error");
            }
        }
    }
}