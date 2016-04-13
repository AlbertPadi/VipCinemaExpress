<%@ Page Title="" Language="C#" MasterPageFile="~/adm/Site.Master" AutoEventWireup="true" CodeBehind="cReservaciones.aspx.cs" Inherits="VIPCinemaExpress.adm.Consultas.cReservaciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div id="page-wrapper">
            <div class="panel-body">
                <div class="form-horizontal col-md-12" role="form">
                    <div class="row">
                        <div class="col-lg-12">
                            <h1 class="page-header">Vip Cinema Express<small> Consulta reservaciones</small>
                            </h1>
                        </div>
                        <div class="form-goup row">
                            <label class="control-label col-xs-2">Listar por:</label>
                            <div class="col-md-4">
                                <asp:DropDownList ID="DatosDropDownList" CssClass="form-control" runat="server">
                                    <asp:ListItem Value="1">ReservacionId</asp:ListItem>
                                    <asp:ListItem Value="2">UsuarioId</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="DatosTextBox" CssClass="form-control" placeholder="Buscar por" runat="server"></asp:TextBox>
                            </div>
                            <asp:Button ID="BuscarButton" CssClass="btn btn-info" runat="server" Text="Buscar" OnClick="BuscarButton_Click" />
                        </div>
                        <div class="col-xs-12">
                            <asp:GridView ID="DatosGridView" CssClass="table" runat="server"></asp:GridView>
                        </div>

                        <div class="col-xs-12">
                            <asp:Button ID="ImprimirButton" CssClass="btn btn-info" runat="server" Text="Imprimir" />
                        </div>
                    </div>
            </div>
        </div>
        </div>

</asp:Content>
