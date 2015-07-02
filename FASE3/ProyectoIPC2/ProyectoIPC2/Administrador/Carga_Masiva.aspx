<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Carga_Masiva.aspx.cs" Inherits="ProyectoIPC2.Administrador.Carga_Masiva" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 33px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 100%;">
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:FileUpload ID="Flu_CSV" runat="server" />
            </td>
            <td></td>
        </tr>
        <tr>
            <td class="auto-style1"></td>
            <td class="auto-style1">
                <asp:DropDownList ID="Ddl_Tipo_Carga" runat="server">
                    <asp:ListItem Value="1">Impuestos</asp:ListItem>
                    <asp:ListItem Value="2">Empleados</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="auto-style1"></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td><asp:Button ID="Btn_Procesar" runat="server" Text="Cargar Archivo CSV" OnClick="Btn_Procesar_Click" /></td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Label ID="Lbl_Mensaje" runat="server"></asp:Label></td>
            <td></td>
        </tr>
    </table>
</asp:Content>
