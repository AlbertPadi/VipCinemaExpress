﻿<%@ Page Title="" Language="C#" MasterPageFile="~/SiteUser.Master" AutoEventWireup="true" CodeBehind="rReservaciones.aspx.cs" Inherits="VIPCinemaExpress.rReservaciones" %>

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
    <div id="wrapper">
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
                                <div class="col-xs-3">
                                    <asp:TextBox ID="FechaTextBox" type="date" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group row">
                                <div class="col-xs-2">
                                    <asp:Label ID="Label2" runat="server" Text="Cine"></asp:Label>
                                </div>
                                <div class="col-xs-3">
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
                                <asp:Button ID="AgregarCSButton" CssClass="btn btn-primary" runat="server" Text="Agregar" />
                            </div>

                            <asp:GridView ID="CineGridView" class="table" runat="server"></asp:GridView>

                            <div class="form-group row">
                                <div class="col-xs-2">
                                    <asp:Label ID="Label3" runat="server" Text="Cantidad"></asp:Label>
                                </div>
                                <div class="col-xs-3">
                                    <asp:TextBox ID="CantidadTextBox" class="form-control" runat="server" placeholder="Cantidad"></asp:TextBox>
                                </div>
                            </div>

                            <asp:GridView ID="PeliculaGridView" Class="table" runat="server"></asp:GridView>
                            <div class="form-group">
                                <div class="col-xs-2">
                                    <asp:Label ID="Label6" runat="server" Text="Monto"></asp:Label>
                                </div>
                                <div class="col-xs-3">
                                    <asp:TextBox ID="MontoTextBox" class="form-control" runat="server" placeholder="Monto" ReadOnly="True"></asp:TextBox>
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
                                <div class="col-md-offset-2">
                                    <asp:Button ID="NuevoButton" class="btn btn-default" runat="server" Text="Nuevo" Width="137px" />
                                    <asp:Button ID="ReservarButton" CssClass="btn btn-info" runat="server" Text="Reservar" Width="137px"/>
                                </div>

                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>







</asp:Content>
