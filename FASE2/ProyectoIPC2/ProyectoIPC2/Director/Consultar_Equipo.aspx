<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Consultar_Equipo.aspx.cs" Inherits="ProyectoIPC2.Director.Consultar_Equipo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                <asp:DropDownList ID="Ddl_Departamento" runat="server" OnSelectedIndexChanged="Ddl_Departamento_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                <asp:Button ID="Btn_Ver_Todos" runat="server" Text="Ver Empleados Sucursal" OnClick="Btn_Ver_Todos_Click" /></td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:GridView ID="Grd_Empleados" runat="server">
                </asp:GridView>
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
