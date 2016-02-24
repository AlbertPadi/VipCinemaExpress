﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
namespace VIPCinemaExpress.adm.Registros
{
    public partial class rUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void NombresTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            Usuarios usuario = new Usuarios();

            if (UsuarioIdTextBox.Text.Length == 0)
            {
                usuario.Nombres = NombresTextBox.Text;
                usuario.Apellidos = ApellidosTextBox.Text;
                usuario.Direccion = DireccionTextBox.Text;
                usuario.Telefono = TelefonoTextBox.Text;
                usuario.Celular = CelularTextBox.Text;
                usuario.Email = EmailTextBox.Text;
                usuario.Usuario = UsuarioTextBox.Text;
                usuario.Contrasena = PassWordTextBox.Text;
                
            }
            else
            {
                usuario.Nombres = NombresTextBox.Text;
                usuario.Apellidos = ApellidosTextBox.Text;
                usuario.Direccion = DireccionTextBox.Text;
                usuario.Telefono = TelefonoTextBox.Text;
                usuario.Celular = CelularTextBox.Text;
                usuario.Email = EmailTextBox.Text;
                usuario.Usuario = UsuarioTextBox.Text;
                usuario.Contrasena = PassWordTextBox.Text;

                if (usuario.Editar())
                {
                    HttpContext.Current.Response.Write("<SCRIPT>alert('Se han guardado los datos')</SCRIPT>");
                }
                else
                {
                    HttpContext.Current.Response.Write("<SCRIPT>alert('No se han actualizado los datos')</SCRIPT>");
                }
            }
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            UsuarioIdTextBox.Text = string.Empty;
            NombresTextBox.Text = string.Empty;
            ApellidosTextBox.Text = string.Empty;
            DireccionTextBox.Text = string.Empty;
            TelefonoTextBox.Text = string.Empty;
            CelularTextBox.Text = string.Empty;
            EmailTextBox.Text = string.Empty;
            UsuarioTextBox.Text = string.Empty;
            PassWordTextBox.Text= string.Empty;
            PassWord1TextBox.Text = string.Empty;
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            int id;
            Usuarios usuario = new Usuarios();
            id = Convert.ToInt32(UsuarioIdTextBox.Text);
            if (UsuarioIdTextBox.Text.Length > 0)
            {
                usuario.UsuarioId = id;
                if (usuario.Eliminar())
                {
                    HttpContext.Current.Response.Write("<SCRIPT>alert('Se han eliminado los datos')</SCRIPT>");
                }
                else
                {
                    HttpContext.Current.Response.Write("<SCRIPT>alert('Error al eliminar')</SCRIPT>");
                }
            }
            else
            {
                HttpContext.Current.Response.Write("<SCRIPT>alert('Ingrese un Id')</SCRIPT>");
            }
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            int id;
            Usuarios usuario = new Usuarios();
            id = Convert.ToInt32(UsuarioIdTextBox.Text);
            if (UsuarioIdTextBox.Text.Length > 0)
            {
                usuario.UsuarioId = id;

                NombresTextBox.Text = usuario.Nombres;
                ApellidosTextBox.Text = usuario.Apellidos;
                DireccionTextBox.Text = usuario.Direccion;
                TelefonoTextBox.Text = usuario.Telefono;
                CelularTextBox.Text = usuario.Celular;
                EmailTextBox.Text = usuario.Email;
                UsuarioTextBox.Text = usuario.Usuario;
                PassWordTextBox.Text = usuario.Contrasena;
            }
            else
            {
                HttpContext.Current.Response.Write("<SCRIPT>alert('Ingrese un Id')</SCRIPT>");
            }
        }

        protected void PassWord1TextBox_TextChanged(object sender, EventArgs e)
        {
            Usuarios usuario = new Usuarios();
            if (PassWord1TextBox.Text != PassWordTextBox.Text)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No se registraron los datos')", true);
            }
        }
    }
}