<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Facturacion.aspx.cs" Inherits="ProyectoIPC2.Empleados.Facturacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;<asp:Label ID="Label1" runat="server" Text="Facturacion" CssClass="Titulo"></asp:Label></td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <table style="width:100%;">
                    <tr>
                        <td>&nbsp;</td>
                        <td>
                            <asp:TextBox ID="Txt_Casilla" runat="server" placeholder="Casilla Cliente" CssClass="TxtGen"></asp:TextBox>
                            <br />
                            <asp:Button ID="Btn_Buscar" runat="server" Text="Buscar Paquetes" CssClass="button-jumbo button-flat-royal" OnClick="Btn_Buscar_Click" Width="266px" />
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>
                            <asp:DropDownList ID="Ddl_Paquetes" runat="server" CssClass="TxtGen" Visible="false">
                            </asp:DropDownList>
                            <br />
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>
                            <asp:Button ID="Btn_Facturar" runat="server" Visible="false" Text="Generar PDF Factura" CssClass="button-jumbo button-flat-caution" OnClick="Btn_Facturar_Click" />
                        </td>
                        <td>&nbsp;</td>
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
