using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Web.Security;

namespace VIPCinemaExpress
{
    public partial class SiteUser : System.Web.UI.MasterPage
    {
        int tipo;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {

        }

        protected void IngresarButton_Click(object sender, EventArgs e)
        {
            Default defaul = new Default();


            Usuarios Usuario = new Usuarios();
            Boolean paso = false;

            paso = Usuario.ValidarUsuario(UsuarioTextBox.Text, ContrasenaTextBox.Text);

            if (paso)
            {
                if (Usuario.Tipo == 0)
                {
                    FormsAuthentication.RedirectFromLoginPage(Usuario.Usuario, RememberCheckBox.Checked);
                    Response.Redirect("/adm/Default.aspx");
                }
                else
                {
                    FormsAuthentication.RedirectFromLoginPage(Usuario.Usuario, RememberCheckBox.Checked);
                    Response.Redirect("/Default.aspx");
                }

            }
            else
            {
                Utilitarios.ShowToastr(this.Page, "Error", "Revise usuario o contrasena", "Error");
            }
        }
    }
}