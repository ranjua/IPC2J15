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
            <td></td>
                
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <table style="width: 100%;">
                     
                    <tr>

                        <td>
                            <asp:TextBox ID="Txt_Cod_Empleado" runat="server" placeholder="ID Empleado"></asp:TextBox></td>
                        <td rowspan="6">
                            <asp:DropDownList ID="Ddl_Departamento" runat="server" OnSelectedIndexChanged="Ddl_Departamento_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                            <asp:Button ID="Btn_Ver_Todos" runat="server" Text="Ver Empleados Sucursal" OnClick="Btn_Ver_Todos_Click" />
                            <asp:GridView ID="Grd_Empleados" runat="server">
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:DropDownList ID="Ddl_Suc_Dep" runat="server"></asp:DropDownList> </td>
                    </tr>
                     <tr>
                        <td>
                            &nbsp;</td>
                    </tr>
                     <tr>
                        <td> <asp:TextBox ID="Txt_Sueldo" runat="server" placeholder="Sueldo"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td>
                            <asp:Button ID="Btn_Modificar" runat="server" Text="Modificar" OnClick="Btn_Modificar_Click" /> </td>
                    </tr>
                    <tr>
                        <td><asp:Button ID="Btn_Despedir" runat="server" Text="Despedir" OnClick="Btn_Despedir_Click" /></td>
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
