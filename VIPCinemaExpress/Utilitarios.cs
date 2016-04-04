using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VIPCinemaExpress
{
    public static class Utilitarios
    {
        public static void ShowToastr(this Page page, string message, string title, string type = "info")
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "toastr_message", String.Format("toastr.{0}('{1}', '{2}');", type.ToLower(), message, title), true);
        }

        public static bool ValidarEmail(string strMailAddress)
        {
            return Regex.IsMatch(strMailAddress, @"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))" + @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");
        }

        public static bool ValidarTelefono(string Telefono)
        {
            return Regex.IsMatch(Telefono, @"^[+-]?\d+(\.\d+)?$");
        }

        public static bool ValidarNombre(string Nombre)
        {
            return Regex.IsMatch(Nombre, @"[a-zA-ZñÑ\s]{2,50}");
        }

        public static bool ValidarSoloNumero(string Numero)
        {
            return Regex.IsMatch(Numero, @"[0-9]{1,9}(\.[0-9]{0,2})?$");
        }

    }
}