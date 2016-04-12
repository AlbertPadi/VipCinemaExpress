using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Security;
using System.Web.UI.WebControls;
using BLL;
using System.Text.RegularExpressions;

namespace VIPCinemaExpress.adm.Registros
{
    public partial class rCines : System.Web.UI.Page
    {

        int esActiva;
        int cont = 0;
        int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SalasGridView.DataBind();
                EsActivaCheckBox.Checked = false;
            }

        }




        public void Limpiar()
        {
            CineIdTextBox.Text = "";
            NombreTextBox.Text = "";
            CiudadTextBox.Text = "";
            TelefonoTextBox.Text = "";
            DireccionTextBox.Text = "";
            EmailTextBox.Text = "";
            CanSalasTextBox.Text = "";
            SalasGridView.DataSource = null;
            SalasGridView.DataBind();
            EsActivaCheckBox.Checked = false;
            CanSalasTextBox.Text = string.Empty;
            Session.Clear();
            Session.Abandon();

        }


        protected void AddSalasButton_Click(object sender, EventArgs e)
        {
            if (CineIdTextBox.Text == "")
            {
                if (EsActivaCheckBox.Checked == true)
                {
                    esActiva = 1;
                }
                else
                {
                    esActiva = 0;
                }
            }
            Cines cine;

            if (Session["Cine"] == null)
                Session["Cine"] = new Cines();


            cine = (Cines)Session["Cine"];


            cine.AgregarSalas((string)NombreSalaTextBox.Text, Convert.ToInt32(NoAsientosTextBox.Text), esActiva);

            Session["Cine"] = cine;

            SalasGridView.DataSource = cine.Sala;
            SalasGridView.DataBind();

            NombreSalaTextBox.Text = "";
            NoAsientosTextBox.Text = "";

            int co = 0;
            foreach (GridViewRow row in SalasGridView.Rows)
            {
                co++;
                CanSalasTextBox.Text = co.ToString();
            }
            cine.CantidadSalas = Convert.ToInt32(CanSalasTextBox.Text);
        }


        protected void GuardarButton_Click(object sender, EventArgs e)
        {



            Cines cines = new Cines();
            if (CineIdTextBox.Text.Length == 0)
            {
                foreach (GridViewRow dr in SalasGridView.Rows)
                {
                    cines.AgregarSalas(Convert.ToString(dr.Cells[0].Text), Convert.ToInt32(dr.Cells[1].Text), esActiva);
                }
                cines.CantidadSalas = Convert.ToInt32(CanSalasTextBox.Text);

                cines.Nombres = NombreTextBox.Text;
                cines.Ciudad = CiudadTextBox.Text;
                cines.Telefono = TelefonoTextBox.Text;
                cines.Direccion = DireccionTextBox.Text;
                cines.Email = EmailTextBox.Text;
                SalasGridView.DataSource = null;
                SalasGridView.DataBind();

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
            else
            {
                int id;
                id = Convert.ToInt32(CineIdTextBox.Text);
                cines.CineId = id;

                cines.Nombres = NombreTextBox.Text;
                cines.Ciudad = CiudadTextBox.Text;
                cines.Telefono = TelefonoTextBox.Text;
                cines.Direccion = DireccionTextBox.Text;
                cines.Email = EmailTextBox.Text;
                SalasGridView.DataSource = null;
                SalasGridView.DataBind();
                foreach (GridViewRow dr in SalasGridView.Rows)
                {
                    cines.AgregarSalas(Convert.ToString(dr.Cells[0].Text), Convert.ToInt32(dr.Cells[1].Text), esActiva);
                }
                cines.CantidadSalas = Convert.ToInt32(CanSalasTextBox.Text);
                if (cines.Editar())
                {
                    Utilitarios.ShowToastr(this.Page, "Se han actualizado los datos", "Actualizado", "Success");
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

            Cines cines = new Cines();
            if (CineIdTextBox.Text == "" || CineIdTextBox.Text.Length == 0)
            {
                Utilitarios.ShowToastr(this.Page, "!debe ingresar un id", "!Error", "Error");
            }
            else
            {
                if (CineIdTextBox.Text.Length > 0)
                {
                    cineId = Convert.ToInt32(CineIdTextBox.Text);
                    cines.CineId = cineId;
                    if (cines.Eliminar())
                    {
                        Utilitarios.ShowToastr(this.Page, "Se han eliminado los datos", "Eliminado", "Success");
                        Limpiar();
                    }
                    else
                    {
                        Utilitarios.ShowToastr(this.Page, "Error al eliminar los datos", "Error", "Error");

                    }
                }
            }




        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            Cines cine = new Cines();


            if (CineIdTextBox.Text == "")
            {
                Utilitarios.ShowToastr(this.Page, "Debe ingresar un Id", "Error", "Error");
            }
            else
                if (CineIdTextBox.Text.Length > 0)
            {
                id = Convert.ToInt32(CineIdTextBox.Text);
                if (cine.Buscar(id))
                {

                    cine.CineId = id;
                    NombreTextBox.Text = cine.Nombres;
                    CiudadTextBox.Text = cine.Ciudad;
                    DireccionTextBox.Text = cine.Direccion;
                    TelefonoTextBox.Text = cine.Telefono;
                    EmailTextBox.Text = cine.Email;
                    CanSalasTextBox.Text = cine.CantidadSalas.ToString();
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
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
    }


}