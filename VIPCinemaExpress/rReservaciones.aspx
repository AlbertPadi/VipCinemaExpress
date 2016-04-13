<%@ Page Title="" Language="C#" MasterPageFile="~/SiteUser.Master" AutoEventWireup="true" CodeBehind="rReservaciones.aspx.cs" Inherits="VIPCinemaExpress.rReservaciones" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="http://cdn.jsdelivr.net/webshim/1.12.4/extras/modernizr-custom.js"></script>
    <!-- polyfiller file to detect and load polyfills -->
    <script src="http://cdn.jsdelivr.net/webshim/1.12.4/polyfiller.js"></script>
    <script>
        webshims.setOptions('waitReady', false);
        webshims.setOptions('forms-ext', { types: 'date' });
        webshims.polyfill('forms forms-ext');
</script>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div id="page-wrapper">
        <div class="container">
            <div class="panel-body">
                <div class="form-horizontal col-md-12" role="form">
                    <!-- Page Heading -->
                    <div class="row">
                        <div class="col-lg-12">
                            <h1 class="page-header">Vip Cinema Express <small>Reservaciones</small>
                            </h1>



                            <div class="form-group row">
                                <div class="col-xs-2">
                                    <asp:Label ID="Label4" runat="server" Text="Fecha"></asp:Label>
                                </div>
                                <div class="col-md-3">
                                    <asp:TextBox ID="FechaTextBox" runat="server"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="FechaCalendarExtender" runat="server" TargetControlID="FechaTextBox" />
                                </div>
                            </div>



                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="form-group row">
                                        <div class="col-xs-2">
                                            <asp:Label ID="Label2" runat="server" Text="Cine"></asp:Label>
                                        </div>
                                        <div class="col-md-3">
                                            <asp:DropDownList ID="CinesDropDownList" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="CinesDropDownList_SelectedIndexChanged" runat="server"></asp:DropDownList>

                                        </div>
                                    </div>

                                    <div class="form-group row">
                                        <div class="col-xs-2">
                                            <asp:Label ID="Label1" runat="server" Text="Sala"></asp:Label>
                                        </div>
                                        <div class="col-xs-3">
                                            <asp:DropDownList ID="SalaDropDownList" CssClass="form-control" runat="server"></asp:DropDownList>

                                        </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>

                        </div>
                        <div class="form-group row">
                            <div class="col-xs-2">
                                <asp:Label ID="Label3" runat="server" Text="Cantidad"></asp:Label>
                            </div>
                            <div class="col-xs-3">
                                <asp:TextBox ID="CantidadTextBox" class="form-control" runat="server" placeholder="Cantidad"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                                    ControlToValidate="CantidadTextBox"
                                    ValidationExpression="^\d+"
                                    Display="Static"
                                    ErrorMessage="Only Numbers"
                                    EnableClientScript="False"
                                    runat="server"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="form-group row">
                            <div class="col-md-offset-5">
                                <asp:Button ID="AgregarButton" runat="server" CssClass="btn btn-primary" Text="Agregar" OnClick="AgregarButton_Click1" />
                            </div>
                        </div>
                        <asp:GridView ID="CineSalaGridView" class="table" runat="server"></asp:GridView>



                        <div class="form-group row">
                            <div class="col-xs-2">
                                <asp:Label ID="Label7" runat="server" Text="Total"></asp:Label>
                            </div>
                            <div class="col-md-3">
                                <asp:TextBox ID="TotalTextBox" placeholder="Total" ReadOnly="true" runat="server"></asp:TextBox>
                            </div>
                        </div>


                        <div class="form-group row">
                            <div class="col-xs-2">
                                <asp:Label ID="Label6" runat="server" Text="Cantidad Reservas"></asp:Label>
                            </div>
                            <div class="col-md-3">
                                <asp:TextBox ID="CantidadTextBoxRes" placeholder="Cantidad Reservada" ReadOnly="true" runat="server"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="col-xs-2">
                                <asp:Label ID="Label5" runat="server" Text="Tarjeta"></asp:Label>
                            </div>
                            <div class="col-xs-3">
                                <asp:DropDownList ID="TarjetaDropDownList" CssClass="form-control" runat="server">
                                    <asp:ListItem Value="1">Visa</asp:ListItem>
                                    <asp:ListItem Value="2">Master Card</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-offset-3">
                                <asp:Button ID="NuevoButton" class="btn btn-default" runat="server" Text="Nuevo" />
                                <asp:Button ID="ReservarButton" CssClass="btn btn-info" runat="server" Text="Reservar" OnClick="ReservarButton_Click" />
                            </div>

                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
