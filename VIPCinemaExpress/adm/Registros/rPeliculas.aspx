<%@ Page Title="" Language="C#" MasterPageFile="~/adm/Site.Master" AutoEventWireup="true" CodeBehind="rPeliculas.aspx.cs" Inherits="VIPCinemaExpress.adm.Registros.rPeliculas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--    <script src="http://cdn.jsdelivr.net/webshim/1.12.4/extras/modernizr-custom.js"></script>--%>
    <script src="../../js/modernizr-custom.js"></script>
    <!-- polyfiller file to detect and load polyfills -->
    <script src="../../js/polyfiller.js"></script>
    <script src="http://cdn.jsdelivr.net/webshim/1.12.4/polyfiller.js"></script>
    <script>
        webshims.setOptions('waitReady', false);
        webshims.setOptions('forms-ext', { types: 'date' });
        webshims.polyfill('forms forms-ext');
</script>


</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script src="/scripts/jquery.date-dropdowns.js"></script>

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
                    <div class="col-xs-4">
                        <asp:TextBox ID="PeliculaIdTextBox" class="form-control" runat="server" placeholder="Pelicula Id"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                            ControlToValidate="PeliculaIdTextBox"
                            ValidationExpression="^\d+"
                            Display="Static"
                            ErrorMessage="Only Numbers"
                            EnableClientScript="False"
                            runat="server"></asp:RegularExpressionValidator>
                    </div>

                    <asp:Button ID="BuscarButton" runat="server" class="btn btn-info" Text="Buscar" OnClick="BuscarButton_Click" Width="84px" />

                </div>

                <div class="form-group row">
                    <label class="control-label col-xs-2">Nombre:</label>
                    <div class="col-xs-5">
                        <asp:TextBox ID="NombreTextBox" class="form-control" runat="server" placeholder="Nombre"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="NombreTextBox"
                            ValidationExpression="[a-zA-Z ]*$" ErrorMessage="*Valid characters: Alphabets and space." />

                    </div>
                </div>

                <div class="form-group row">
                    <label class="control-label col-xs-2">Genero:</label>
                    <div class="col-xs-5">
                        <asp:TextBox ID="GeneroTextBox" class="form-control" runat="server" placeholder="Genero"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="GeneroTextBox"
                            ValidationExpression="[a-zA-Z ]*$" ErrorMessage="*Valid characters: Alphabets and space." />
                    </div>
                </div>

                <div class="form-group row">
                    <label class="control-label col-xs-2">Clasificacion:</label>
                    <div class="col-xs-5">
                        <asp:TextBox ID="ClasificaiconTextBox" class="form-control" runat="server" placeholder="Clasificacion"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="ClasificaiconTextBox"
                            ValidationExpression="[a-zA-Z ]*$" ErrorMessage="*Valid characters: Alphabets and space." />
                    </div>
                </div>

                <div class="form-group row">
                    <label class="control-label col-xs-2">Idioma:</label>
                    <div class="col-xs-4">
                        <asp:DropDownList ID="IdiomaDropDownList" CssClass="form-control" runat="server">
                            <asp:ListItem>Ingles</asp:ListItem>
                            <asp:ListItem>Español latino</asp:ListItem>
                            <asp:ListItem>Mandarin</asp:ListItem>
                            <asp:ListItem>Castellano</asp:ListItem>
                            <asp:ListItem>Portugues</asp:ListItem>
                            <asp:ListItem>Frances</asp:ListItem>
                            <asp:ListItem>Alemán</asp:ListItem>
                        </asp:DropDownList>

                    </div>
                </div>


                <div class="form-group row">
                    <label class="control-label col-xs-2">Subtitulo:</label>
                    <div class="col-xs-3">
                        <asp:CheckBox ID="SubtituloCheckBox" CssClass="badge" runat="server" />
                    </div>
                </div>

                <div class="form-group row">
                    <label class="control-label col-xs-2">Director:</label>
                    <div class="col-xs-5">
                        <asp:TextBox ID="DirectorTextBox" class="form-control" runat="server" placeholder="Director"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="DirectorTextBox"
                            ValidationExpression="[a-zA-Z ]*$" ErrorMessage="*Valid characters: Alphabets and space." />

                    </div>
                </div>

                <div class="form-group row">
                    <label class="control-label col-xs-2">Actores:</label>
                    <div class="col-xs-5">
                        <asp:TextBox ID="ActoresTextBox" class="form-control" runat="server" placeholder="Actores" TextMode="MultiLine"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="ActoresTextBox"
                            ValidationExpression="[a-zA-Z ]*$" ErrorMessage="*Valid characters: Alphabets and space." />
                    </div>
                </div>

                <div class="form-group row">
                    <label class="control-label col-xs-2">Activa:</label>
                    <div class="col-xs-3">
                        <asp:CheckBox ID="ActivaCheckBox" CssClass="badge" runat="server" />

                    </div>
                </div>

                <div class="form-group row">
                    <label class="control-label col-xs-2">Duracion:</label>
                    <div class="col-xs-5">
                        <asp:TextBox ID="TiempoTextBox" class="form-control" runat="server"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator7"
                            ControlToValidate="TiempoTextBox"
                            ValidationExpression="^\d+"
                            Display="Static"
                            ErrorMessage="Only Numbers"
                            EnableClientScript="False"
                            runat="server"></asp:RegularExpressionValidator>
                    </div>
                </div>

                <div class="form-group row">

                    <label class="control-label col-xs-2">Desde :</label>
                    <div class="col-xs-5">
                        <asp:TextBox ID="FechaInicioTextBox" class="form-control" type="date" runat="server"></asp:TextBox>
                    </div>
                    <label class="control-label col-md-1">Hasta:</label>
                    <div class="col-xs-4">
                        <asp:TextBox ID="FechaFinTextBox" class="form-control" type="date" runat="server"></asp:TextBox>
                    </div>
                </div>
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="form-group row">
                            <div class="col-xs-2">
                                <asp:Label ID="CineLabel" runat="server" Text="Cine"></asp:Label>
                            </div>
                            <div class="col-xs-5">
                                <asp:DropDownList ID="CineDropDownList" CssClass="form-control" runat="server" OnSelectedIndexChanged="CineDropDownList_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                            </div>
                        </div>


                        <div class="form-group row">
                            <div class="col-xs-2">
                                <asp:Label ID="SalasLabel" runat="server" Text="Sala"></asp:Label>
                            </div>
                            <div class="col-xs-5">
                                <asp:DropDownList ID="SalaDropDownList" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>

                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div class="form-group row">
                    <div class="col-md-offset-6">
                        <asp:Button ID="AgregarButton" CssClass="btn btn-primary" runat="server" Text="Agregar" OnClick="AgregarButton_Click" />

                    </div>
                    <asp:GridView ID="CinesSalasGridView" CssClass="table" runat="server"></asp:GridView>
                </div>


                <div class="form-group row">
                    <label class="control-label col-xs-2">Precio:</label>
                    <div class="col-xs-5">
                        <asp:TextBox ID="PrecioTextBox" class="form-control" placeholder="Precio" runat="server"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator8"
                            ControlToValidate="PrecioTextBox"
                            ValidationExpression="^\d+"
                            Display="Static"
                            ErrorMessage="Only Numbers"
                            EnableClientScript="False"
                            runat="server"></asp:RegularExpressionValidator>
                    </div>

                </div>

                <div class="form-group row">
                    <label class="control-label col-xs-2">Imagen:</label>
                    <div class="col-xs-6">
                        <asp:FileUpload ID="ImagenFileUpload" class="bg-primary" runat="server" />
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

    <!--Hasta aqui, Copiar este Pedazo de Codigo para todos los registros y consultas.-->
</asp:Content>
