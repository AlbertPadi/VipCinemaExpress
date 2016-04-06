<%@ Page Title="" Language="C#" MasterPageFile="~/SiteUser.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="VIPCinemaExpress.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- start: Slider -->
    <div class="slider-wrapper">

        <div id="da-slider" class="da-slider">
            <div class="da-slide">
                <h2>Transporter 3</h2>
                <p>Es una pelicula de accion pura, el protagonista Jason busca la venganza de quien coloca un dispositivo para eliminarlo</p>

                <!--<asp:Button ID="ReservarButton" href="/adm/Registros/rReservaciones.aspx" class="btn btn-primary" runat="server" Text="Reservar" />-->

                <div class="da-img">
                    <img src="img/parallax-slider/Transporter3.png" alt="image01" />
                </div>
            </div>
            <div class="da-slide">
                <h2>Legion</h2>
                <p>Una pelicula de drama, accion y suspenso</p>
                <div class="da-img">
                    <img src="img/parallax-slider/legion.jpg" alt="image02" />
                </div>
            </div>
            <div class="da-slide">
                <h2>No Devoluaciones</h2>
                <p>Una pelicula totalmente comedia, un padre y madre ala vez</p>

                <div class="da-img">
                    <img src="img/parallax-slider/Noseaceptandevoluaciones.jpg" alt="image03" />
                </div>
            </div>
            <div class="da-slide">
                <h2>Resacón</h2>
                <p>Una pelicula de caricaturas animadas, comedia y drama</p>

                <div class="da-img">
                    <img src="img/parallax-slider/Rio-2.png" alt="image04" />
                </div>
               
            </div>
            <div class="da-slide">
                <h2>Rio-2</h2>
                <p>La saga Resacón es una franquicia de tres películas estadounidenses producidas por Legendary Pictures y distribuidas por Warner Bros. Pictures. </p>

                <div class="da-img">
                    <img src="img/Resacon.jpg" />
                </div>
            </div>
            <nav class="da-arrows">
                <span class="da-arrows-prev"></span>
                <span class="da-arrows-next"></span>
            </nav>
        </div>

    </div>


    <!-- end: Slider -->


    <asp:Repeater ID="CarteleraRepeater" runat="server">
    </asp:Repeater>




    <!----------------------------------------------------------------------------------------------------------->
    <!--start: Wrapper-->

    <div id="wrapper">

        <!--start: Container -->
        <div class="container">

            <asp:Repeater ID="yourRepeater" runat="server" OnItemCommand="yourRepeater_ItemCommand">
                <ItemTemplate>
                    <a href="rReservaciones.aspx?Id=<%# Eval("PeliculaId") %>">
                        <img id="imgImagen" runat="server" alt="" src='<%# Eval("Imagen")%>' commandname="Redirect" commandargument='<%# Eval("PeliculaId") %>' height="210" width="150" /></a>
                    <a href="rReservaciones.aspx?Id=<%# Eval("PeliculaId") %>"></a>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>

</asp:Content>
