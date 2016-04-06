﻿<%@ Page Title="" Language="C#" MasterPageFile="~/SiteUser.Master" AutoEventWireup="true" CodeBehind="rUsuarios.aspx.cs" Inherits="VIPCinemaExpress.rUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
        <div id="page-wrapper">
            <div class="container-fluid">
                <!-- Page Heading -->
                <div class="row">
                    <div class="col-lg-12">
                        <h1 class="page-header">Vip Cinema Express <small>Registro Usuarios</small>
                        </h1>
                    </div>

                    <div class="form-group row">
                        <label class="control-label col-xs-3">Usuario ID:</label>
                        <div class="col-xs-3">
                            <asp:TextBox ID="UsuarioIdTextBox" class="form-control" runat="server" placeholder="Usuario Id"></asp:TextBox>
                        </div>
                        <asp:Button ID="BuscarButton" runat="server" class="btn btn-info" Text="Buscar" OnClick="BuscarButton_Click" />
                    </div>


                    <div class="form-group row">
                        <label class="control-label col-xs-3">Nombres:</label>
                        <div class="col-xs-9">
                            <asp:TextBox ID="NombresTextBox" class="form-control" runat="server" placeholder="Nombres"></asp:TextBox>

                        </div>
                    </div>

                    <div class="form-group row">
                        <label class="control-label col-xs-3">Apellidos:</label>
                        <div class="col-xs-9">
                            <asp:TextBox ID="ApellidosTextBox" class="form-control" runat="server" placeholder="Apellidos"></asp:TextBox>
                        </div>
                    </div>



                    <div class="form-group row">
                        <label class="control-label col-xs-3">Telefono:</label>
                        <div class="col-xs-9">
                            <asp:TextBox ID="TelefonoTextBox" class="form-control" runat="server" placeholder="Telefono"></asp:TextBox>
                        </div>
                    </div>



                    <div class="form-group row">
                        <label class="control-label col-xs-3">Celular:</label>
                        <div class="col-xs-9">
                            <asp:TextBox ID="CelularTextBox" class="form-control" runat="server" placeholder="Celular"></asp:TextBox>
                        </div>
                    </div>


                    <div class="form-group row">
                        <label class="control-label col-xs-3">Dirección:</label>
                        <div class="col-xs-9">
                            <asp:TextBox ID="DireccionTextBox" class="form-control" runat="server" placeholder="Direccion"></asp:TextBox>
                        </div>
                    </div>



                    <div class="form-group row">
                        <label class="control-label col-xs-3">Email:</label>
                        <div class="col-xs-9">
                            <asp:TextBox ID="EmailTextBox" class="form-control" runat="server" placeholder="Email"></asp:TextBox>
                        </div>
                    </div>



                    <div class="form-group row">
                        <label class="control-label col-xs-3">Usuario:</label>
                        <div class="col-xs-9">
                            <asp:TextBox ID="UsuarioTextBox" class="form-control" runat="server" placeholder="Usuario"></asp:TextBox>
                        </div>
                    </div>



                    <div class="form-group row">
                        <label class="control-label col-xs-3">Password:</label>
                        <div class="col-xs-9">
                            <asp:TextBox ID="PassWordTextBox" TextMode="Password" class="form-control" runat="server" placeholder="Password"></asp:TextBox>
                        </div>
                    </div>


                    <div class="form-group row">
                        <label class="control-label col-xs-3">Confirmar Password:</label>
                        <div class="col-xs-9">
                            <asp:TextBox ID="PassWord1TextBox" TextMode="Password" class="form-control" runat="server" placeholder="Confirm Password" OnTextChanged="PassWord1TextBox_TextChanged"></asp:TextBox>
                        </div>
                    </div>


                    <div class="form-group row">
                        <div class="col-xs-offset-3 col-xs-9">
                            <asp:Button ID="NuevoButton" class="btn btn-default" runat="server" Text="Nuevo" OnClick="NuevoButton_Click" />
                            <asp:Button ID="GuardarButton" class="btn btn-primary" runat="server" Text="Guardar" OnClick="GuardarButton_Click" />
                            <asp:Button ID="EliminarButton" class="btn btn-danger" runat="server" Text="Eliminar" OnClick="EliminarButton_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>

</asp:Content>