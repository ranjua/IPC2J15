<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Reportar_Paquete_Perdido.aspx.cs" Inherits="ProyectoIPC2.Empleados.Reportar_Paquete_Perdido" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .Txt_info {}
    .auto-style2 {
        width: 728px;
    }
    .auto-style3 {
        width: 942px;
    }
    </style>
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
                <table style="width:100%;">
                    <tr>
                        <td class="auto-style3">
                            <asp:Label ID="Label1" runat="server" CssClass="Txt_info" Text="Reportar Paquete Perdido"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label2" runat="server" CssClass="Txt_info" Text="Cargar CSV con Paquetes Reales"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style3">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style3">
                            <asp:TextBox ID="Txt_Perdido" runat="server" CssClass="Txt_info" placeholder="Codigo de Paquete Perdido" Width="303px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:FileUpload ID="Flu_Archivo" runat="server" CssClass="TxtGen" />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style3">
                            <asp:Button ID="Btn_Registrar" runat="server" CssClass="button-jumbo button-flat-royal" OnClick="Btn_Registrar_Click" Text="Registrar Paquete" />
                        </td>
                        <td>
                            <asp:Button ID="Btn_Cargar_CSV" runat="server" CssClass="button-jumbo button-flat-highlight" OnClick="Btn_Cargar_CSV_Click" Text="Cargar Archivo con Paquetes" />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style3">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style3">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Label ID="Lbl_Mensaje" runat="server" CssClass="TxtCod"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
