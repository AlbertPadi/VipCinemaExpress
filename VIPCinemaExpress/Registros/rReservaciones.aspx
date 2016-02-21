<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rReservaciones.aspx.cs" Inherits="VIPCinemaExpress.Registros.rReservaciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--Copiar este Pedazo de Codigo para todos los registros y consultas.-->
    <form runat="server">
        <div id="page-wrapper">
            <div class="container-fluid">
                <!-- Page Heading -->
                <div class="row">
                    <div class="col-lg-12">
                        <h1 class="page-header">Cambiar este Texto <small>Cambiar este texto tambien.</small>
                        </h1>
                        <ol class="breadcrumb">
                            <li class="active">
                                <i class="fa fa-dashboard"></i>Cambiar este Texto
                            </li>
                        </ol>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-xs-3">Reservacion ID:</label>
                        <div class="col-xs-4">
                            <asp:TextBox ID="ReservacionIdTextBox" class="form-control" runat="server" placeholder="Reservacion Id"></asp:TextBox>
                        </div>
                        <asp:Button ID="BuscarButton" runat="server" class="btn btn-info" Text="Buscar" />
                    </div>

                    <div class="form-group">
                        <label class="control-label col-xs-3">CineId:</label>
                        <div class="col-xs-4">
                            <asp:TextBox ID="CineIdTextBox" class="form-control" runat="server" placeholder="Cine Id" OnTextChanged="CineIdTextBox_TextChanged"></asp:TextBox>
                        </div>
                        <asp:Button ID="BuscarCineButton" runat="server" class="btn btn-info" Text="Buscar" />

                        <div class="col-xs-2">
                            <div class="dropdown">
                              <button class="btn btn-primary dropdown-toggle" ID="dropDownL" type="button" data-toggle="dropdown">Buscar Cines
                              <span class="caret"></span></button>
                              <ul class="dropdown-menu">
                                <li><a href="#">HTML</a></li>
                                <li><a href="#">CSS</a></li>
                                <li><a href="#">JavaScript</a></li>
                              </ul>
                            </div>
                        </div>
                         
                    </div>

                    <div class="form-group">
                        <label class="control-label col-xs-3">UsuarioId:</label>
                        <div class="col-xs-9">
                            <asp:TextBox ID="UsuarioIdTextBox" class="form-control" runat="server" placeholder="Usuario Id"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="control-label col-xs-3">Sala Id:</label>
                        <div class="col-xs-9">
                            <asp:TextBox ID="SalaIdTextBox" class="form-control" runat="server" placeholder="SalaId Id"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="control-label col-xs-3">Cantidad:</label>
                        <div class="col-xs-9">
                            <asp:TextBox ID="CantidadTextBox" class="form-control" runat="server" placeholder="Cantidad"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="control-label col-xs-3">Monto:</label>
                        <div class="col-xs-9">
                            <asp:TextBox ID="MontoTextBox" class="form-control" runat="server" placeholder="Monto"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-xs-offset-3 col-xs-9">
                            <asp:Button ID="NuevoButton" class="btn btn-default" runat="server" Text="Nuevo" />
                            <asp:Button ID="GuardarButton" class="btn btn-primary" runat="server" Text="Guardar" />
                            <asp:Button ID="EliminarButton" class="btn btn-danger" runat="server" Text="Eliminar" />
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </form>
    <!--Hasta aqui, Copiar este Pedazo de Codigo para todos los registros y consultas.-->
</asp:Content>
