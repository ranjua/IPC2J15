<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Perfil_Empleado.aspx.cs" Inherits="ProyectoIPC2.Director.Perfil_Empleado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%;text-align:center;">
        <tr>
            <td>&nbsp;</td>
            <td></td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td></td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <table style="width:100%; text-align:center;">
                    <tr>
                        <td>
                           <asp:Label ID="Lbl_Usuario"  CssClass="Txt_info" runat="server"></asp:Label></td>
                        <td rowspan="10">
                            <asp:Panel ID="Pnl_Historial" runat="server">
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style4">
                            <asp:Label ID="Lbl_Nombre" runat="server"></asp:Label>
                            </td>
                                </tr>
                    <tr>
                        <td class="auto-style4">
                            <asp:Label ID="Lbl_Apellido" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="auto-style4">
                            <asp:Label ID="Lbl_Telefono" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="auto-style4">
                            <asp:Label ID="Lbl_Correo" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="auto-style4">
                            <asp:Label ID="Lbl_Domicilio" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="auto-style4">
                            <asp:Label ID="Lbl_Sucursal" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="auto-style4">
                            <asp:Label ID="Lbl_Departamento" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="auto-style4">
                            <asp:Label ID="Lbl_Sueldo" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="auto-style4">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style3">
                            &nbsp;</td>
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
