<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Devolucion.aspx.cs" Inherits="ProyectoIPC2.Empleados.Devolucion" %>
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
                <br />
                <br />
                <asp:DropDownList ID="Ddl_Paquetes" runat="server" CssClass="TxtGen" Visible="false">
                </asp:DropDownList>

                <br />
                <br />
                <br />

                <asp:Button ID="Btn_Devolver" CssClass="button-flat-primary button-jumbo" runat="server" Text="Devolver" OnClick="Btn_Devolver_Click" Width="305px" />
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
