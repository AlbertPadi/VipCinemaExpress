<%@ Page Title="" Language="C#" MasterPageFile="~/adm/Site.Master" AutoEventWireup="true" CodeBehind="ListadoCines.aspx.cs" Inherits="VIPCinemaExpress.ReportViewers.ListadoCines" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
     <div id="page-wrapper">
        <div class="panel-body">
            <div class="form-horizontal col-md-12" role="form">
           
                <div class="row">
                    <div class="col-lg-12">
                        <h1 class="page-header">Reporte <small>Reporte Cines</small>
                        </h1>
                        <div class="form-group row">
                            <div class="col-xs-7">
                                <rsweb:ReportViewer ID="CinesReportViewer" runat="server" BackColor="#99FFCC" BorderColor="#0099CC" CssClass="form-control" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt">
                                    <LocalReport ReportPath="Rpts\CinesReport.rdlc">
                                    </LocalReport>
                                </rsweb:ReportViewer>
                            </div>
                            <asp:Button ID="ListarButton" CssClass="btn btn-info" runat="server" Text="Listar" OnClick="ListarButton_Click" />
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>
        </form>
</asp:Content>
