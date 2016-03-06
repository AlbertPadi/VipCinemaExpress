<%@ Page Title="" Language="C#" MasterPageFile="~/adm/Site.Master" AutoEventWireup="true" CodeBehind="rReservaciones.aspx.cs" Inherits="VIPCinemaExpress.adm.Registros.rReservaciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--Copiar este Pedazo de Codigo para todos los registros y consultas.-->
    <form runat="server">
        <div id="page-wrapper">
            <div class="panel-body">
                <div class="form-horizontal col-md-12" role="form">
                    <!-- Page Heading -->
                    <div class="row">
                        <div class="col-lg-12">
                            <h1 class="page-header">Vip Cinema Express <small>Reservaciones</small>
                            </h1>
                            <ol class="breadcrumb">
                                <li class="active">
                                    <i class="fa fa-dashboard"></i>Cambiar este Texto
                            </li>
                            </ol>
                        </div>

                        <div class="form-group ">
                            <label for="ReservacionIdTextBox" class="control-label col-xs-3">Reservacion ID:</label>
                            <div class="col-xs-8">
                                <asp:TextBox ID="ReservacionIdTextBox" class="form-control" runat="server" placeholder="Reservacion Id"></asp:TextBox>
                            </div>
                            <asp:Button ID="BuscarButton" Class="btn btn-sm btn-info" runat="server" Text="Buscar" />

                        </div>


                        <div class="form-group">
                            <label class="control-label col-xs-3">CineId:</label>
                            <div class="col-xs-8">
                                <div class="dropdown">
                                    <asp:DropDownList ID="CinesDropDownList" class="form-control" runat="server" OnSelectedIndexChanged="CinesDropDownList_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                                <asp:TextBox ID="CineIdTextBox" class="form-control" runat="server" placeholder="Cine Id" OnTextChanged="CineIdTextBox_TextChanged" ReadOnly="True"></asp:TextBox>
                            </div>
                            <asp:Button ID="BuscarCineButton" runat="server" class="btn btn-info" Text="Agregar" OnClick="BuscarCineButton_Click1" />
                        </div>

                        <div class="form-group">
                            <label class="control-label col-xs-3">UsuarioId:</label>
                            <div class="col-xs-8">
                                <asp:TextBox ID="UsuarioIdTextBox" class="form-control" runat="server" placeholder="Usuario Id"></asp:TextBox>
                            </div>

                        </div>

                        <div class="form-group">
                            <label class="control-label col-xs-3">Sala Id:</label>
                            <div class="col-xs-8">
                                <div class="dropdown">
                                    <asp:DropDownList ID="SalaIdDropDownList" class="form-control" runat="server"></asp:DropDownList>
                                </div>
                                <asp:TextBox ID="SalaIdTextBox" class="form-control" runat="server" placeholder="SalaId Id"></asp:TextBox>

                            </div>
                            <asp:Button ID="AddSalaButton" runat="server" class="btn btn-info" TextMode="MultiLine" Text="Agregar" OnClick="AddSalaButton_Click" />
                        </div>

                        <div class="form-group">

                            <div class="col-xs-9">
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="control-label col-xs-3">Pelicula Id:</label>
                            <div class="col-xs-8">
                                <div class="dropdown">
                                    <asp:DropDownList ID="PeliculaIdDropDownList" class="form-control dropdown-toggle" runat="server"></asp:DropDownList>
                                </div>
                                <textarea id="PeliculaTextArea" class="form-control" cols="20" rows="2"></textarea>

                            </div>
                            <asp:Button ID="AddPeliculaButton" runat="server" class="btn btn-info" Text="Agregar" />
                        </div>


                        <div class="form-group">
                            <label class="control-label col-xs-3">Cantidad:</label>
                            <div class="col-xs-8">
                                <asp:TextBox ID="CantidadTextBox" class="form-control" runat="server" placeholder="Cantidad"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="control-label col-xs-3">Monto:</label>
                            <div class="col-xs-9">
                                <asp:TextBox ID="MontoTextBox" class="form-control" runat="server" placeholder="Monto" ReadOnly="True"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="control-label col-xs-3">Realizar pago:</label>
                            <div class="col-xs-9">
                                <asp:Button ID="PagoButton" class="btn btn-link" runat="server" Text="CLIK AQUI para hacer su pago" />
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="col-xs-offset-3 col-xs-9">
                                <asp:Button ID="NuevoButton" class="btn btn-default" runat="server" Text="Nuevo" />
                                <asp:Button ID="GuardarButton" class="btn btn-primary" runat="server" Text="Guardar" OnClick="GuardarButton_Click" />
                                <asp:Button ID="EliminarButton" class="btn btn-danger" runat="server" Text="Eliminar" />
                            </div>
                        </div>

                    </div>
                </div>
        </div>
     
        </div>
    </form>
    <!--Hasta aqui, Copiar este Pedazo de Codigo para todos los registros y consultas.-->
</asp:Content>
