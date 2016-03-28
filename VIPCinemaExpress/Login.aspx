<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="VIPCinemaExpress.Login" %>
<DOCTYPE HTML>

    
<HTML>
    <HEAD>
        <link href="css/bootstrap.min.css" rel="stylesheet" />
    <script src="js/bootstrap.min.js"></script>
    <script src="js/jquery.js"></script>
    </HEAD>
    <BODY>
        <div class="container">
    <div class="row">
		<div class="col-md-4 col-md-offset-4">
    		<div class="panel panel-default">
			  	<div class="panel-heading">
			    	<h3 class="panel-title">Please sign in</h3>
			 	</div>
			  	<div class="panel-body">
			    	<form runat="server" accept-charset="UTF-8" role="form">
                    <fieldset>
			    	  	<div class="form-group">
                              <asp:textbox id="Usuariotextbox" runat="server" cssclass="form-control" placeholder="Usuario"></asp:textbox>
			    		</div>
			    		<div class="form-group">
			    			<asp:textbox ID="Passwordtextbox" runat="server" CssClass="form-control" textmode="Password" placeholder="Password"></asp:textbox>
                            
			    		</div>
			    		<div class="form-control row">
                            <asp:CheckBox ID="RememberCheckBox" runat="server" />
			    		</div>

			    		<asp:Button ID="EntrarButton" runat="server" Text="Ingresar" class="btn btn-success" OnClick="Button1_Click"/>
			    	</fieldset>
			      	</form>
			    </div>
			</div>
		</div>
	</div>
</div>
    </BODY>

</HTML>
