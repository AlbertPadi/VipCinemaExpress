<%@ Page Title="" Language="C#" MasterPageFile="~/SiteUser.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="VIPCinemaExpress.Login1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/adm/assets/css/style.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <script src="js/bootstrap.min.js"></script>
    <script src="js/jquery.js"></script>

    <div class="container">
        <div class="row">
            <div class="col-md-4 col-md-offset-4">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title">Please sign in</h3>
                    </div>
                    <div class="panel-body">
                        <fieldset>
                            <div class="form-group">
                                <asp:TextBox ID="Usuariotextbox" runat="server" CssClass="form-control" placeholder="Usuario"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:TextBox ID="Passwordtextbox" runat="server" CssClass="form-control" TextMode="Password" placeholder="Password"></asp:TextBox>

                            </div>
                            <div class="form-control row">
                                <asp:CheckBox ID="RememberCheckBox" runat="server" />
                            </div>
                            <div class="col-xs-5">
                                <asp:Button ID="EntrarButton" CssClass="btn btn-primary" runat="server" Text="Acceder" OnClick="EntrarButton_Click" />
                            </div>

                        </fieldset>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
