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
                            <asp:TextBox ID="Txt_Cod_Empleado" runat="server" placeholder="ID Empleado" CssClass=" TxtGen"></asp:TextBox></td>
                        <td rowspan="12">
                            <asp:DropDownList ID="Ddl_Departamento" runat="server" OnSelectedIndexChanged="Ddl_Departamento_SelectedIndexChanged" AutoPostBack="true" CssClass="TxtGen"></asp:DropDownList>
                            <asp:Button ID="Btn_Ver_Todos" runat="server" Text="Ver Empleados Sucursal" OnClick="Btn_Ver_Todos_Click" CssClass="button-jumbo button-flat-primary"/>
                            <asp:GridView ID="Grd_Empleados" runat="server">
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Visitar Perfil
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:RadioButton ID="Rbn_S" runat="server" AutoPostBack="True" 
                                                oncheckedchanged="Rbn_S_CheckedChanged" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:DropDownList ID="Ddl_Suc_Dep" runat="server" CssClass="TxtGen"></asp:DropDownList> </td>
                    </tr>
                     <tr>
                        <td>
                            &nbsp;</td>
                    </tr>
                     <tr>
                        <td> <asp:TextBox ID="Txt_Sueldo" runat="server" placeholder="Sueldo" CssClass="TxtGen"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td>
                            <asp:Button ID="Btn_Modificar" runat="server" Text="Modificar" OnClick="Btn_Modificar_Click" CssClass="button-jumbo button-flat-highlight" /> </td>
                    </tr>
                    <tr>
                        <td><asp:Button ID="Btn_Despedir" runat="server" Text="Despedir" OnClick="Btn_Despedir_Click" CssClass="button-jumbo button-flat-caution"/></td>
                    </tr>
                    <tr><td></td></tr>
                    <tr><td></td></tr>
                    <tr><td></td></tr>
                    <tr><td></td></tr>
                    <tr><td></td></tr>
                    <tr><td></td></tr>
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
