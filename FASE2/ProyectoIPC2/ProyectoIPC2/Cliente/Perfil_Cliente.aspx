<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Perfil_Cliente.aspx.cs" Inherits="ProyectoIPC2.Cliente.Perfil_Cliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="~/CSS/Botones.css" rel="stylesheet" type="text/css" />
    <link href="CSS/Perfil.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .auto-style1 {
            height: 54px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
    <table style="width:100%;text-align:center;">
        <tr>
            <td>&nbsp;</td>
            <td>
               <asp:Label ID="Label"  CssClass="Txt_info" runat="server" Text="Usuario: "> </asp:Label>
               <asp:Label ID="Lbl_Usuario"  CssClass="Txt_info" runat="server" >
                    <br/>
                </asp:Label><asp:Label ID="lbl_mensaje" runat="server"></asp:Label></td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <table style="width:100%; text-align:center;">
                    <tr>
                        <td>
                            <asp:TextBox ID="Txt_NIT" runat="server" CssClass="Txt_info" placeholder="NIT"></asp:TextBox></td>
                        <td rowspan="9">
                            <asp:Panel ID="Panel1" runat="server">
                                <table style="width:100%; text-align:center;">
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>
                                            <asp:Label ID="Label1" runat="server" CssClass="Txt_info" Text="Contraseña"></asp:Label></td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>
                                            <asp:TextBox ID="Txt_Actual" CssClass="Txt_info"  runat="server" placeholder="Actual" TextMode="Password"></asp:TextBox></td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>
                                            <asp:TextBox ID="Txt_Nueva" CssClass="Txt_info"  runat="server" placeholder="Nueva" TextMode="Password"></asp:TextBox></td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td style=" text-align:center;">
                                            <asp:Button ID="Btn_Cambio_Pass" CssClass="button-jumbo button-flat-highlight Txt_info"  runat="server" Text="Actualizar" OnClick="Btn_Cambio_Pass_Click" Height="57px" />
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="Txt_Tarjeta" runat="server" CssClass="Txt_info"  placeholder="Tarjeta"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="Txt_DPI_Entrega" runat="server" CssClass="Txt_info"  placeholder="DPI Entrega"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="Txt_Nombre" runat="server" CssClass="Txt_info"  placeholder="Nombre"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="Txt_Apellido" runat="server" CssClass="Txt_info"  placeholder="Apellido"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="Txt_Telefono" runat="server" CssClass="Txt_info"  placeholder="Telefono" ></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="Txt_correo" runat="server" CssClass="Txt_info"  placeholder="Correo" ></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="Txt_Domicilio" runat="server" CssClass="Txt_info"  placeholder="Domicilio" ></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><asp:DropDownList ID="Ddl_Sucursal" CssClass="Txt_info" runat="server" Height="96px"></asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <asp:Button ID="Btn_Actualizar" runat="server" CssClass="Txt_info button-jumbo button-flat-primary " Text="Actualizar" Height="54px" OnClick="Btn_Actualizar_Click" /></td>
                    </tr>
                </table>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
  
</asp:Content>