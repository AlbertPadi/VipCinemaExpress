using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
namespace VIPCinemaExpress.adm.Registros
{
    public partial class rCines : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Salas sala = new Salas();
                SalasDropDownList.DataSource = sala.Listado(" * ", "1=1", "");
                SalasDropDownList.DataTextField = "Descripcion";
                SalasDropDownList.DataValueField = "SalaId";
                SalasDropDownList.DataBind();
            }
        }

        public void Limpiar()
        {
            CineIdTextBox.Text = string.Empty;
            NombreTextBox.Text = string.Empty;
            CiudadTextBox.Text = string.Empty;
            TelefonoTextBox.Text = string.Empty;
            DireccionTextBox.Text = string.Empty;
            EmailTextBox.Text = string.Empty;
            
        }
        protected void AddSalasButton_Click(object sender, EventArgs e)
        {
            SalasListBox.Items.Add(SalasDropDownList.Text);
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            Cines cines = new Cines();
            int Id = Convert.ToInt32(SalasDropDownList.SelectedValue);
            if (CineIdTextBox.Text.Length <= 0)
            {
                cines.Nombres = NombreTextBox.Text;
                cines.Ciudad = CiudadTextBox.Text;
                cines.Telefono = TelefonoTextBox.Text;
                cines.Direccion = DireccionTextBox.Text;
                cines.Email = EmailTextBox.Text;
                for (int i = 0; i < SalasListBox.Items.Count; i++)
                {
                    cines.AgregarSalas(Id);
                }
                if (cines.Insertar())
                {
                    HttpContext.Current.Response.Write("<SCRIPT>'Se han guardado los datos'</SCRIPT>");
                    Limpiar();
                }
                else
                {
                    HttpContext.Current.Response.Write("<SCRIPT>'Error al guardar los datos'</SCRIPT>");
                }
            }
            else if(CineIdTextBox.Text.Length > 0)
            {
                int cineId;
                cineId = Convert.ToInt32(CineIdTextBox.Text);
                cines.CineId = cineId;
                cines.Nombres = NombreTextBox.Text;
                cines.Ciudad = CiudadTextBox.Text;
                cines.Telefono = TelefonoTextBox.Text;
                cines.Direccion = DireccionTextBox.Text;
                cines.Email = EmailTextBox.Text;
                for (int i = 0; i < SalasListBox.Items.Count; i++)
                {
                    cines.AgregarSalas(Id);
                }
                if (cines.Editar())
                {
                    HttpContext.Current.Response.Write("<SCRIPT>'Se han actualizado los datos'</SCRIPT>");
                    Limpiar();
                }
                else
                {
                    HttpContext.Current.Response.Write("<SCRIPT>'Error al actualizar los datos'</SCRIPT>");
                }
                

            }
            }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            int cineId;
            cineId = Convert.ToInt32(CineIdTextBox.Text);
            Cines cines = new Cines();
            if (CineIdTextBox.Text.Length > 0)
            {
                cines.CineId = cineId;
            }
            else
            {
                HttpContext.Current.Response.Write("<SCRIPT>'Ingrese un Id'</SCRIPT>");
            }

            if (cines.Eliminar())
            {
                HttpContext.Current.Response.Write("<SCRIPT>'Se han eliminado los datos'</SCRIPT>");
            }
            else
            {
                HttpContext.Current.Response.Write("<SCRIPT>'Error al eliminar'</SCRIPT>");
            }
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            int cineId;
            cineId = Convert.ToInt32(CineIdTextBox.Text);
            Cines cines = new Cines();
            if (CineIdTextBox.Text.Length > 0)
            {
                cines.CineId = cineId;

                if (cines.Buscar(cineId))
                {

                    NombreTextBox.Text = cines.Nombres;
                    CiudadTextBox.Text = cines.Ciudad;
                    TelefonoTextBox.Text = cines.Telefono;
                    DireccionTextBox.Text = cines.Direccion;
                    EmailTextBox.Text = cines.Email;
                }
            }
            else
            {
                HttpContext.Current.Response.Write("<SCRIPT>'Inserte un Id'</SCRIPT>");
            }
            
        }

        
    }
    }