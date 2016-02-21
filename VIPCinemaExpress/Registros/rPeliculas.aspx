<%@ Page Title="" Language="C#" MasterPageFile="~/adm/Site.Master" AutoEventWireup="true" CodeBehind="rPeliculas.aspx.cs" Inherits="VIPCinemaExpress.Registros.rPeliculas" %>

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
                        <h1 class="page-header">Vip Cinema Express <small>Registro Peliculas</small>
                        </h1>
                        <ol class="breadcrumb">
                            <li class="active">
                                <i class="fa fa-dashboard"></i>Registre peliculas desde este formulario
                              
                            </li>
                        </ol>
                    </div>

                    <!-- Componentes -->
                    <div class="form-group row">
                        <label class="control-label col-xs-2">PeliculaId ID:</label>
                        <div class="col-xs-3">
                            <asp:TextBox ID="PeliculaIdTextBox" class="form-control" runat="server" placeholder="Pelicula Id"></asp:TextBox>
                            
                        </div>
                        <div class="row col-xs-4">
                            <asp:Button ID="BuscarButton" runat="server" class="btn btn-info" Text="Buscar" />
                        </div>
                    </div>

                    <div class="form-group row">
                        <label class="control-label col-xs-2">Clasificacion:</label>
                        <div class="col-xs-9">
                            <asp:TextBox ID="ClasificaiconTextBox" class="form-control" runat="server" placeholder="Clasificacion"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group row">
                        <label class="control-label col-xs-2">Idioma:</label>
                        <div class="col-xs-9">
                            <asp:DropDownList ID="IdiomaDropDownList" runat="server"></asp:DropDownList>
                            <asp:TextBox ID="IdiomaTextBox" class="form-control" runat="server" placeholder="Idioma"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group row">
                        <label class="control-label col-xs-2">Subtitulo:</label>
                        <div class="col-xs-9">
                            Si <asp:RadioButton ID="SubtiSiRadioButton" runat="server" />    No <asp:RadioButton ID="SubtiNoRadioButton" runat="server" />
                        </div>
                    </div>

                    <div class="form-group row">
                        <label class="control-label col-xs-2">Director:</label>
                        <div class="col-xs-9">
                            <asp:TextBox ID="DirectorTextBox" class="form-control" runat="server" placeholder="Director"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group row">
                        <label class="control-label col-xs-2">Actores:</label>
                        <div class="col-xs-9">
                            <asp:TextBox ID="ActoresTextBox" class="form-control" runat="server" placeholder="Actores"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group row">
                        <label class="control-label col-xs-2">Activa:</label>
                        <div class="col-xs-9">
                            
                           Si <asp:RadioButton ID="ActivaRadioButton" runat="server" />    No <asp:RadioButton ID="NoActivaRadioButton" runat="server" />
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
