<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rCarteleras.aspx.cs" Inherits="VIPCinemaExpress.Registros.rCarteleras" %>

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
                        <h1 class="page-header">Vip Cinema Express <small>Registro carteleras</small>
                        </h1>
                        <ol class="breadcrumb">
                            <li class="active">
                                <i class="fa fa-dashboard"></i>Cambiar este Texto
                            
                            </li>
                        </ol>
                    </div>
                    <!-- Componentes -->
                    <div class="form-group row">
                        <label class="control-label col-xs-2">Cartelera Id:</label>
                        <div class="col-xs-4">
                            <asp:TextBox ID="CarteleraIdTextBox" class="form-control" runat="server" placeholder="Cartelera Id"></asp:TextBox>
                        </div>
                        <asp:Button ID="BuscarButton" runat="server" class="btn btn-info" Text="Buscar" />
                    </div>

                    <div class="form-group row">
                        <label class="control-label col-xs-2">Pelicula Id:</label>
                        <div class="col-xs-4">
                            <asp:TextBox ID="PeliculaIdTextBox" class="form-control" runat="server" placeholder="Pelicula Id"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group row">
                        <div class="col-xs-offset-2 col-xs-9">
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
