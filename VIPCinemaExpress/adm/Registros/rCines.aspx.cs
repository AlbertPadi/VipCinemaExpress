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
        
        int esActiva;
        int cont = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
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
            SalasGridView.DataSource = null;
            SalasGridView.DataBind();

        }
        protected void AddSalasButton_Click(object sender, EventArgs e)
        {
            
            Cines cine;
            if (EsActivaCheckBox.Checked == true)
            {
                esActiva = 1;
            }
            else
            {
                esActiva = 0;
            }
            if (Session["Cine"] == null)
                Session["Cine"] = new Cines(); 


            cine = (Cines)Session["Cine"];


            cine.AgregarSalas((string)NombreSalaTextBox.Text, Convert.ToInt32(NoAsientosTextBox.Text), esActiva);
            //cont=+1;
            Session["Cine"] = cine;

            SalasGridView.DataSource = cine.Sala;
            SalasGridView.DataBind();

            NombreSalaTextBox.Text = "";
            NoAsientosTextBox.Text = "";
            EsActivaCheckBox.Checked = false;
           // CanSalasTextBox.Text = cont.ToString();
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            int id;
        
           

            Cines cines = new Cines();

            if (CineIdTextBox.Text.Length <= 0)
            {
                foreach (GridViewRow dr in SalasGridView.Rows)
                {
                    cines.AgregarSalas(Convert.ToString(dr.Cells[0].Text), Convert.ToInt32(dr.Cells[1].Text), esActiva);
                }
                cines.Nombres = NombreTextBox.Text;
                cines.Ciudad = CiudadTextBox.Text;
                cines.Telefono = TelefonoTextBox.Text;
                cines.Direccion = DireccionTextBox.Text;
                cines.Email = EmailTextBox.Text;
                //cines.CantidadSalas = Convert.ToInt32(CanSalasTextBox.Text);

                if (cines.Insertar())
                {
                    Utilitarios.ShowToastr(this.Page, "Se han guardado los datos", "Guardado", "Success");
                    Limpiar();
                }
                else
                {
                    Utilitarios.ShowToastr(this.Page, "Error al guardar los datos", "Error", "Error");
                }
            }
            else if (CineIdTextBox.Text.Length > 0)
            {
                id = Convert.ToInt32(CineIdTextBox.Text);
                cines.CineId = id;
                foreach (GridViewRow dr in SalasGridView.Rows)
                {
                    cines.AgregarSalas(Convert.ToString(dr.Cells[0].Text), Convert.ToInt32(dr.Cells[1].Text), esActiva);
                }
                cines.Nombres = NombreTextBox.Text;
                cines.Ciudad = CiudadTextBox.Text;
                cines.Telefono = TelefonoTextBox.Text;
                cines.Direccion = DireccionTextBox.Text;
                cines.Email = EmailTextBox.Text;
                //cines.CantidadSalas = Convert.ToInt32(CanSalasTextBox.Text);

                if (cines.Editar())
                {
                    Utilitarios.ShowToastr(this.Page, "Se han actualizado los datos", "Guardado", "Success");
                    Limpiar();
                }
                else
                {
                    Utilitarios.ShowToastr(this.Page, "Error al actualizar los datos", "Error", "Error");
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
                Utilitarios.ShowToastr(this.Page, "Ingrese un id", "Error", "Error");

            }

            if (cines.Eliminar())
            {
                Utilitarios.ShowToastr(this.Page, "Se han eliminado los datos", "Eliminado", "Eliminado");
            }
            else
            {
                Utilitarios.ShowToastr(this.Page, "Error al eliminar los datos", "Error", "Error");
            }
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            Cines cine = new Cines();
            int id;
            id = Convert.ToInt32(CineIdTextBox.Text);

            if (CineIdTextBox.Text.Length > 0)
            {
                if (cine.Buscar(id))
                {

                    cine.CineId = id;
                    NombreTextBox.Text = cine.Nombres;
                    CiudadTextBox.Text = cine.Ciudad;
                    DireccionTextBox.Text = cine.Direccion;
                    TelefonoTextBox.Text = cine.Telefono;
                    EmailTextBox.Text = cine.Email;

                    SalasGridView.DataSource = cine.Sala;
                    SalasGridView.DataBind();

                }
                else
                {
                    Utilitarios.ShowToastr(this.Page, "Error al buscar los datos", "Error", "Error");
                }

            }
            else
            {
                Utilitarios.ShowToastr(this.Page, "Ingrese un id", "Error", "Error");
            }



        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
    }

    
    }