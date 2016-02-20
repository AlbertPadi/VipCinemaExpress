using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace VIPCinemaExpress.Consultas
{
    /// <summary>
    /// Summary description for MostrarImagen
    /// </summary>
    public class MostrarImagen : IHttpHandler
    {
        SqlConnection con = new SqlConnection();
        public void ProcessRequest(HttpContext context)
        {
            
            con.Open();
            SqlCommand cmd = new SqlCommand("Select Imagen from Peliculas where PeliculaId = @PeliculaId", con);
            cmd.Parameters.AddWithValue("PeliculaId", context.Request.QueryString["PeliculaId"]);

            byte[] foto = (byte[])cmd.ExecuteScalar();

            con.Close();
            context.Response.ContentType = "image/jpg";
            context.Response.OutputStream.Write(foto, 0, foto.Length);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}