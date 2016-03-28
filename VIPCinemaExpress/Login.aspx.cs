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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Default defaul = new Default();
    
       
                Usuarios Usuario = new Usuarios();
                Boolean paso = false;

                paso = Usuario.ValidarUsuario(Usuariotextbox.Text, Passwordtextbox.Text);

                if (paso)
                {
                    FormsAuthentication.RedirectFromLoginPage(Usuario.Usuario, RememberCheckBox.Checked);
                    Response.Redirect("/default.aspx");
                }
            }
        }
    }
 