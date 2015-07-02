<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Sucursal_Departamento.aspx.cs" Inherits="ProyectoIPC2.Administrador.Sucursal_Departamento" %>
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
                <asp:TextBox ID="Txt_suc" runat="server" placeholder="Sucursal"></asp:TextBox>
                <asp:TextBox ID="Txt_sede" runat="server" placeholder="Sede"></asp:TextBox>
                <asp:Button ID="Btn_suc" runat="server" CssClass="button-flat-highlight" Text="Agregar Sucursal" OnClick="Btn_suc_Click" />
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:DropDownList ID="Ddl_suc" runat="server">
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:TextBox ID="Txt_dep" runat="server" placeholder="departamento"></asp:TextBox>
                <asp:Button ID="Btn_dep" runat="server" CssClass="button-flat-primary" Text="Agregar Departamento a Sucursal" OnClick="Btn_dep_Click" />
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
