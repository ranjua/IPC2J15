<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Reportes.aspx.cs" Inherits="ProyectoIPC2.Administrador.Reportes" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
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
            <td>
                <asp:DropDownList ID="Ddl_Reporte" runat="server" CssClass="button-flat-primary">
                    <asp:ListItem Selected="True" Value="1">Paquetes por Categoria de Impuesto</asp:ListItem>
                    <asp:ListItem Value="2">Paquetes por Sucursal</asp:ListItem>
                    <asp:ListItem Value="3">Resumen de Empleados</asp:ListItem>
                    <asp:ListItem Value="4">Top 5 Categoria de Impuestos</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="Btn_Reporte" runat="server" Text="Generar Reporte" OnClick="Btn_Reporte_Click" CssClass="button-jumbo button-flat-royal" />
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
