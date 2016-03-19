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
        protected void AgregarCSButton_Click(object sender, EventArgs e)
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
        public void Limpiar()
        {

            NombreTextBox.Text = string.Empty; ;
            PeliculaIdTextBox.Text = string.Empty;
            ClasificaiconTextBox.Text = string.Empty;
            IdiomaTextBox.Text = string.Empty;
            SubtiSiRadioButton.Checked = false;
            SubtiNoRadioButton.Checked = false;
            DirectorTextBox.Text = string.Empty;
            ActoresTextBox.Text = string.Empty;
            ActivaRadioButton.Checked = false;
            NoActivaRadioButton.Checked = false;
            FechaInicioTextBox.Text = string.Empty;
            FechaFinTextBox.Text = string.Empty;
            PrecioTextBox.Text = string.Empty;
            GeneroTextBox.Text = string.Empty;

        }
        protected void AddIdiomaButton_Click(object sender, EventArgs e)
        {
            IdiomaTextBox.Text = IdiomaDropDownList.SelectedItem.ToString();
        }

        private void GuardarArchivo(HttpPostedFile file)
        {
            // Se carga la ruta física de la carpeta temp del sitio
            string ruta = Server.MapPath("~/temp");

            // Si el directorio no existe, crearlo
            if (!Directory.Exists(ruta))
                Directory.CreateDirectory(ruta);

            string archivo = String.Format("{0}\\{1}", ruta, file.FileName);

            // Verificar que el archivo no exista
            if (File.Exists(archivo))
                Response.Write("<script>alert('Archivo ya Existe');</script>");
            else
            {
                file.SaveAs(archivo);
            }
        }
        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            Peliculas pelicula = new Peliculas();
            double precio;

            if (PeliculaIdTextBox.Text.Length == 0)
            {
                pelicula.Nombre = NombreTextBox.Text;
                pelicula.Genero = GeneroTextBox.Text;
                pelicula.Clasificacion = ClasificaiconTextBox.Text;
                pelicula.Idioma = IdiomaTextBox.Text;
                if (ImagenFileUpload.HasFile)
                {
                    string ext = ImagenFileUpload.PostedFile.FileName;
                    ext = ext.Substring(ext.LastIndexOf(".") + 1).ToLower();
                    string[] formatos = new string[] { "jpg", "jpeg", "bmp", "png", "gif" };

                    if (Array.IndexOf(formatos, ext) < 0)
                        Response.Write("<script>alert('Formato de imagen inválido.');</script>");
                    else
                        GuardarArchivo(ImagenFileUpload.PostedFile);
                    pelicula.Imagen =ImagenFileUpload.FileName;
                    Response.Write("<script>alert('Hola "+ pelicula.Imagen+"');</script>");
                }
                else
                    Response.Write("<script>alert('Seleccione un archivo del disco duro.');</script>");


                if (SubtiSiRadioButton.Checked == true)
                {
                    pelicula.Subtitulo = 1;
                }
                else if (SubtiNoRadioButton.Checked == true)
                {
                    pelicula.Subtitulo = 0;
                }
                pelicula.Director = DirectorTextBox.Text;
                pelicula.Actores = ActoresTextBox.Text;
                if (ActivaRadioButton.Checked == true)
                {
                    pelicula.Activa = 1;
                }
                else if (NoActivaRadioButton.Checked == true)
                {
                    pelicula.Activa = 0;
                }

                pelicula.FechaInicio = FechaInicioTextBox.Text;
                pelicula.FechaFin = FechaFinTextBox.Text;
                precio = Convert.ToDouble(PrecioTextBox.Text);
                pelicula.Precio = precio;

                if (pelicula.Insertar())
                {
                    Utilitarios.ShowToastr(this.Page, "Se han guardado los datos", "Guardado", "Guardado");
                    Limpiar();
                }
                else
                {
                    Utilitarios.ShowToastr(this.Page, "Error al guardar los datos", "Error", "Error");

                }
            }
            else
            {
                pelicula.PeliculaId = Convert.ToInt32(PeliculaIdTextBox.Text);
                pelicula.Nombre = NombreTextBox.Text;
                pelicula.Genero = GeneroTextBox.Text;
                pelicula.Clasificacion = ClasificaiconTextBox.Text;

                IdiomaTextBox.Text = IdiomaDropDownList.SelectedItem.ToString();
                pelicula.Idioma = IdiomaTextBox.Text;
                if (SubtiSiRadioButton.Checked == true)
                {
                    pelicula.Subtitulo = 1;
                }
                else if (SubtiNoRadioButton.Checked == true)
                {
                    pelicula.Subtitulo = 0;
                }
                pelicula.Director = DirectorTextBox.Text;
                pelicula.Actores = ActoresTextBox.Text;
                if (ActivaRadioButton.Checked == true)
                {
                    pelicula.Activa = 1;
                }
                else if (NoActivaRadioButton.Checked == true)
                {
                    pelicula.Activa = 0;
                }

                pelicula.FechaInicio = FechaInicioTextBox.Text;
                pelicula.FechaFin = FechaFinTextBox.Text;
                precio = Convert.ToDouble(PrecioTextBox.Text);
                pelicula.Precio = precio;

                if (pelicula.Insertar())
                {
                    Utilitarios.ShowToastr(this.Page, "Se han actualizado los datos", "Actalizado", "Actualizado");
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

            if (PeliculaIdTextBox.Text.Length < 0)
            {
                Utilitarios.ShowToastr(this.Page, "Ingrese un Id", "Error", "Error");
            }
            else
            {
                pelicula.PeliculaId = Convert.ToInt32(PeliculaIdTextBox.Text);

                if (pelicula.Eliminar())
                {
                    Utilitarios.ShowToastr(this.Page, "Se han eliminado los datos", "Eliminado", "Eliminado");
                }
                else
                {
                    Utilitarios.ShowToastr(this.Page, "Error al eliminar los datos", "Error", "Error");
                }
            }
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {

        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {

            Peliculas pelicula = new Peliculas();
            if (PeliculaIdTextBox.Text.Length < 0)
            {
                HttpContext.Current.Response.Write("<SCRIPT>'Ingrese un Id'</SCRIPT>");
            }
            else
            {
                pelicula.PeliculaId = Convert.ToInt32(PeliculaIdTextBox.Text);
                NombreTextBox.Text = pelicula.Nombre;
                GeneroTextBox.Text = pelicula.Genero;
                ClasificaiconTextBox.Text = pelicula.Clasificacion;
                IdiomaTextBox.Text = pelicula.Idioma;
                //ImagenFileUpload = pelicula.Imagen;
                if (pelicula.Subtitulo == 1)
                {
                    SubtiSiRadioButton.Checked = true;
                }
                else if (pelicula.Subtitulo == 0)
                {
                    SubtiNoRadioButton.Checked = true;
                }
                DirectorTextBox.Text = pelicula.Director;
                ActoresTextBox.Text = pelicula.Actores;

                if (pelicula.Activa == 1)
                {
                    ActivaRadioButton.Checked = true;
                }
                else if (pelicula.Activa == 0)
                {
                    NoActivaRadioButton.Checked = true;
                }


                FechaInicioTextBox.Text = pelicula.FechaInicio;
                FechaFinTextBox.Text = string.Empty;
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


    }
}