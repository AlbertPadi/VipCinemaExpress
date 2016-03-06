<%@ Page Title="" Language="C#" MasterPageFile="~/adm/Site.Master" AutoEventWireup="true" CodeBehind="rCines.aspx.cs" Inherits="VIPCinemaExpress.adm.Registros.rCines" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
        <div id="page-wrapper">
            <div class="panel-body">
                <div class="form-horizontal col-md-12" role="form">
                    <!-- Page Heading -->
                    <div class="row">
                        <div class="col-lg-12">
                            <h1 class="page-header">Vip Cinema Express <small>Registro Cines</small>
                            </h1>

                        </div>

                        <!-- Componentes -->
                        <div class="form-group row">
                            <label class="control-label col-xs-2">Cine Id:</label>
                            <div class="col-xs-4">
                                <asp:TextBox ID="CineIdTextBox" class="form-control" runat="server" placeholder="Cine Id"></asp:TextBox>
                            </div>
                            <asp:Button ID="BuscarButton" runat="server" class="btn btn-info" Text="Buscar" OnClick="BuscarButton_Click" />
                        </div>

                        <div class="form-group row">

                            <label class="control-label col-xs-2">Nombre:</label>
                            <div class="col-xs-6">
                                <asp:TextBox ID="NombreTextBox" class="form-control" runat="server" placeholder="Nombre"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group row">
                            <label class="control-label col-xs-2">Ciudad:</label>
                            <div class="col-xs-6">
                                <asp:TextBox ID="CiudadTextBox" class="form-control" runat="server" placeholder="Ciudad"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group row">
                            <label class="control-label col-xs-2">Direccion:</label>
                            <div class="col-xs-6">
                                <asp:TextBox ID="DireccionTextBox" class="form-control" runat="server" placeholder="Direccion"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group row">
                            <label class="control-label col-xs-2">Telefono:</label>
                            <div class="col-xs-6">
                                <asp:TextBox ID="TelefonoTextBox" class="form-control" runat="server" placeholder="Telefono"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group row">
                            <label class="control-label col-xs-2">Email:</label>
                            <div class="col-xs-6">
                                <asp:TextBox ID="EmailTextBox" class="form-control" runat="server" placeholder="Email"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label class="control-label col-xs-2">Agrager Sala:</label>
                        </div>

                        <div class="form-group row">
                            <label for="NombreSalaTextBox" class="control-label col-xs-2">Nombre sala:</label>
                            <div class="col-xs-6">
                                <asp:TextBox ID="NombreSalaTextBox" CssClass="form-control" placeholder="Nombre sala" runat="server"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group row">
                            <label for="NoAsientosTextBox" class="control-label col-xs-2">No. Asientos:</label>
                            <div class="col-xs-6">
                                <asp:TextBox ID="NoAsientosTextBox" CssClass="form-control" placeholder="No Asientos" runat="server"></asp:TextBox>
                            </div>
                            <asp:Button ID="AddSalasButton" class="btn btn-info" runat="server" Text="Add" OnClick="AddSalasButton_Click" />
                        </div>

                        <div class="form-group row">
                            <label for="NombreSalaTextBox" class="control-label col-xs-2">Activa:</label>
                            <div class="col-xs-4">
                                <asp:CheckBox ID="EsActivaCheckBox" runat="server" />

                            </div>
                        </div>

                        <div class="form-group row">
                            <div class=" col-xs-12">

                                <asp:GridView ID="SalasGridView" CssClass="table" runat="server"></asp:GridView>
                            </div>
                        </div>

                        <div class="form-group row">
                            <label class="control-label col-xs-2">Cantidad Salas:</label>
                            <div class="col-xs-6">
                                <asp:TextBox ID="CanSalasTextBox" class="form-control" runat="server" placeholder="Cantidad Salas" ReadOnly="True"></asp:TextBox>
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

        </div>


    </form>
    <!--Hasta aqui, Copiar este Pedazo de Codigo para todos los registros y consultas.-->
</asp:Content>
