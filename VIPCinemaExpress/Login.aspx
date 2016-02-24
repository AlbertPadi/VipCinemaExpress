<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="VIPCinemaExpress.Login" %>
<DOCTYPE HTML>

    
<HTML>
    <HEAD>
        <TITTLE>

        </TITTLE>
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
			    			<asp:textbox ID="Passwordtextbox" runat="server" CssClass="form-control" placeholder="Password"></asp:textbox>
                            
			    		</div>
			    		<div class="checkbox">
			    	    	<label>
                                
			    	    		<input name="remember" type="checkbox" value="Remember Me"> Remember Me
			    	    	</label>
			    	    </div>
			    		<asp:Button ID="Button1" runat="server" Text="Button" class="btn btn-lg btn-success btn-block" OnClick="Button1_Click"/>
			    	</fieldset>
			      	</form>
			    </div>
			</div>
		</div>
	</div>
</div>
    </BODY>

</HTML>
