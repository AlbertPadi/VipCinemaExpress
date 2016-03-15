<%@ Page Title="" Language="C#" MasterPageFile="~/adm/Site.Master" AutoEventWireup="true" CodeBehind="rPeliculas.aspx.cs" Inherits="VIPCinemaExpress.adm.Registros.rPeliculas" %>

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
                    </div>

                    <!-- Componentes -->
                    <div class="form-group row">
                        <label class="control-label col-xs-2">PeliculaId ID:</label>
                        <div class="col-xs-3">
                            <asp:TextBox ID="PeliculaIdTextBox" class="form-control" runat="server" placeholder="Pelicula Id"></asp:TextBox>

                        </div>

                        <div class="row col-xs-6">
                            <asp:Button ID="BuscarButton" runat="server" class="btn btn-info" Text="Buscar" OnClick="BuscarButton_Click" Width="84px" />
                        </div>
                    </div>

                    <div class="form-group row">
                        <label class="control-label col-xs-2">Nombre:</label>
                        <div class="col-xs-3">
                            <asp:TextBox ID="NombreTextBox" class="form-control" runat="server" placeholder="Nombre"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group row">
                        <label class="control-label col-xs-2">Genero:</label>
                        <div class="col-xs-3">
                            <asp:TextBox ID="GeneroTextBox" class="form-control" runat="server" placeholder="Genero"></asp:TextBox>
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
                        <div class="col-xs-3">
                            <asp:DropDownList ID="IdiomaDropDownList" CssClass="form-control" runat="server">
                                <asp:ListItem>Ingles</asp:ListItem>
                                <asp:ListItem>Español latino</asp:ListItem>
                                <asp:ListItem>Mandarin</asp:ListItem>
                                <asp:ListItem>Castellano</asp:ListItem>
                                <asp:ListItem>Portugues</asp:ListItem>
                                <asp:ListItem>Frances</asp:ListItem>
                                <asp:ListItem>Alemán</asp:ListItem>
                            </asp:DropDownList>
                            <asp:TextBox ID="IdiomaTextBox" class="form-control" runat="server" placeholder="Idioma"></asp:TextBox>
                        </div>
                        <asp:Button ID="AddIdiomaButton" class="btn btn-info" runat="server" Text="Add" Width="84px" OnClick="AddIdiomaButton_Click"></asp:Button>
                    </div>


                    <div class="form-group row">
                        <label class="control-label col-xs-2">Subtitulo:</label>
                        <div class="col-xs-9">
                            Si
                            <asp:RadioButton ID="SubtiSiRadioButton" runat="server" />
                            No
                            <asp:RadioButton ID="SubtiNoRadioButton" runat="server" />
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
                            <asp:TextBox ID="ActoresTextBox" class="form-control" runat="server" placeholder="Actores" TextMode="MultiLine"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group row">
                        <label class="control-label col-xs-2">Activa:</label>
                        <div class="col-xs-9">
                            Si
                            <asp:RadioButton ID="ActivaRadioButton" runat="server" />
                            No
                            <asp:RadioButton ID="NoActivaRadioButton" runat="server" />
                        </div>
                    </div>

                    <div class="form-group row">
                        <label class="control-label col-xs-2">Fecha inicio:</label>
                        <div class="col-xs-9">
                            <asp:TextBox ID="FechaInicioTextBox" class="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <script type="text/javascript">
                        $(document).ready(function () {
                            $('#FechaInicioTextBox').datepicker();
                        });
                    </script>

                    <div class="form-group row">
                        <label class="control-label col-xs-2">Fecha fin:</label>
                        <div class="col-xs-9">
                            <asp:TextBox id="FechaFinTextBox" class="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group row">
                        <label class="control-label col-xs-2">Precio:</label>
                        <div class="col-xs-9">
                            <asp:TextBox ID="PrecioTextBox" class="form-control" placeholder="Precio" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group row">
                        <label class="control-label col-xs-2">Imagen:</label>
                        <div class="col-xs-6">
                            <asp:FileUpload ID="ImagenFileUpload" class="btn btn-facebook" runat="server" />
                        </div>
                    </div>


                    <div class="form-group row">
                        <label class="control-label col-xs-2">Vidoe:</label>
                        <div class="col-xs-9">
                        </div>
                    </div>

                    <div class="form-group row">
                        <div class="col-xs-offset-2 col-xs-9">
                            <asp:Button ID="NuevoButton" class="btn btn-default" runat="server" Text="Nuevo" OnClick="NuevoButton_Click" />
                            <asp:Button ID="GuardarButton" class="btn btn-primary" runat="server" Text="Guardar" OnClick="GuardarButton_Click" />
                            <asp:Button ID="EliminarButton" class="btn btn-danger" runat="server" Text="Eliminar" OnClick="EliminarButton_Click" />
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </form>
    <!--Hasta aqui, Copiar este Pedazo de Codigo para todos los registros y consultas.-->
</asp:Content>
