using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
namespace VIPCinemaExpress.adm.Registros
{
    public partial class rArchivo : System.Web.UI.Page
    {
        int num, val;
        int res;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public int calcular(int valor)
        {
            
            
            for (int i = 0; i < valor; i++)
            {
               res = num * valor;
            }
            return res;

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //System.IO. StreamReader sr = new System.IO.StreamReader("C:\\Users\\Apache\\Desktop\\TestFile.txt");

            //ArchivoTextBox.Text = sr.ReadToEnd();

            val = Convert.ToInt32(ArchivoTextBox.Text);
            num = Convert.ToInt32(NumTextBox.Text);
            ResTextBox.Text = Convert.ToString(calcular(val));
        }
    }
}