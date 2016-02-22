<%@ Page Title="" Language="C#" MasterPageFile="~/adm/Site.Master" AutoEventWireup="true" CodeBehind="rSalas.aspx.cs" Inherits="VIPCinemaExpress.adm.Registros.rSalas" %>

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
                        <h1 class="page-header">Vip Cinema Express <small>Registro Salas</small>
                        </h1>
                        <ol class="breadcrumb">
                            <li class="active">
                                <i class="fa fa-dashboard"></i>Cambiar este Texto
                            </li>
                        </ol>
                    </div>
                    <!-- Componentes -->
                    <div class="form-group row">
                        <label class="control-label col-xs-2">Sala Id:</label>
                        <div class="col-xs-4">
                            <asp:TextBox ID="SalaIdTextBox" class="form-control" runat="server" placeholder="SalaId Id"></asp:TextBox>
                        </div>
                        <asp:Button ID="BuscarButton" runat="server" class="btn btn-info" Text="Buscar" OnClick="BuscarButton_Click" />
                    </div>

                    <div class="form-group row">
                        <label class="control-label col-xs-2">CineId:</label>
                        <div class="col-xs-4">
                            <asp:TextBox ID="CineIdTextBox" class="form-control" runat="server" placeholder="Cine Id"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group row">
                        <label class="control-label col-xs-2">Numero asientos:</label>
                        <div class="col-xs-4">
                            <asp:TextBox ID="NoAsientoTextBox" class="form-control" runat="server" placeholder="Numero Asientos"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group row">
                        <label class="control-label col-xs-2">Descripcion:</label>
                        <div class="col-xs-4">
                            <asp:TextBox ID="DescripcionTextBox" TextMode="MultiLine" class="form-control" runat="server" placeholder="Descripcion"></asp:TextBox>
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
