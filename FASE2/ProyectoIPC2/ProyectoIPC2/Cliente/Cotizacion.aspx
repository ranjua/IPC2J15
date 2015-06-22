<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Cotizacion.aspx.cs" Inherits="ProyectoIPC2.Cliente.Cotizacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="~/CSS/Botones.css" rel="stylesheet" type="text/css" />
    <link href="CSS/Perfil.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%;">
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:TextBox ID="Txt_Precio" runat="server" CssClass="Txt_info" placeholder="Precio de Producto en Q"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:TextBox ID="Txt_Libras" runat="server" CssClass="Txt_info" placeholder="Peso en Libras"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
               <asp:DropDownList ID="Ddl_Tipo_Impuesto" CssClass="Txt_info" runat="server"></asp:DropDownList>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="Btn_Cotizar" runat="server" CssClass="button-jumbo button-flat-royal" Text="Cotizar" OnClick="Btn_Cotizar_Click" />
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:TextBox ID="Txt_Total" runat="server" CssClass="Txt_info" placeholder="Total en Q"></asp:TextBox>
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
