<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Menu.ascx.cs" Inherits="VIPCinemaExpress.Include.Menu" %>

<!-- Static navbar -->

<%--
<nav class="navbar navbar-inverse">
    <div class="container-fluid">
        <div class="navbar-header">
            <a class="navbar-brand" href="#">WebSiteName</a>
        </div>
        <ul class="nav navbar-nav">
            <li class="active"><a href="#">Home</a></li>
            <li><a href="#">Page 1</a></li>
            <li><a href="#">Page 2</a></li>
            <li><a href="#">Page 3</a></li>
        </ul>
        <ul class="nav navbar-nav navbar-right">
            <li><a href="rUsuarios.aspx"><span class="glyphicon glyphicon-user"></span>Sign Up</a></li>

            <asp:LoginView ID="LoginView1" runat="server">
                <AnonymousTemplate>
                    <li><a href="#">
                        <span class="glyphicon glyphicon-log-in" runat="server" data-toggle="modal" data-target="myModal"></span>Login</a>

                    </li>
                </AnonymousTemplate>
            </asp:LoginView>
        </ul>
    </div>
</nav>--%>


<div class="navbar navbar-default navbar-fixed-top">
    <div class="navbar-collapse collapse">
        <ul class="nav navbar-nav">
            <li>
                <a href="Default.aspx">Inicio</a>
            </li>
            <li>
                <a href="#Quees">Cines</a>
            </li>
            <li>
                <a href="#" data-toggle="modal" data-target="#myModal">Acerca de</a>
                <%--<button type="button" data-toggle="modal" data-target="#myModal">Open Modal</button>--%>
            </li>
            <li>
                <a href="#" data-toggle="modal" data-target="#myModal1">Contactarnos</a>
            </li>
            <% if (Request.IsAuthenticated)
                { %>
            <li>
                <a href="/adm/default.aspx">
                    <asp:Label ID="AdminPanelLabel" runat="server">Admin Panel</asp:Label></a>
            </li>
            <% } %>
        </ul>
        <ul class=" nav navbar-nav pull-right">
            <asp:LoginView ID="LoginView1" runat="server">
                <AnonymousTemplate>
                    <li>

                        <%--                    <li><a href="#"><span class="glyphicon glyphicon-user" data-toggle="modal" data-target="myModal"></span>Login</a></li>--%>
                        <%-- <asp:Label ID="Label1" runat="server" data-toggle="modal" data-target="myModal" Text=" Conectar"></asp:Label>--%>
<%--                        <button type="button" id="LoginButton" class="glyphicon glyphicon-user" data-toggle="modal" data-target=".bs-example-modal-lg">Login</button>--%>
                        <a href="#" data-toggle="modal" class="glyphicon glyphicon-user" data-target=".bs-example-modal-lg">Login</a>

                    </li>

                    <li><a href="rUsuarios.aspx"><span class="glyphicon glyphicon-user"></span>Sign Up</a></li>

                </AnonymousTemplate>
                <LoggedInTemplate>
                    <li style="color: white; padding-top: 19px;">
                        <asp:Label ID="UsuarioL" runat="server" Text="Bienvenido,"></asp:Label>&nbsp
                    </li>
                    <li style="color: white; padding-top: 19px;">
                        <asp:LoginName ID="UsuarioN" runat="server" />
                    </li>
                    <li>
                        <asp:LoginStatus ID="LoginStatus" runat="server" />
                    </li>
                </LoggedInTemplate>
            </asp:LoginView>
        </ul>
    </div>
    <!--/.nav-collapse -->
</div>



<div class="modal fade bs-example-modal-lg" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" style="display: table;">

    <div class="modal-content">

        <div class="modal-body">

            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal">&times;</button>
                <h4 class="modal-title">Login</h4>
            </div>
            <div class="modal-body">
                <div class="form-group row">
                    <label for="UsuarioTextbox" class="col-sm-2 col-md-6 form-control-label">Usuario:</label>
                    <div class="col-sm-10 col-md-6">
                        <asp:TextBox ID="UsuarioTextbox" runat="server" CssClass="form-control" placeholder="Usuario"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group row">
                    <label for="PasswordTextBox" class="col-sm-2 col-md-6 form-control-label">Contraseña:</label>
                    <div class="col-sm-10 col-md-6">
                        <asp:TextBox ID="PasswordTextBox" runat="server" TextMode="Password" CssClass="form-control" placeholder="Contraseña"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-sm-offset-10">
                        <asp:Button ID="EntrarButton" CssClass="btn btn-primary" runat="server" Text="Entrar" OnClick="EntrarButton_Click" />
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-md-12 col-centered">
                        <asp:CheckBox ID="RememberMeCheckBox" runat="server" Text=" Remember Me?" />
                    </div>
                </div>
                <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
            </div>


        </div>

    </div>

</div>



<%--<div id="myModal" class="modal fade" role="dialog" style="display: table;">
    <div class="modal-dialog">

        <!-- Modal content-->
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal">&times;</button>
                <h4 class="modal-title">Modal Header</h4>
            </div>
            <div class="modal-body">
                <div class="form-group row">
                    <label for="UsuarioTextbox" class="col-sm-2 col-md-6 form-control-label">Usuario:</label>
                    <div class="col-sm-10 col-md-6">
                        <asp:TextBox ID="UsuarioTextbox" runat="server" CssClass="form-control" placeholder="Usuario"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group row">
                    <label for="PasswordTextBox" class="col-sm-2 col-md-6 form-control-label">Contraseña:</label>
                    <div class="col-sm-10 col-md-6">
                        <asp:TextBox ID="PasswordTextBox" runat="server" TextMode="Password" CssClass="form-control" placeholder="Contraseña"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-sm-offset-10">
                        <asp:Button ID="EntrarButton" CssClass="btn btn-primary" runat="server" Text="Entrar" OnClick="EntrarButton_Click" />
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-md-12 col-centered">
                        <asp:CheckBox ID="RememberMeCheckBox" runat="server" Text=" Remember Me?" />
                    </div>
                </div>

            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
            </div>
        </div>

    </div>
</div>--%>





<!-- Modal -->
<div id="myModal" class="modal fade" role="dialog" style="display:table;">
  <div class="modal-dialog">

    <!-- Modal content-->
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal">&times;</button>
        <h4 class="modal-title">Acerca de</h4>
      </div>
      <div class="modal-body">
        <p>Vip Cinema Express es un sitio web de tipo prueba, se esta implementando nuevas mejoras y pronto vendran nuevos cambios - By Padilla Solutions®. .</p>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
      </div>
    </div>

  </div>
</div>


<div id="myModal1" class="modal fade" role="dialog" style="display:table;">
  <div class="modal-dialog">

    <!-- Modal content-->
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal">&times;</button>
        <h4 class="modal-title">Contactos</h4>
      </div>
      <div class="modal-body">
        <p>Puede contactarnos a albertopadi91@hotmail.com o jhoanpadi@gmail.com - Padilla Solutions®. .</p>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
      </div>
    </div>

  </div>
</div>