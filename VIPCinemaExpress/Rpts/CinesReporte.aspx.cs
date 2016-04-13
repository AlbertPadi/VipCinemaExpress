using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
namespace VIPCinemaExpress.Rpts
{
    public partial class CinesReporte : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                Cines cine = new Cines();

                //CinesReportViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
                //CinesReportViewer.Reset();
                //CinesReportViewer.LocalReport.ReportPath = Server.MapPath(@"~\Reportes/CinesRpt.rdlc");

                //CinesReportViewer.LocalReport.DataSources.Clear();

                //CinesReportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSet1", cine.Listado(" * ", "1=1", "")));
                //CinesReportViewer.LocalReport.Refresh();
            }
        }
    }
}