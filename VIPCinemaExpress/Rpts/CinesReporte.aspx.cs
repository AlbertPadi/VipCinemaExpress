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

                Padilla.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
                Padilla.Reset();
                Padilla.LocalReport.ReportPath = Server.MapPath(@"~\Reportes/CinesReport.rdlc");
                
                Padilla.LocalReport.DataSources.Clear();
               
                Padilla.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSet1", cine.Listado(" * ", "1=1", "")));
                Padilla.LocalReport.Refresh();
            }
        }
    }
}