using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
namespace VIPCinemaExpress.adm.Registros
{
    public partial class rPeliculas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void AddIdiomaButton_Click(object sender, EventArgs e)
        {
            IdiomaTextBox.Text = IdiomaDropDownList.SelectedItem.ToString();
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

                pelicula.FechaInicio = Convert.ToDateTime(FechaInicioTextBox.Text);
                pelicula.FechaFin = Convert.ToDateTime(FechaFinTextBox.Text);
                precio = Convert.ToDouble(PrecioTextBox.Text);
                pelicula.Precio = precio;
                pelicula.Imagen = imagenTextBox.Text;
                pelicula.Video = VideoTextBox.Text;

                if (pelicula.Insertar())
                {
                    HttpContext.Current.Response.Write("<SCRIPT>'Se han guardado los datos'</SCRIPT>");
                }
                else
                {
                    HttpContext.Current.Response.Write("<SCRIPT>'Error al guardado'</SCRIPT>");
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

                pelicula.FechaInicio = Convert.ToDateTime(FechaInicioTextBox.Text);
                pelicula.FechaFin = Convert.ToDateTime(FechaFinTextBox.Text);
                precio = Convert.ToDouble(PrecioTextBox.Text);
                pelicula.Precio = precio;
                pelicula.Imagen = imagenTextBox.Text;
                pelicula.Video = VideoTextBox.Text;

                if (pelicula.Insertar())
                {
                    HttpContext.Current.Response.Write("<SCRIPT>'Se han actualizado los datos'</SCRIPT>");
                }
                else
                {
                    HttpContext.Current.Response.Write("<SCRIPT>'Error al actualizar los datos'</SCRIPT>");
                }
            }
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            
            Peliculas pelicula = new Peliculas();

            if (PeliculaIdTextBox.Text.Length < 0)
            {
                HttpContext.Current.Response.Write("<SCRIPT>'Ingrese un Id'</SCRIPT>");
            }
            else
            {
                pelicula.PeliculaId = Convert.ToInt32(PeliculaIdTextBox.Text);

                if (pelicula.Eliminar())
                {
                    HttpContext.Current.Response.Write("<SCRIPT>'Se han eliminado los datos'</SCRIPT>");
                }
                else
                {
                    HttpContext.Current.Response.Write("<SCRIPT>'Error al eliminar'</SCRIPT>");
                }
            }
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
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
            imagenTextBox.Text = string.Empty;
            VideoTextBox.Text = string.Empty;
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
                imagenTextBox.Text = pelicula.Imagen;
                VideoTextBox.Text = pelicula.Video;
                if (pelicula.Subtitulo == 1)
                {
                    SubtiSiRadioButton.Checked = true;
                }
                else if(pelicula.Subtitulo == 0)
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


                //FechaInicioTextBox.Text = pelicula.FechaInicio;
                //FechaFinTextBox.Text = string.Empty;
            }
            
        }

        
    }
}