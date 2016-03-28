using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VIPCinemaExpress.ReportViewers
{
    public partial class ListadoCines : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ListarButton_Click(object sender, EventArgs e)
        {
            CinesReportViewer.Visible = true;
        }
    }
}