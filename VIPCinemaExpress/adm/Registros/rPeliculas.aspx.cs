using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.IO;

namespace VIPCinemaExpress.adm.Registros
{
    public partial class rPeliculas : System.Web.UI.Page
    {
        string img;
        int id;
        DateTime Variable1 = new DateTime();
        DateTime Variable2 = new DateTime();
        protected void Page_Load(object sender, EventArgs e)
        {
            //FechaInicioTextBox.Text = DateTime.Now.ToString("yyyy-MM-dddd hh:mm:ss");
            //FechaFinTextBox.Text = DateTime.Now.ToString("yyyy-MM-dddd hh:mm:ss");
            if (!IsPostBack)
            {
                Cines cines = new Cines();
                CineDropDownList.DataSource = cines.Listado(" * ", "1=1", "");
                CineDropDownList.DataTextField = "Nombre";
                CineDropDownList.DataValueField = "CineId";
                CineDropDownList.DataBind();

                CinesSalasDetalle CinesSalas = new CinesSalasDetalle();
                SalaDropDownList.DataSource = CinesSalas.Listado("CinesSalasId, NombreSala", "CineId = " + CineDropDownList.SelectedValue, "");
                SalaDropDownList.DataTextField = "NombreSala";
                SalaDropDownList.DataValueField = "CinesSalasId";
                SalaDropDownList.DataBind();

            }
        }

        public void Limpiar()
        {

            NombreTextBox.Text = string.Empty; ;
            PeliculaIdTextBox.Text = string.Empty;
            ClasificaiconTextBox.Text = string.Empty;
            SubtituloCheckBox.Checked = false;
            DirectorTextBox.Text = string.Empty;
            ActoresTextBox.Text = string.Empty;
            ActivaCheckBox.Checked = false;
            FechaInicioTextBox.Text = string.Empty;
            FechaFinTextBox.Text = string.Empty;
            PrecioTextBox.Text = string.Empty;
            GeneroTextBox.Text = string.Empty;
            CinesSalasGridView.DataSource = "";
            CinesSalasGridView.DataBind();
            Session.Clear();
            Session.Abandon();


        }
        protected void AddIdiomaButton_Click(object sender, EventArgs e)
        {

        }

        private void GuardarArchivo(HttpPostedFile file)
        {
            // Se carga la ruta física de la carpeta temp del sitio
            string ruta = Server.MapPath("~/temp");

            // Si el directorio no existe, crearlo
            if (!Directory.Exists(ruta))
                Directory.CreateDirectory(ruta);

            string archivo = String.Format("{0}\\{1}", ruta, file.FileName);

            file.SaveAs(archivo);

        }
        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            Peliculas pelicula = new Peliculas();
            double precio;

            if (PeliculaIdTextBox.Text == "")
            {
                foreach (GridViewRow item in CinesSalasGridView.Rows)
                {
                    pelicula.AddCinesSalas(Convert.ToInt32(item.Cells[1].Text), Convert.ToInt32(item.Cells[2].Text));
                }

                pelicula.Nombre = NombreTextBox.Text;
                pelicula.Genero = GeneroTextBox.Text;
                pelicula.Clasificacion = ClasificaiconTextBox.Text;
                pelicula.Idioma = IdiomaDropDownList.SelectedValue;
                if (ImagenFileUpload.HasFile)
                {
                    string ext = ImagenFileUpload.PostedFile.FileName;
                    ext = ext.Substring(ext.LastIndexOf(".") + 1).ToLower();
                    string[] formatos = new string[] { "jpg", "jpeg", "bmp", "png", "gif" };

                    if (Array.IndexOf(formatos, ext) < 0)
                        Response.Write("<script>alert('Formato de imagen inválido.');</script>");
                    else
                        GuardarArchivo(ImagenFileUpload.PostedFile);
                    pelicula.Imagen = "/temp/" + ImagenFileUpload.FileName;
                    Response.Write("<script>alert('Hola " + pelicula.Imagen + "');</script>");
                }
                else
                    Utilitarios.ShowToastr(this.Page, "Error", "Seleccione un archivo", "Error");


                if (SubtituloCheckBox.Checked == true)
                {
                    pelicula.Subtitulo = 1;
                }
                else if (SubtituloCheckBox.Checked == false)
                {
                    pelicula.Subtitulo = 0;
                }
                pelicula.Director = DirectorTextBox.Text;
                pelicula.Actores = ActoresTextBox.Text;
                if (ActivaCheckBox.Checked == true)
                {
                    pelicula.Activa = 1;
                }
                else if (ActivaCheckBox.Checked == false)
                {
                    pelicula.Activa = 0;
                }

                Variable1.ToString("yyyy-MM-dd hh:mm:ss tt");
                Variable2.ToString("yyyy-MM-dd hh:mm:ss tt");
                Variable1 = Convert.ToDateTime(FechaInicioTextBox.Text);
                Variable2 = Convert.ToDateTime(FechaFinTextBox.Text);
                pelicula.FechaFin = Variable2;
                pelicula.FechaInicio = Variable1;
                precio = Convert.ToDouble(PrecioTextBox.Text);
                pelicula.Precio = precio;

                if (pelicula.Insertar())
                {
                    Utilitarios.ShowToastr(this.Page, "Se han guardado los datos", "Guardado", "Success");
                    Limpiar();
                }
                else
                {
                    
                    Limpiar();
                }
            }
            else
            {
                int id = Convert.ToInt32(PeliculaIdTextBox.Text);

                pelicula.PeliculaId = id;
                pelicula.Nombre = NombreTextBox.Text;
                pelicula.Genero = GeneroTextBox.Text;
                pelicula.Clasificacion = ClasificaiconTextBox.Text;

                Variable1 = Convert.ToDateTime(FechaInicioTextBox.Text);
                Variable2 = Convert.ToDateTime(FechaFinTextBox.Text);
                pelicula.FechaFin = Variable2;
                pelicula.FechaInicio = Variable1;

                pelicula.Idioma = IdiomaDropDownList.SelectedValue;
                if (SubtituloCheckBox.Checked == true)
                {
                    pelicula.Subtitulo = 1;
                }
                else if (SubtituloCheckBox.Checked == false)
                {
                    pelicula.Subtitulo = 0;
                }
                pelicula.Director = DirectorTextBox.Text;
                pelicula.Actores = ActoresTextBox.Text;
                if (ActivaCheckBox.Checked == true)
                {
                    pelicula.Activa = 1;
                }
                else if (ActivaCheckBox.Checked == false)
                {
                    pelicula.Activa = 0;
                }

                precio = Convert.ToDouble(PrecioTextBox.Text);
                pelicula.Precio = precio;

                if (pelicula.Insertar())
                {
                    Utilitarios.ShowToastr(this.Page, "Se han actualizado los datos", "Actalizado", "Success");
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

            Peliculas pelicula = new Peliculas();

            if (PeliculaIdTextBox.Text == "")
            {
                Utilitarios.ShowToastr(this.Page, "!Ingrese un id", "Error", "Error");
            }
            else
            {
                if (PeliculaIdTextBox.Text.Length > 0)
                {
                    id = Convert.ToInt32(PeliculaIdTextBox.Text);
                }
                pelicula.PeliculaId = id;
                if (pelicula.Eliminar())
                {
                    Utilitarios.ShowToastr(this.Page, "Se han eliminado los datos", "Eliminado", "Success");
                }
                else
                {
                    Utilitarios.ShowToastr(this.Page, "Error al eliminar los datos", "Error", "Error");
                }

            }

        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {

            Peliculas pelicula = new Peliculas();
            if (PeliculaIdTextBox.Text == "")
            {
                Utilitarios.ShowToastr(this.Page, "!debe ingresar un id", "Error", "Error");
            }
            else
            {
                if (PeliculaIdTextBox.Text.Length > 0 || PeliculaIdTextBox.Text != "!@#$%^&*()_+./?><';:[`~,{")
                {
                    id = Convert.ToInt32(PeliculaIdTextBox.Text);
                }
                    if (pelicula.Buscar(id))
                    {
                        pelicula.PeliculaId = id;
                        NombreTextBox.Text = pelicula.Nombre;
                        GeneroTextBox.Text = pelicula.Genero;
                        ClasificaiconTextBox.Text = pelicula.Clasificacion;
                        IdiomaDropDownList.SelectedValue = pelicula.Idioma;
                        if (pelicula.Subtitulo == 1)
                        {
                            SubtituloCheckBox.Checked = true;
                        }
                        else if (pelicula.Subtitulo == 0)
                        {
                            SubtituloCheckBox.Checked = false;
                        }
                        DirectorTextBox.Text = pelicula.Director;
                        ActoresTextBox.Text = pelicula.Actores;

                        if (pelicula.Activa == 1)
                        {
                            ActivaCheckBox.Checked = true;
                        }
                        else if (pelicula.Activa == 0)
                        {
                            ActivaCheckBox.Checked = false;
                        }


                        FechaInicioTextBox.Text = pelicula.FechaInicio.ToString();
                        FechaFinTextBox.Text = pelicula.FechaFin.ToString();

                    }
                else
                {
                    Utilitarios.ShowToastr(this.Page, "!Id no valido", "Error", "Error");
                }

            }


        }

        protected void CineDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            CinesSalasDetalle CinesSalas = new CinesSalasDetalle();
            SalaDropDownList.DataSource = CinesSalas.Listado("CinesSalasId, NombreSala", "CineId = " + CineDropDownList.SelectedValue, "");
            SalaDropDownList.DataTextField = "NombreSala";
            SalaDropDownList.DataValueField = "CinesSalasId";
            SalaDropDownList.DataBind();
        }

        protected void AgregarButton_Click(object sender, EventArgs e)
        {
            Peliculas pelicula;
            if (Session["Pelicula"] == null)
                Session["Pelicula"] = new Peliculas();


            pelicula = (Peliculas)Session["Pelicula"];


            pelicula.AddCinesSalas(Convert.ToInt32(CineDropDownList.SelectedValue), Convert.ToInt32(SalaDropDownList.SelectedValue));
            Session["Pelicula"] = pelicula;
            CinesSalasGridView.DataSource = pelicula.Detalle;
            CinesSalasGridView.DataBind();
        }
    }
}