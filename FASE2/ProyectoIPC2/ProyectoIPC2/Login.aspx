<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ProyectoIPC2.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title><%: Page.Title %>Quetzal Express</title>
    <link href="CSS/Botones.css" rel="stylesheet" type="text/css" />
    <link href="CSS/Login.css" rel="stylesheet" type="text/css" />
    <script>
        function Registrar_Error() {
            var slide_Activa = $('#Login');
            var slide_Siguiente = $('#Registro');
            slide_Activa.fadeOut(1000).removeClass('active_slide');
            slide_Siguiente.fadeIn(2000).addClass('active_slide');
        }
        function Olvido_Error() {
            var slide_Activa = $('#Login');
            var slide_Siguiente = $('#Olvido');
            slide_Activa.fadeOut(1000).removeClass('active_slide');
            slide_Siguiente.fadeIn(2000).addClass('active_slide');
        }
    </script>
</head>
<body>
    <form id="Form_Login" runat="server">
    <div id="M_Encabezado">
    <div id="Encabezado">
        <asp:Label id="Lbl_Titulo" runat="server" Text="Quetzal Express" ></asp:Label>
    </div>
    <div id="Sub-Encabezado">
        <asp:Label ID="Lbl_SubTitulo" runat="server" Text="Login" ></asp:Label>
    </div>
        </div>
        
    <div id="C_LRF">
        <div id="SubC_LRF">
            
            <div id="Login" class="slide active_slide" >
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <asp:Panel ID="Panel1" runat="server" defaultbutton="Btn_Login" >
                <div class="Contenido">
                    <asp:TextBox ID="Txt_Correo" CssClass="Txt_Login_Pass" runat="server" placeholder="Usuario" ></asp:TextBox>
                    <asp:TextBox ID="Txt_Pass" CssClass="Txt_Login_Pass" TextMode="Password" runat="server" placeholder="Contraseña"></asp:TextBox>
                </div>
                <br />
                <div class="Advertencias">
                <asp:Label ID="Lbl_Mensaje_Error" runat="server" CssClass="button-caution" Visible="false"></asp:Label>
                </div>
                <div class="Botones">
                <asp:Button ID="Btn_Login" CssClass="button-jumbo button-primary" runat="server" Text="Ingresar" Width="200px" OnClick="Btn_Login_Click" />
                </div>
                    </asp:Panel>
            </div>
         
            <div id="Registro" class="slide">
                <div class="Contenido">
                    <br />
                    <asp:TextBox ID="Txt_DPI" CssClass="Txt_Login" runat="server" TextMode="Number" placeholder="DPI" ></asp:TextBox>
                    <asp:TextBox ID="Txt_NIT" CssClass="Txt_Login" runat="server" placeholder="NIT"></asp:TextBox>
                    <asp:TextBox ID="Txt_Tarjeta" CssClass="Txt_Login" runat="server" TextMode="Number" placeholder="Tarjeta"></asp:TextBox>
                    <asp:TextBox ID="Txt_Nombre" CssClass="Txt_Login" runat="server" placeholder="Nombre"></asp:TextBox>
                    <asp:TextBox ID="Txt_Apellido" CssClass="Txt_Login" runat="server" placeholder="Apellido"></asp:TextBox>
                    <asp:TextBox ID="Txt_Telefono" CssClass="Txt_Login" runat="server" TextMode="Number" placeholder="Telefono"></asp:TextBox>
                    <asp:TextBox ID="Txt_NCorreo" CssClass="Txt_Login" TextMode="Email" runat="server" placeholder="Correo"></asp:TextBox>
                    <asp:TextBox ID="Txt_Domicilio" CssClass="Txt_Login" runat="server" placeholder="Domicilio" ></asp:TextBox>
                    <asp:DropDownList ID="Ddl_Sucursal" CssClass="Txt_Login" runat="server"></asp:DropDownList>

                </div>
                <br />
               
                <div class="Botones">
                <asp:Button ID="Btn_Registrarse" CssClass="button-jumbo button-action" runat="server" Text="Registrarse" OnClick="Btn_Registrarse_Click" />
                </div>
            </div>
            <div id="Olvido" class="slide">
                <div class="Contenido">
                    <br />
                    <asp:TextBox ID="Txt_PCorreo" CssClass="Txt_Login" TextMode="Email" runat="server" placeholder="Correo"></asp:TextBox>
                </div>
                 <div class="Advertencias">
                <asp:Label ID="Lbl_Olvido_Mensaje" runat="server" CssClass="button-primary" Visible="false"></asp:Label>
                </div>
            </div>
        </div>
        <div class="nav">
             <a href="#" id="Siguiente_L" class="Siguiente">
                 <asp:Label ID="Label1" runat="server" Text="Login"></asp:Label></a>
             <a href="#" id="Siguiente_R" class="Siguiente">
                 <asp:Label ID="Label2" runat="server" Text="Registrarse"></asp:Label></a>
            <asp:Label ID="Lbl_Mensaje" runat="server" CssClass="Siguiente button-primary" Visible="false"></asp:Label>
        </div>

    </div>
    </form>
    <script src="//ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
    <script src="JS/Login.js"></script>
</body>

</html>
