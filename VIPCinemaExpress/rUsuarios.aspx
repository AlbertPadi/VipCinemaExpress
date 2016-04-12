<%@ Page Title="" Language="C#" MasterPageFile="~/SiteUser.Master" AutoEventWireup="true" CodeBehind="rUsuarios.aspx.cs" Inherits="VIPCinemaExpress.rUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div id="page-wrapper">
        <div class="container">
            <div class="panel-body">
                <!-- Page Heading -->
                <div class="row">
                    <div class="col-lg-12">
                        <h1 class="page-header">Vip Cinema Express <small>Registro Usuarios</small>
                        </h1>
                    </div>

                    <div class="form-group row">
                        <label class="control-label col-xs-3">Nombres:</label>
                        <div class="col-xs-9">
                            <asp:TextBox ID="NombresTextBox" class="form-control" runat="server" placeholder="Nombres"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="NombresTextBox"
                                ValidationExpression="[a-zA-Z ]*$" ErrorMessage="*Valid characters: Alphabets and space." />

                        </div>
                    </div>

                    <div class="form-group row">
                        <label class="control-label col-xs-3">Apellidos:</label>
                        <div class="col-xs-9">
                            <asp:TextBox ID="ApellidosTextBox" class="form-control" runat="server" placeholder="Apellidos"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="ApellidosTextBox"
                                ValidationExpression="[a-zA-Z ]*$" ErrorMessage="*Valid characters: Alphabets and space." />
                        </div>
                    </div>



                    <div class="form-group row">
                        <label class="control-label col-xs-3">Telefono:</label>
                        <div class="col-xs-9">
                            <asp:TextBox ID="TelefonoTextBox" class="form-control" runat="server" placeholder="Telefono"></asp:TextBox>
                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" Mask="(999)-999-9999"
                                AcceptNegative="None" MessageValidatorTip="true" TargetControlID="TelefonoTextBox"
                                MaskType="Number" ClearMaskOnLostFocus="false" ClearTextOnInvalid="false" />

                        </div>
                    </div>



                    <div class="form-group row">
                        <label class="control-label col-xs-3">Celular:</label>
                        <div class="col-xs-9">
                            <asp:TextBox ID="CelularTextBox" class="form-control" runat="server" placeholder="Celular"></asp:TextBox>
                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender2" runat="server" Mask="(999)-999-9999"
                                AcceptNegative="None" MessageValidatorTip="true" TargetControlID="CelularTextBox"
                                MaskType="Number" ClearMaskOnLostFocus="false" ClearTextOnInvalid="false" />
                        </div>
                    </div>


                    <div class="form-group row">
                        <label class="control-label col-xs-3">Dirección:</label>
                        <div class="col-xs-9">
                            <asp:TextBox ID="DireccionTextBox" class="form-control" runat="server" placeholder="Direccion"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="DireccionTextBox" ValidationExpression="^[a-zA-Z0-9.@]{0,25}$" ErrorMessage="Only Alphanumeric"></asp:RegularExpressionValidator>

                        </div>
                    </div>



                    <div class="form-group row">
                        <label class="control-label col-xs-3">Email:</label>
                        <div class="col-xs-9">
                            <asp:TextBox ID="EmailTextBox" class="form-control" runat="server" placeholder="Email"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="validateEmail"
                                runat="server" ErrorMessage="Invalid email."
                                ControlToValidate="EmailTextBox"
                                ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$" />

                        </div>
                    </div>



                    <div class="form-group row">
                        <label class="control-label col-xs-3">Usuario:</label>
                        <div class="col-xs-9">
                            <asp:TextBox ID="UsuarioTextBox" class="form-control" runat="server" placeholder="Usuario"></asp:TextBox>
                            <asp:RegularExpressionValidator id="RegularExpressionValidator4" runat="server" ControlToValidate="UsuarioTextBox" ValidationExpression="^[a-zA-Z0-9.@]{0,25}$" ErrorMessage="Only Alphanumeric"></asp:RegularExpressionValidator>

                        </div>
                    </div>



                    <div class="form-group row">
                        <label class="control-label col-xs-3">Password:</label>
                        <div class="col-xs-9">
                            <asp:TextBox ID="PassWordTextBox" TextMode="Password" class="form-control" runat="server" placeholder="Password"></asp:TextBox>
                            <asp:RegularExpressionValidator id="RegularExpressionValidator5" runat="server" ControlToValidate="PassWordTextBox" ValidationExpression="^[a-zA-Z0-9.@]{0,25}$" ErrorMessage="Only Alphanumeric"></asp:RegularExpressionValidator>

                        </div>
                    </div>


                    <div class="form-group row">
                        <label class="control-label col-xs-3">Confirmar Password:</label>
                        <div class="col-xs-9">
                            <asp:TextBox ID="PassWord1TextBox" TextMode="Password" class="form-control" runat="server" placeholder="Confirm Password" OnTextChanged="PassWord1TextBox_TextChanged"></asp:TextBox>
                       <asp:RegularExpressionValidator id="RegularExpressionValidator6" runat="server" ControlToValidate="PassWord1TextBox" ValidationExpression="^[a-zA-Z0-9.@]{0,25}$" ErrorMessage="Only Alphanumeric"></asp:RegularExpressionValidator>

                             </div>
                    </div>


                    <div class="form-group row">
                        <div class="col-xs-offset-3 col-xs-9">
                            <asp:Button ID="NuevoButton" class="btn btn-default" runat="server" Text="Nuevo" OnClick="NuevoButton_Click" />
                            <asp:Button ID="GuardarButton" class="btn btn-primary" runat="server" Text="Guardar" OnClick="GuardarButton_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
