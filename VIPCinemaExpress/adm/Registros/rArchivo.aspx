<%@ Page Title="" Language="C#" MasterPageFile="~/adm/Site.Master" AutoEventWireup="true" CodeBehind="rArchivo.aspx.cs" Inherits="VIPCinemaExpress.adm.Registros.rArchivo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
        <div id="page-wrapper">
            <div class="panel-body">
                <div class="form-horizontal col-md-12" role="form">
                    <div class="form-group row">
                        <label class="control-label col-xs-2">Ingrese un dato:</label>
                        <div class="col-xs-8">
                            <asp:TextBox ID="ArchivoTextBox" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>

                    </div>
                    <div class="form-group row">
                        <label class="control-label col-xs-2">Ingrese otro dato:</label>
                        <div class="col-xs-8">
                            <asp:TextBox ID="NumTextBox" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group row">
                        <label class="control-label col-xs-2">Resultado:</label>
                        <div class="col-xs-8">
                            <asp:TextBox ID="ResTextBox" CssClass="form-control" runat="server" ReadOnly="True"></asp:TextBox>
                        </div>
                        <asp:Button ID="Button1" CssClass="btn btn-info" runat="server" Text="Calcular" OnClick="Button1_Click" />
                    </div>
                </div>



            </div>
        </div>
    </form>
</asp:Content>
