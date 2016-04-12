using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DAL;
namespace BLL
{
    public class Usuarios : ClaseMaestra
    {
        public int UsuarioId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Usuario { get; set; }
        public string Contrasena { get; set; }
        public int Tipo { get; set; }

        public Usuarios()
        {
            this.UsuarioId = 0;
            this.Nombres = "";
            this.Apellidos = "";
            this.Direccion = "";
            this.Telefono = "";
            this.Celular = "";
            this.Email = "";
            this.Usuario = "";
            this.Contrasena = "";
            this.Tipo = 0;
        }



        public bool ValidarUsuario(string Usuario, string contra)
        {
            bool Encontro = false;
            DataTable dt = new DataTable();

            dt = this.Listado("UsuarioId, Usuario, Contrasena", "Usuario = '" + Usuario + "' and Contrasena = '" + contra + "'", "UsuarioId ASC");

            if (dt.Rows.Count > 0)
            {
                Encontro = true;

                this.Usuario = (string)dt.Rows[0]["Usuario"];
                this.Contrasena = (string)dt.Rows[0]["Contrasena"];
            }

            return Encontro;
        }

        //public bool ValidarUsuario(string Usuario, string contra, int tipo)
        //{
        //    bool Encontro = false;
        //    DataTable dt = new DataTable();

        //    dt = this.Listado("UsuarioId, Usuario, Contrasena, Tipo", "Usuario ='" + Usuario + " Contrasena = " + contra + "' and Tipo = '" + tipo +"'", "");

        //    if (dt.Rows.Count > 0)
        //    {
        //        Encontro = true;

        //        this.Usuario = (string)dt.Rows[0]["Usuario"];
        //        this.Contrasena = (string)dt.Rows[0]["Contrasena"];
        //        this.Tipo = (int)dt.Rows[0]["Tipo"];
        //    }

        //    return Encontro;
        //}


        public override bool Insertar()
        {
            bool retorno = false;
            ConexionDb conexion = new ConexionDb();
            retorno = conexion.Ejecutar(String.Format("Insert into Usuarios(Nombres, Apellidos, Direccion, Telefono, Celular, Email, Usuario, Contrasena, Tipo) values('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', {8})", this.Nombres, this.Apellidos, this.Direccion, this.Telefono, this.Celular, this.Email, this.Usuario, this.Contrasena, this.Tipo));
            return retorno;
        }

        public override bool Editar()
        {
            bool retorno = false;
            ConexionDb conexion = new ConexionDb();
            retorno = conexion.Ejecutar(String.Format("Update Usuarios set Nombres = '{0}', Apellidos = '{1}', Direccion = '{2}', Telefono = '{3}', Celular = '{4}', Email = '{5}', Usuario = '{6}', Contrasena = '{7}', Tipo = {8} where UsuarioId = {9}", this.Nombres, this.Apellidos, this.Direccion, this.Telefono, this.Celular, this.Email, this.Usuario, this.Contrasena, this.Tipo, this.UsuarioId));
            return retorno;
        }

        public override bool Eliminar()
        {
            bool retorno = false;
            ConexionDb conexion = new ConexionDb();
            retorno = conexion.Ejecutar(String.Format("Delete from Usuarios where UsuarioId = {0}", this.UsuarioId));
            return retorno;
        }

        public override bool Buscar(int IdBuscado)
        {
            ConexionDb conexion = new ConexionDb();
            DataTable dt = new DataTable();
            dt = conexion.ObtenerDatos(String.Format("select *from Usuarios where UsuarioId = {0}", IdBuscado));

            if (dt.Rows.Count > 0)
            {
                this.UsuarioId = IdBuscado;
                this.Nombres = dt.Rows[0]["Nombres"].ToString();
                this.Apellidos = dt.Rows[0]["Apellidos"].ToString();
                this.Direccion = dt.Rows[0]["Direccion"].ToString();
                this.Telefono = dt.Rows[0]["Telefono"].ToString();
                this.Celular = dt.Rows[0]["Celular"].ToString();
                this.Email = dt.Rows[0]["Email"].ToString();
                this.Usuario = dt.Rows[0]["Usuario"].ToString();
                this.Contrasena = dt.Rows[0]["Contrasena"].ToString();
            }

            return dt.Rows.Count > 0;
        }

        public bool ValidarNivelUsuario(string UsuarioBuscado)
        {
            bool Encontro = false;
            DataTable dt = new DataTable();

            dt = this.Listado("Tipo", "Usuario = '" + UsuarioBuscado + "'", "Usuario ASC");

            if (dt.Rows.Count > 0)
            {
                Encontro = true;

                this.Tipo = (int)dt.Rows[0]["Tipo"];

            }

            return Encontro;
        }

        public bool BuscarId(string UsuarioBuscado)
        {
            bool Encontro = false;
            DataTable dt = new DataTable();

            dt = this.Listado("*", "Usuario = '" + UsuarioBuscado + "'", "Usuario ASC");

            if (dt.Rows.Count > 0)
            {
                Encontro = true;

                this.UsuarioId = (int)dt.Rows[0]["UsuarioId"];
                this.Tipo = (int)dt.Rows[0]["Tipo"];
                this.Nombres = dt.Rows[0]["Nombres"].ToString();
                this.Apellidos = dt.Rows[0]["Apellidos"].ToString();
                this.Direccion = dt.Rows[0]["Direccion"].ToString();
                this.Telefono = dt.Rows[0]["Telefono"].ToString();
                this.Celular = dt.Rows[0]["Celular"].ToString();
                this.Email = dt.Rows[0]["Email"].ToString();
                this.Usuario = UsuarioBuscado;
                this.Contrasena = dt.Rows[0]["Contrasena"].ToString();

            }

            return Encontro;
        }

        public override DataTable Listado(string Campos, string Condicion, string Orden)
        {
            ConexionDb conexion = new ConexionDb();
            string OrdenFinal = string.Empty;
            if (!Orden.Equals(""))
            {
                OrdenFinal = " Order by " + Orden;
            }
            return conexion.ObtenerDatos("Select " + Campos + " from Usuarios where " + Condicion + " " + OrdenFinal);
        }
    }
}
