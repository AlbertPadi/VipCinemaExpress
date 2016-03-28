<%@ Page Title="" Language="C#" MasterPageFile="~/SiteUser.Master" AutoEventWireup="true" CodeBehind="rReservaciones.aspx.cs" Inherits="VIPCinemaExpress.rReservaciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div id="page-wrapper">
            <div class="panel-body">
                <div class="form-horizontal col-md-12" role="form">
                    <!-- Page Heading -->
                    <div class="row">
                        <div class="col-lg-12">
                            <h1 class="page-header">Vip Cinema Express <small>Reservaciones</small>
                            </h1>

                        </div>
                        <div class="form-group"><div class="col-xs-2">Fecha</div>
                            <div class="col-xs-3">
                                <asp:TextBox ID="FechaTextBox" CssClass="form-control" runat="server" ></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="col-md-2"></div>

                            <label class="control-label col-xs-2">CineId:</label>

                            <label class="control-label col-xs-2">Cantidad:</label>
                        </div>


                        <div class="form-group ">
                            <div class="col-xs-2"></div>
                            <div class="col-xs-3">
                                <asp:DropDownList ID="CinesDropDownList" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>

                            <div class="col-xs-4">

                                <asp:TextBox ID="CantidadTextBox" class="form-control" runat="server" placeholder="Cantidad"></asp:TextBox>
                            </div>

                            <asp:Button ID="BuscarButton" CssClass="btn btn-info" runat="server" Text="Agregar" />
                        </div>

                        <asp:GridView ID="CineGridView" class="table" runat="server"></asp:GridView>

                        <div class="form-group row">
                            <div class=" col-xs-12">
                                <asp:GridView ID="PeliculaGridView" Class="table" runat="server"></asp:GridView>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="control-label col-md-2">Monto:</label>
                            <div class="col-xs-8">
                                <asp:TextBox ID="MontoTextBox" class="form-control" runat="server" placeholder="Monto" ReadOnly="True"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="col-xs-2"></div>
                            <h2 class="col-xs-3"><small>Pago</small>
                            </h2>
                        </div>

                        <div class="form-group">
                            <div class="col-xs-2"></div>

                            <label class="control-label col-xs-4">Tipo tarjeta:</label>

                            <label class="control-label col-xs-3">Numero tarjeta:</label>
                        </div>

                        <div class="form-group ">
                            <div class="col-xs-2"></div>
                            <div class="col-xs-4">
                                <asp:DropDownList ID="TarjetaDropDownList" CssClass="form-control" runat="server">
                                    <asp:ListItem Value="1">Visa</asp:ListItem>
                                    <asp:ListItem Value="2">Master Card</asp:ListItem>
                                </asp:DropDownList>
                            </div>

                            <div class="col-xs-4">

                                <asp:TextBox ID="NumeroTarjetaTextBox" CssClass="form-control" runat="server" placeholder="Numero tarjeta"></asp:TextBox>
                            </div>

                        </div>

                        <div class="form-group">
                            <div class="col-xs-2"></div>

                            <label class="control-label col-xs-4">Mes Exp:</label>

                            <label class="control-label col-xs-3">Año Exp:</label>
                        </div>

                        <div class="form-group ">
                            <div class="col-xs-2"></div>
                            <div class="col-xs-4">
                                <asp:TextBox ID="MesExpTextBox" CssClass="form-control" runat="server" ></asp:TextBox>
                            </div>

                            <div class="col-xs-4">

                                <asp:TextBox ID="AnoExpTextBox" CssClass="form-control" runat="server" placeholder="Año Expide"></asp:TextBox>
                            </div>

                        </div>

                        <div class="form-group">
                            <div class="col-xs-offset-2 col-xs-9">
                                <asp:Button ID="NuevoButton" class="btn btn-default" runat="server" Text="Nuevo" />
                                <asp:Button ID="ReservarButton" CssClass="btn btn-info" runat="server" Text="Reservar" />
                            </div>
                        </div>

                    </div>
                </div>
            </div>

        </div>
</asp:Content>
